using ApiDeTareas.DTOs;
using ApiDeTareas.Models;

namespace ApiDeTareas.Services;
public class TareaService : ITareaService
{
    private static readonly List<Tarea> _tareas = new();
    private static int _nextId = 1;
    private static TareaResponse MapToDto(Tarea t) => new TareaResponse(t.Id, t.Nombre, t.Completada, t.FechaCreacion);
    public Task<IEnumerable<TareaResponse>> GetAllAsync()
    {
        var dtos = _tareas.Select(MapToDto);
        return Task.FromResult(dtos);
    }
    public Task<TareaResponse?> GetByIdAsync(int id)
    {
        var tarea = _tareas.FirstOrDefault(t => t.Id == id);
        var dto = tarea is null ? null : MapToDto(tarea);
        return Task.FromResult(dto);
    }
    public Task<TareaResponse> CreateAsync(TareaCreate dto)
    {
        var nuevaTarea = new Tarea
        {
            Id = _nextId++,
            Nombre = dto.nombre,
            Completada = false,
            FechaCreacion = DateTime.Now
        };

        _tareas.Add(nuevaTarea);
        return Task.FromResult(MapToDto(nuevaTarea));
    }
    public Task<bool> UpdateAsync(int id, TareaUpdate dto)
    {
        var tarea = _tareas.FirstOrDefault(t => t.Id == id);
        if(tarea is null) return Task.FromResult(false);

        tarea.Nombre = dto.Nombre;
        tarea.Completada = dto.Completada;

        return Task.FromResult(true);
    }
    public Task<bool> DeleteAsync(int id)
    {
        var tarea = _tareas.FirstOrDefault(t => t.Id == id);
        if (tarea is null) return Task.FromResult(false);

        _tareas.Remove(tarea);
        return Task.FromResult(true);
    }
}