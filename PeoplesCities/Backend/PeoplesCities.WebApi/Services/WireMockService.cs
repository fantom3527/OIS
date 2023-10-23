using PeoplesCities.Application.Interfaces;

namespace PeoplesCities.Application.Sevices
{
    public class WireMockService : IWireMockService
    {
        private readonly string _url;
        private readonly HttpClient _httpClient;
        public string Url { get => _url; }

        public WireMockService(string url)
        {
            _httpClient = new HttpClient();
            _url = url;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        /// <summary>
        /// Отправка запроса на сервер.
        /// </summary>
        /// <param name="requestUrl">Url запроса</param>
        /// <returns>Тело ответа</returns>
        public async Task<HttpResponseMessage> GetResponseAsync(string? requestUrl)
        {
            return await _httpClient.GetAsync(Url + requestUrl);
        }
    }
}
