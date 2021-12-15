using DF21.Blazor.Models;
using System.Text;
using System.Text.Json;


namespace DF21.Blazor.Services
{
    public interface IUmbracoIntegrationService
    {
        Task<IEnumerable<TalkResponse>> GetTalks();

        Task<TalkWithComments> GetTalk(Guid talkId);

        Task<string> AddComment(CommentRequest model);

        Task<string> GetWebPubSubClientUrl();
    }

    public class UmbracoIntegrationService : IUmbracoIntegrationService
    {
        private readonly HttpClient _httpClient;

        public UmbracoIntegrationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AddComment(CommentRequest model)
        {
            var requestUrl = string.Format($"https://df21-umbraco.azurewebsites.net/umbraco/api/Comments/AddComments");

            var httpContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(requestUrl, httpContent);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<IEnumerable<TalkResponse>> GetTalks()
        {
            var requestUrl = string.Format($"https://df21-umbraco.azurewebsites.net/umbraco/api/talksapi/GetTalks");

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<TalkResponse>>(await _httpClient.GetStreamAsync(requestUrl), serializeOptions);
        }

        public async Task<TalkWithComments> GetTalk(Guid talkId)
        {
            var requestUrl = string.Format($"https://df21-umbraco.azurewebsites.net/umbraco/api/talksapi/GetTalk?key={talkId}");

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            return await JsonSerializer.DeserializeAsync<TalkWithComments>(await _httpClient.GetStreamAsync(requestUrl), serializeOptions);
        }

        public async Task<string> GetWebPubSubClientUrl()
        {
            var requestUrl = string.Format($"https://df21azurewebpubsubclienttoken.azurewebsites.net/api/GetClientUrl");

            var response = await _httpClient.PostAsync(requestUrl,null);

            return await response.Content.ReadAsStringAsync();
        }

    }    
}
