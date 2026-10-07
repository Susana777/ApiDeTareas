using Microsoft.AspNetCore.Mvc;
using ApiDeTareas.DTOs;
using ApiDeTareas.Services;
using System.Formats.Tar;

namespace ApiDeTareas.Controllers;

[ApiController]
[Route ("api/[controller]")]
public class TareasController : ControllerBase
{
    private readonly ITareaService _service;

    public TareasController(ITareaService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public async Task<ActionResult<IEnumerable<TareaResponse>>> GetAll()
    {
        var tareas = await _service.GetAllAsync();
        return Ok(tareas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TareaResponse>> GetById(int id)
    {
        var tarea = await _service.GetByIdAsync(id);
        if (tarea is null)
        {
            return NotFound();
        }

        return Ok(tarea);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TareaResponse>> Create([FromBody]TareaCreate dto)
    {
        var nuevaTarea = await _service.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = nuevaTarea.Id }, nuevaTarea);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(int id, [FromBody] TareaUpdate dto)
    {
        var exito = await _service.UpdateAsync(id, dto);
        if (!exito)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var exito = await _service.DeleteAsync(id);
        if (!exito)
        {
            return NotFound();
        }

        return NoContent();
    }

}