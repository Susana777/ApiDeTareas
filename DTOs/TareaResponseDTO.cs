namespace ApiDeTareas.DTOs;
public record TareaResponse (int Id, string Nombre, bool Completada, DateTime FechaCreacion);