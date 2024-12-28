using Todo.MAUI.Models;

namespace Todo.MAUI.Services;

public class PerformanceService : IPerformanceService
{
    IRestService _restService;

    public PerformanceService(IRestService service)
    {
        _restService = service;
    }

    public Task<List<Performance>?> GetPerformancesAsync()
    {
        return _restService.RefreshPerformancesAsync();
    }

    public Task SavePerformanceAsync(Performance performance, bool isNewPerformance = false)
    {
        return _restService.SavePerformanceAsync(performance, isNewPerformance);
    }

    public Task DeletePerformanceAsync(Performance performance)
    {
        return _restService.DeletePerformanceAsync(performance.ID);
    }
}