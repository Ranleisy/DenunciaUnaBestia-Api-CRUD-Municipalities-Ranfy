# DenunciaUnaBestia - CRUD de Municipios

Proyecto de **Web API** con ASP.NET Core para gestionar municipios, desarrollado siguiendo las sesiones del curso.

## Características principales
- ASP.NET Core Web API con **Controllers** (no Minimal APIs)
- Entity Framework Core + SQL Server (LocalDB)
- DTOs para entrada (`CreateMunicipalityDto`) y salida (`MunicipalityDto`)
- Validación básica en el controlador (nombre obligatorio)
- Swagger habilitado solo en entorno de Development
- CRUD completo: GET (todos y por ID), POST, PUT, DELETE
- Base de datos creada automáticamente en LocalDB al hacer el primer POST

## Endpoints disponibles
| Método | Endpoint                        | Descripción                              | Body (ejemplo POST/PUT)                     |
|--------|---------------------------------|------------------------------------------|---------------------------------------------|
| GET    | /api/municipalities             | Lista todos los municipios               | —                                           |
| GET    | /api/municipalities/{id}        | Obtiene un municipio por ID              | —                                           |
| POST   | /api/municipalities             | Crea un nuevo municipio                  | `{ "name": "La Romana", "postalCode": "22000" }` |
| PUT    | /api/municipalities/{id}        | Actualiza un municipio existente         | `{ "name": "La Romana Editada", "postalCode": "22001" }` |
| DELETE | /api/municipalities/{id}        | Elimina un municipio                     | —                                           |

Respuestas HTTP esperadas:
- 200 OK (GET exitoso)
- 201 Created (POST exitoso, con Location header)
- 204 No Content (PUT/DELETE exitoso)
- 400 Bad Request (validación fallida)
- 404 Not Found (ID no existe)

## Cómo ejecutar localmente
1. Clona el repositorio:
git clone https://github.com/Ranleisy/DenunciaUnaBestia-Api-CRUD-Municipalities-Ranfy.git
text2. Entra a la carpeta del proyecto:
cd DenunciaUnaBestia-Api-CRUD-Municipalities-Ranfy/DenunciaUnaBestia.Api
text3. Compila:
dotnet build
text4. Ejecuta:
dotnet run
text5. Abre en el navegador:
http://localhost:5133/swagger
text(El puerto puede variar; mira la consola)

La base de datos `DenunciaUnaBestia` se crea automáticamente en **LocalDB** al hacer el primer POST.

## Tecnologías utilizadas
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server LocalDB
- Swashbuckle.AspNetCore (Swagger)
- DTOs para separación de capas

## Estructura del proyecto
DenunciaUnaBestia.Api/
├── Controllers/
│   └── MunicipalitiesController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Models/
│   ├── Entities/
│   │   └── Municipality.cs
│   └── Dtos/
│       ├── CreateMunicipalityDto.cs
│       └── MunicipalityDto.cs
├── appsettings.Development.json
├── Program.cs
└── DenunciaUnaBestia.Api.csproj
text
