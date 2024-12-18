using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Data.DTO;
using Todo.Data.Entity;
using Todo.Data.Repository;

namespace TodoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PerformancesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PerformancesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // List all performances
    [HttpGet]
    public async Task<IActionResult> ListPerformances()
    {
        var performances = await _unitOfWork.Performances.All();
        return Ok(_mapper.Map<IEnumerable<PerformanceDto>>(performances));
    }

    // Get performance by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPerformanceById(string id)
    {
        var performance = await _unitOfWork.Performances.Find(id);
        if (performance == null)
        {
            return NotFound("Performance not found.");
        }
        return Ok(_mapper.Map<PerformanceDto>(performance));
    }

    // Get performances by concert ID
    [HttpGet("concert/{concertId}")]
    public async Task<IActionResult> GetPerformancesByConcertId(string concertId)
    {
        var performances = await _unitOfWork.Performances.Find(concertId);
        return Ok(_mapper.Map<IEnumerable<PerformanceDto>>(performances));
    }
}
