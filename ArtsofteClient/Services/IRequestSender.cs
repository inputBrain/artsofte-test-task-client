namespace ArtsofteClient.Services;

public interface IRequestSender
{
    Task<T> SendGetRequest<T>(string url);

    Task<T> SendPostRequest<T>(string url, object body);
    
    Task SendPostRequest(string url, object body);

    Task SendWithBodyAsync(string url, object body, HttpMethod httpMethod);
}