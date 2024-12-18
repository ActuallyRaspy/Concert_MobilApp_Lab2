using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Data.DTO;
using Todo.Data.Entity;
using Todo.Data.Repository;

namespace TodoAPI.Controllers;

public enum ErrorCode
{
    BookingNameRequired,
    BookingIDInUse,
    RecordNotFound,
    CouldNotCreateItem,
    CouldNotUpdateItem,
    CouldNotDeleteItem
}

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookingsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> ListBookings()
    {
        var bookings = await _unitOfWork.Bookings.All();
        return Ok(_mapper.Map<IEnumerable<BookingDto>>(bookings));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookingDto dto)
    {
        Booking item;
        try
        {
            item = _mapper.Map<Booking>(dto);
            if (item == null || !ModelState.IsValid)
            {
                return BadRequest(ErrorCode.BookingNameRequired.ToString());
            }
            bool itemExists = await _unitOfWork.Bookings.DoesItemExist(item.ID);
            if (itemExists)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                ErrorCode.BookingIDInUse.ToString());
            }
            _unitOfWork.Bookings.Insert(item);
            int affectedItems = await _unitOfWork.Complete();
        }
        catch (Exception)
        {
            return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
        }
        return Ok(_mapper.Map<BookingDto>(item));
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] BookingDto dto) // Only edits booking.name, should probably be changed??
    {
        Booking item;
        try
        {
            item = _mapper.Map<Booking>(dto);
            if (item == null || !ModelState.IsValid)
            {
                return BadRequest(ErrorCode.BookingNameRequired.ToString());
            }
            var existingItem = await _unitOfWork.Bookings.Find(item.ID);
            if (existingItem == null)
            {
                return NotFound(ErrorCode.RecordNotFound.ToString());
            }
            item.Name = existingItem.Name;
            _unitOfWork.Bookings.Update(item);
            
            int affectedItems = await _unitOfWork.Complete();
        }
        catch (Exception)
        {
            return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
        }
        //return NoContent();
        return Ok(_mapper.Map<BookingDto>(item));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        Booking? item;
        try
        {
            item = await _unitOfWork.Bookings.Find(id);
            if (item == null)
            {
                return NotFound(ErrorCode.RecordNotFound.ToString());
            }
            //_todoRepository.Delete(id);
            _unitOfWork.Bookings.Delete(id);
            int affectedItems = await _unitOfWork.Complete();
        }
        catch (Exception)
        {
            return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
        }
        //return NoContent();
        return Ok(_mapper.Map<BookingDto>(item));
    }
}