using System.Text;
using System.Text.Json;

namespace ArtsofteClient.Services;

public class RequestSender : IRequestSender
{
    private readonly HttpClient _client;

    public RequestSender(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<T> SendGetRequest<T>(string url)
    {
        var response = await _client.GetAsync(url);
        var scriptText = await response.Content.ReadAsStringAsync();

        var appData = JsonSerializer.Deserialize<T>(scriptText, JsonSerializerOptions);

        return appData;
    }
    
    
    public async Task<T> SendPostRequest<T>(string url, object body)
    {
        var jsonContent = JsonSerializer.Serialize(body);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(url, content);
        response.EnsureSuccessStatusCode();

        var responseText = await response.Content.ReadAsStringAsync();

        var responseData = JsonSerializer.Deserialize<T>(responseText, JsonSerializerOptions);

        return responseData;
    }


    public async Task SendPostRequest(string url, object body)
    {
        var jsonContent = JsonSerializer.Serialize(body);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(url, content);
        response.EnsureSuccessStatusCode();
    }


    public async Task SendWithBodyAsync(string url, object body, HttpMethod httpMethod)
    {
        var request = new HttpRequestMessage
        {
            Method = httpMethod,
            RequestUri = new Uri(url),
            Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json")
        };
        
        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }


    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
}