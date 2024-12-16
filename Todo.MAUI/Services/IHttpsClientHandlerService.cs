namespace Todo.MAUI.Services;

public interface IHttpsClientHandlerService
{
    HttpMessageHandler GetPlatformMessageHandler();
}