# Api De Tareas - Gestion

API RESTful desarrollada con **ASP.NET Core** y C# utilizando una arquitectura basada en controladores, desacoplamiento mediante **DTOs (Records)** y un servicio con almacenamiento en memoria.

---

## Recursos utilizados 

* **Lenguaje**: C# (.NET 8+)
* **Framework**: ASP.NET Core Web API
* **Documentacion**: Swagger UI / OpenAPI (Swashbuckle)
* **Pruebas HTTP**: Postman Collection

## Estructura del proyecto

* `Controllers\`: Coordinacion de peticiones y respuestas RESTful.
* `Services\`: Capa de negocio y gestion de datos en memoria (Ciclo de vida *Singleton*).
* `DTOs\`: Tipos `record` posicionales para evitar vulnerabilidades de *over-posting*.
* `Models\`: Entidades de dominio internas.

---

## Requisitos previos

* [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 o superior).
* [Postman](https://www.postman.com/) (opcional, para ejecutar la suite de pruebas).

---

## Instrucciones de ejecucion

1. **Clonar o descargar el repositorio** e ingresar a la carpeta del proyecto:
    ```bash
    cd ApiDeTareas
    ```
2. **Restaurar las dependencias**:
    `dotnet restore`
3. **Ejecutar la aplicacion**:
    `dotnet run`
4. **Acceder a la documentacion interactiva de Swagger**. Abre tu navegador web e ingresa a: `https://localhost:<puerto>/swagger` 

**Nota**: Reemplaza `<puerto>` por el numero de puerto que muestre tu terminal al ejecutar `dotnet run` (por ejemplo: `7001`). 

## Endpoints y codigos de respuesta HTTP

| Metodo | Ruta | Codigo exitoso | Codigos de error | Descripcion |
|:-:|:-:|:-:|:-:|:-:|
|GET|/api/tareas|200 OK|-|
|GET|/api/tareas/{id}|200 OK|404 NOT FOUND|
|POST|/api/tareas|201 CREATED|400 BAD REQUEST|
|PUT|/api/tareas/{id}|204 NO CONTENT|400 BAD REQUEST, 404 NOT FOUND|
|DELETE|/api/tareas/{id}|204 NO CONTENT| 404 NOT FOUND|

## Pruebas con Postman 
El proyecto incluye una coleccion de pruebas para postman

1. Importa la coleccion `Tareas_API_Collection.json` en Postman

2. Selecciona el entorno **Desarrollo local** con la variable `baseUrl` configurada en `https://localhost:<puerto>`.

3. Ejecuta la coleccion mediante **Collection Runner** para verificar todos los codigos http (`200`,`201`,`204`,`404`).
