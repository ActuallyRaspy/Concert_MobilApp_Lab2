using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Data.DTO;
using Todo.Data.Entity;
using Todo.Data.Repository;

namespace TodoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConcertsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ConcertsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // List all concerts
    [HttpGet]
    public async Task<IActionResult> ListConcerts()
    {
        IEnumerable<Concert> concerts = await _unitOfWork.Concerts.All();
        return Ok(_mapper.Map<IEnumerable<ConcertDto>>(concerts));
    }

    // Get concert by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetConcertById(string id)
    {
        Concert concert = await _unitOfWork.Concerts.Find(id);
        if (concert == null)
        {
            return NotFound("Concert not found.");
        }
        return Ok(_mapper.Map<ConcertDto>(concert));
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ConcertDto dto)
    {
        Concert item;
        try
        {
            item = _mapper.Map<Concert>(dto);
            if (item == null || !ModelState.IsValid)
            {
                return BadRequest(ErrorCode.BookingNameRequired.ToString()); //ändra
            }
            bool itemExists = await _unitOfWork.Concerts.DoesItemExist(item.ID);
            if (itemExists)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                ErrorCode.BookingIDInUse.ToString()); //ändra
            }
            _unitOfWork.Concerts.Insert(item);
            int affectedItems = await _unitOfWork.Complete();
        }
        catch (Exception)
        {
            return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
        }
        return Ok(_mapper.Map<BookingDto>(item));
    }
}
