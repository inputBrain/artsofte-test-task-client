namespace ArtsofteClient.Services;

public interface IRequestSender
{
    Task<T> SendGetRequest<T>(string url);

    Task<T> SendPostRequest<T>(string url, object? body);
}