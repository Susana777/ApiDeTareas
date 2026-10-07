namespace ApiDeTareas.Models;
public class Tarea {
    public required int Id {get; set;}
    public required string Nombre {get; set;}
    public required bool Completada {get; set;}
    public required DateTime FechaCreacion {get; set;}
}