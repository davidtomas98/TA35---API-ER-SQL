# TA35---API-ER-SQL

# Ejercicio 1 -- Piezas y Proveedores :computer:

En este ejercicio, se aborda la configuraci�n b�sica de una aplicaci�n ASP.NET Core, incluyendo la configuraci�n de servicios, repositorios y el pipeline de solicitudes HTTP.

## :file_folder: Estructura del Proyecto

- `Exercicio1.Models`: Contiene las clases de modelo que representan a las piezas, suministra y proveedores.
- `Exercicio1.Repositories`: Contiene las interfaces y las implementaciones de los repositorios para acceder a los datos.
- `Exercicio1.Data`: Contiene el contexto de la base de datos y la configuraci�n de Entity Framework Core.
- `Exercicio1.Controllers`: Contiene los controladores de la API para cada recurso.
- `Program.cs`: Archivo de inicio de la aplicaci�n.
- `Startup.cs`: Configuraci�n de la aplicaci�n y servicios.

## :heavy_check_mark: Requisitos

- .NET Core SDK 5.0 o superior
- MySQL Server 10.11.2 o superior

## :gear: Configuraci�n

1. Clona este repositorio en tu m�quina local.
2. Abre el archivo `appsettings.json` en la carpeta `Exercicio1` y configura la cadena de conexi�n a tu base de datos MySQL en la clave `"ConnectionStrings"`.

## :rocket: Instrucciones

1. Ejecuta `dotnet restore` en la ra�z del proyecto para restaurar las dependencias.
2. Ejecuta `dotnet run` para iniciar la aplicaci�n.
3. Accede a `https://localhost:5001/swagger` en tu navegador para interactuar con la documentaci�n de la API mediante Swagger.

## :earth_americas: Endpoints Disponibles

- `/api/piezas`: CRUD para las piezas.
- `/api/suministra`: CRUD para  suministra.
- `/api/proveedores`: CRUD para los proveedores.


# Ejercicio 2 -- Los Cient�ficos :computer:

En este ejercicio, se implementa una API ASP.NET Core para administrar asignaciones de cient�ficos a proyectos. La API permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en los recursos de Cient�ficos, Proyectos y Asignaciones.

## :file_folder: Estructura del Proyecto

- `Exercicio2.Models`: Contiene las clases de modelo que representan a los cient�ficos, proyectos y asignaciones.
- `Exercicio2.Repositories`: Contiene las interfaces y las implementaciones de los repositorios para acceder a los datos.
- `Exercicio2.Data`: Contiene el contexto de la base de datos y la configuraci�n de Entity Framework Core.
- `Exercicio2.Controllers`: Contiene los controladores de la API para cada recurso.
- `Program.cs`: Archivo de inicio de la aplicaci�n.
- `Startup.cs`: Configuraci�n de la aplicaci�n y servicios.

## :heavy_check_mark: Requisitos

- .NET Core SDK 5.0 o superior
- MySQL Server 10.11.2 o superior

## :gear: Configuraci�n

1. Clona este repositorio en tu m�quina local.
2. Abre el archivo `appsettings.json` en la carpeta `Exercicio2` y configura la cadena de conexi�n a tu base de datos MySQL en la clave `"ConnectionStrings"`.

## :rocket: Instrucciones

1. Ejecuta `dotnet restore` en la ra�z del proyecto para restaurar las dependencias.
2. Ejecuta `dotnet run` para iniciar la aplicaci�n.
3. Accede a `https://localhost:5001/swagger` en tu navegador para interactuar con la documentaci�n de la API mediante Swagger.

## :earth_americas: Endpoints Disponibles

- `/api/cientificos`: CRUD para los cient�ficos.
- `/api/proyectos`: CRUD para los proyectos.
- `/api/asignados`: CRUD para las asignaciones.


# Ejercicio 3 -- Los Grandes Almacenes :computer:

En este ejercicio, se abordan varios ejemplos de configuraci�n de una aplicaci�n ASP.NET Core con controladores de API para administrar diferentes recursos. Cada recurso (Cajeros, M�quinas Registradoras, Productos, Ventas) tiene su propio conjunto de controladores y repositorios.

## :file_folder: Estructura del Proyecto

- `Exercicio3.Models`: Contiene las clases de modelo para los diferentes recursos.
- `Exercicio3.Repositories`: Contiene las interfaces y las implementaciones de los repositorios para acceder a los datos.
- `Exercicio3.Data`: Contiene el contexto de la base de datos y la configuraci�n de Entity Framework Core.
- `Exercicio3.Controllers`: Contiene los controladores de la API para cada recurso.
- `Program.cs`: Archivo de inicio de la aplicaci�n.
- `Startup.cs`: Configuraci�n de la aplicaci�n y servicios.

## :heavy_check_mark: Requisitos

- .NET Core SDK 5.0 o superior
- MySQL Server 10.11.2 o superior

## :gear: Configuraci�n

1. Clona este repositorio en tu m�quina local.
2. Abre el archivo `appsettings.json` en la carpeta `Exercicio3` y configura la cadena de conexi�n a tu base de datos MySQL en la clave `"ConnectionStrings"`.

## :rocket: Instrucciones

1. Ejecuta `dotnet restore` en la ra�z del proyecto para restaurar las dependencias.
2. Ejecuta `dotnet run` para iniciar la aplicaci�n.
3. Accede a `https://localhost:5001/swagger` en tu navegador para interactuar con la documentaci�n de la API mediante Swagger.

## :earth_americas: Endpoints Disponibles

- `/api/cajeros`: CRUD para los cajeros.
- `/api/maquinas-registradoras`: CRUD para las m�quinas registradoras.
- `/api/productos`: CRUD para los productos.
- `/api/ventas`: CRUD para las ventas, b�squeda y operaciones por c�digos.


## Ejercicio 4 -- Los Investigadores :computer:

En este ejercicio, se implementa una API ASP.NET Core para administrar investigadores, equipos, facultades y reservas. La API permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en los diferentes recursos.

### :file_folder: Estructura del Proyecto

- `Exercicio4.Models`: Contiene las clases de modelo que representan a los investigadores, equipos, facultades y reservas.
- `Exercicio4.Repositories`: Contiene las interfaces y las implementaciones de los repositorios para acceder a los datos.
- `Exercicio4.Data`: Contiene el contexto de la base de datos y la configuraci�n de Entity Framework Core.
- `Exercicio4.Controllers`: Contiene los controladores de la API para cada recurso.
- `Program.cs`: Archivo de inicio de la aplicaci�n.
- `Startup.cs`: Configuraci�n de la aplicaci�n y servicios.

### :heavy_check_mark: Requisitos

- .NET Core SDK 5.0 o superior
- MySQL Server 10.11.2 o superior

### :gear: Configuraci�n

1. Clona este repositorio en tu m�quina local.
2. Abre el archivo `appsettings.json` en la carpeta `Exercicio4` y configura la cadena de conexi�n a tu base de datos MySQL en la clave `"ConnectionStrings"`.

### :rocket: Instrucciones

1. Ejecuta `dotnet restore` en la ra�z del proyecto para restaurar las dependencias.
2. Ejecuta `dotnet run` para iniciar la aplicaci�n.
3. Accede a `https://localhost:5001/swagger` en tu navegador para interactuar con la documentaci�n de la API mediante Swagger.

### :earth_americas: Endpoints Disponibles

- `/api/investigadores`: CRUD para los investigadores.
- `/api/equipos`: CRUD para los equipos.
- `/api/facultades`: CRUD para las facultades.
- `/api/reservas`: CRUD para las reservas.


## :page_with_curl: Licencia

Este proyecto est� bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para m�s detalles.
