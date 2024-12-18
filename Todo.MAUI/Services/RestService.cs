using AutoMapper;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Todo.Data.DTO;
using Todo.MAUI.Models;

namespace Todo.MAUI.Services;

public class RestService : IRestService
{
    private HttpClient _client;
    private JsonSerializerOptions _serializerOptions;
    private IHttpsClientHandlerService _httpsClientHandlerService;
    private IMapper _mapper;

    public List<TodoItem>? Items { get; private set; }

    public RestService(IHttpsClientHandlerService service, IMapper mapper)
    {
        _mapper = mapper;
#if DEBUG
        _httpsClientHandlerService = service;
        HttpMessageHandler handler = _httpsClientHandlerService.GetPlatformMessageHandler();
        if (handler != null)
            _client = new HttpClient(handler);
        else
            _client = new HttpClient();
#else
_client = new HttpClient();
#endif
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<List<TodoItem>?> RefreshDataAsync()
    {
        Items = new List<TodoItem>();
        Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Items = _mapper.Map<List<TodoItem>>
                (
                JsonSerializer.Deserialize<List<BookingDto>>(content, _serializerOptions)
                );
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return Items;
    }

    public async Task SaveTodoItemAsync(TodoItem item, bool isNewItem = false)
    {
        Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
        try
        {
            string json = JsonSerializer.Serialize<BookingDto>(_mapper.Map<BookingDto>(item),
            _serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null!;
            if (isNewItem)
                response = await _client.PostAsync(uri, content);
            else
                response = await _client.PutAsync(uri, content);
            if (response.IsSuccessStatusCode)
                Debug.WriteLine(@"\tTodoItem successfully saved.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }

    public async Task DeleteTodoItemAsync(string id)
    {
        Uri uri = new Uri(string.Format(Constants.RestUrl, id));
        try
        {
            HttpResponseMessage response = await _client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
                Debug.WriteLine(@"\tTodoItem successfully deleted.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }
}