using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace ProductsAPI.Services
{
    public class CsvReaderService : ICsvReaderService
    {
        private readonly ILogger<CsvReaderService> _logger;
        IConfiguration _configuration;

        public CsvReaderService(IConfiguration configuration, ILogger<CsvReaderService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// Reads records from given csv file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">Name of the file (e.g. File.csv).</param>
        /// <param name="fileBytes">Byte array of the file.</param>
        /// <param name="hasHeader">Defines if file has header row.</param>
        /// <param name="delimiter">Delimiter that splits data in your file.</param>
        /// <param name="cultureInfo">Culture info used in your file.</param>
        /// <returns>List of records, which were succesfully parsed.</returns>
        public async Task<List<T>> GetRecords<T>(string fileName, byte[] fileBytes, bool hasHeader = true, Delimiter delimiter = Delimiter.Semicolon, string cultureInfo = "sk-SK")
        {
            var date = DateTime.Now.ToString("dd.MM.yyyy_hh.mm");
            var filePath = _configuration.GetValue<string>("CsvFolderPath") + $"{date}_{fileName}";

            await File.WriteAllBytesAsync(filePath, fileBytes);

            var validRecords = new List<T>();
            var invalidRecordsCount = 0;

            using (var reader = new StreamReader(filePath))
            {
                var conf = new CsvConfiguration(CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(cultureInfo))
                {
                    HasHeaderRecord = hasHeader,
                    Delimiter = $"{(char)delimiter}",
                    BadDataFound = null,
                    ReadingExceptionOccurred = (ex) =>
                    {
                        _logger.LogWarning(ex.Exception, $"Row id: {ex.Exception.Context.Parser.Row} in file {fileName} cannot be parsed.");
                        invalidRecordsCount++;
                        return false;
                    }
            };

                using (var csv = new CsvReader(reader, conf))
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<T>();
                        if (record != null)
                            validRecords.Add(record);
                    }
            }

            _logger.LogInformation($"Successfully parsed: {validRecords.Count()} records.\nUnsuccessfull records: {invalidRecordsCount}");

            return validRecords;
        }

        public enum Delimiter
        {
            Semicolon = ';',
            Space = ' ',
            Tab = '\t',
            Comma = ','
        }
    }
}
