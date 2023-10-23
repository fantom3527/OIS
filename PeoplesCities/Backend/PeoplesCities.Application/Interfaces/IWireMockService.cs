namespace PeoplesCities.Application.Interfaces
{
    public interface IWireMockService
    {
        //TODO: Добавить свойство IsStarted - и проверять запросом, запущен ли сервер.
        //TODO: Добавить мб массив mappings.
        public string Url { get; }

        Task<HttpResponseMessage> GetResponseAsync(string? url);
    }
}
