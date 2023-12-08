using RestSharp;

namespace ProductsAPI.Clients
{
    public class BlobClient
    {
        private readonly RestClient _client;

        public BlobClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        /// <summary>
        /// Downloads specified file from Blob.
        /// </summary>
        /// <param name="fileName">Name of the file to download (e.g. File.csv).</param>
        /// <returns>Byte array of the file.</returns>
        /// <exception cref="Exception">Unable to download.</exception>
        public byte[] GetFileBytes(string fileName)
        {
            var request = new RestRequest(new Uri($"{fileName}", UriKind.Relative), Method.Get);

            var response = _client.DownloadData(request);
            if (response is null)
                throw new Exception($"Unable to download file: {fileName}");

            return response;
        }
    }
}
