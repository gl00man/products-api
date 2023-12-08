using ProductsAPI.Models.Product;
using static ProductsAPI.Services.CsvReaderService;

namespace ProductsAPI.Services
{
    public interface ICsvReaderService
    {
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
        public Task<List<T>> GetRecords<T>(string fileName, byte[] fileBytes, bool hasHeader = true, string delimiter = ";", string cultureInfo = "sk-SK");
    }
}
