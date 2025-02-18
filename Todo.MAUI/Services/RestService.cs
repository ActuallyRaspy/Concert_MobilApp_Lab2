using AutoMapper;
using Azure;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Todo.Data.DTO;
using Todo.MAUI.Models;

namespace Todo.MAUI.Services;

public class RestService :  IRestService
{
    private HttpClient _client;
    private JsonSerializerOptions _serializerOptions;
    private IHttpsClientHandlerService _httpsClientHandlerService;
    private IMapper _mapper;

    public List<Concert>? Items { get; private set; }
    public List<Performance>? Performances { get; private set; }
    public List<Booking>? Bookings { get; private set; }



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

    public async Task<List<Concert>?> RefreshDataAsync()
    {
        Items = new List<Concert>();
        Uri uri = new Uri(string.Format(Constants.BaseUrl+"Concerts", string.Empty));
        Debug.WriteLine($"Requesting: {uri}"); // Prints the full URL

        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Items = _mapper.Map<List<Concert>>
                (
                JsonSerializer.Deserialize<List<ConcertDto>>(content, _serializerOptions)
                );
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return Items;
    }
    public async Task SaveConcertAsync(Concert concert, bool isNewConcert = false)
    {
        Uri uri = new Uri(string.Format(Constants.ConcertUrl, string.Empty));
        try
        {
            string json = JsonSerializer.Serialize<BookingDto>(_mapper.Map<BookingDto>(concert),
            _serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null!;
            if (isNewConcert)
                response = await _client.PostAsync(uri, content);
            else
                response = await _client.PutAsync(uri, content);
            if (response.IsSuccessStatusCode)
                Debug.WriteLine(@"\tConcert successfully saved.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }

    public async Task DeleteConcertAsync(string id)
    {
        Uri uri = new Uri(string.Format(Constants.ConcertUrl, id));
        try
        {
            HttpResponseMessage response = await _client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
                Debug.WriteLine(@"\tConcert successfully deleted.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }
    public async Task<List<Performance>?> RefreshPerformancesAsync()
    {
        Performances = new List<Performance>();
        Uri uri = new Uri(string.Format(Constants.BaseUrl + "Performances", string.Empty));
        Debug.WriteLine($"Requesting: {uri}"); // Prints the full URL

        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Performances = _mapper.Map<List<Performance>>
                (
                JsonSerializer.Deserialize<List<PerformanceDto>>(content, _serializerOptions)
                );
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return Performances;
    }
    public async Task SavePerformanceAsync(Performance performance, bool isNewPerformance = false)
    {
        Uri uri = new Uri(string.Format(Constants.PerformanceUrl, string.Empty));
        try
        {
            string json = JsonSerializer.Serialize<PerformanceDto>(_mapper.Map<PerformanceDto>(performance),
            _serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null!;
            if (isNewPerformance)
                response = await _client.PostAsync(uri, content);
            else
                response = await _client.PutAsync(uri, content);
            if (response.IsSuccessStatusCode)
                Debug.WriteLine(@"\tPerformance successfully saved.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }

    public async Task DeletePerformanceAsync(string id)
    {
        Uri uri = new Uri(string.Format(Constants.PerformanceUrl, id));
        try
        {
            HttpResponseMessage response = await _client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
                Debug.WriteLine(@"\tPerformance successfully deleted.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }

    public async Task<List<Booking>?> RefreshBookingsAsync()
    {
        Bookings = new List<Booking>();
        Uri uri = new Uri(string.Format(Constants.BaseUrl + "Bookings", string.Empty));
        Debug.WriteLine($"Requesting: {uri}"); // Prints the full URL

        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Bookings = _mapper.Map<List<Booking>>
                (
                JsonSerializer.Deserialize<List<BookingDto>>(content, _serializerOptions)
                );
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return Bookings;
    }
    public async Task<HttpResponseMessage> SaveBookingAsync(Booking booking, bool isNewBooking = false)
    {
        Uri uri = new Uri(string.Format(Constants.BookingUrl, string.Empty));

        string json = JsonSerializer.Serialize<BookingDto>(_mapper.Map<BookingDto>(booking), _serializerOptions);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response; // Declare the variable properly

        if (isNewBooking)
        {
            response = await _client.PostAsync(uri, content);  // Store response
            Debug.WriteLine(@"\tBooking successfully saved. " + response);
        }
        else
        {
            response = await _client.PutAsync(uri, content);  // Store response
            Debug.WriteLine(@"\tBooking successfully updated. " + response);
        }

        return response; // Ensure a valid response is returned
    }

    public async Task DeleteBookingAsync(string id)
    {
        Uri uri = new Uri(string.Format(Constants.BookingUrl, id));
        try
        {
            HttpResponseMessage response = await _client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
                Debug.WriteLine(@"\tBooking successfully deleted.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }

}