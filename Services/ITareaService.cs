using ApiDeTareas.DTOs;
namespace ApiDeTareas.Services;
public interface ITareaService
{
    Task<IEnumerable<TareaResponse>> GetAllAsync();
    Task<TareaResponse?> GetByIdAsync(int id);
    Task<TareaResponse> CreateAsync(TareaCreate dto);
    Task<bool> UpdateAsync(int id, TareaUpdate dto);
    Task<bool> DeleteAsync(int id);
}