using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Data.DTO;
using Todo.Data.Entity;
using Todo.Data.Repository;

namespace TodoAPI.Controllers;

public enum ErrorCode
{
    TodoItemNameAndNotesRequired,
    TodoItemIDInUse,
    RecordNotFound,
    CouldNotCreateItem,
    CouldNotUpdateItem,
    CouldNotDeleteItem
}

[ApiController]
[Route("api/[controller]")]
public class TodoItemsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TodoItemsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        return Ok(_mapper.Map<IEnumerable<TodoItemDto>>(await _unitOfWork.TodoItems.All()));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TodoItemDto dto)
    {
        Booking item;
        try
        {
            item = _mapper.Map<Booking>(dto);
            if (item == null || !ModelState.IsValid)
            {
                return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
            }
            bool itemExists = await _unitOfWork.TodoItems.DoesItemExist(item.ID);
            if (itemExists)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                ErrorCode.TodoItemIDInUse.ToString());
            }
            _unitOfWork.TodoItems.Insert(item);
            int affectedItems = await _unitOfWork.Complete();
        }
        catch (Exception)
        {
            return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
        }
        return Ok(_mapper.Map<TodoItemDto>(item));
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] TodoItemDto dto)
    {
        Booking item;
        try
        {
            item = _mapper.Map<Booking>(dto);
            if (item == null || !ModelState.IsValid)
            {
                return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
            }
            var existingItem = await _unitOfWork.TodoItems.Find(item.ID);
            if (existingItem == null)
            {
                return NotFound(ErrorCode.RecordNotFound.ToString());
            }
            item.Comments = existingItem.Comments;
            //_todoRepository.Update(item);
            //_unitOfWork.TodoItems.Update(item);
            _unitOfWork.TodoItems.Delete(existingItem);
            _unitOfWork.TodoItems.Insert(item);
            int affectedItems = await _unitOfWork.Complete();
        }
        catch (Exception)
        {
            return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
        }
        //return NoContent();
        return Ok(_mapper.Map<TodoItemDto>(item));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        Booking? item;
        try
        {
            item = await _unitOfWork.TodoItems.Find(id);
            if (item == null)
            {
                return NotFound(ErrorCode.RecordNotFound.ToString());
            }
            //_todoRepository.Delete(id);
            _unitOfWork.TodoItems.Delete(id);
            int affectedItems = await _unitOfWork.Complete();
        }
        catch (Exception)
        {
            return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
        }
        //return NoContent();
        return Ok(_mapper.Map<TodoItemDto>(item));
    }
}