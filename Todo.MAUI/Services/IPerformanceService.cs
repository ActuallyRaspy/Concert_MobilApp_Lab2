using Todo.MAUI.Models;

namespace Todo.MAUI.Services;

public interface IPerformanceService
{
    Task<List<Performance>?> GetPerformancesAsync();
    Task SavePerformanceAsync(Performance performance, bool isNewPerformance);
    Task DeletePerformanceAsync(Performance performance);
}