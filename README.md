# ElectroShop - Proyecto Integrador Blazor

ElectroShop es una aplicación web desarrollada con Blazor para la venta y administración de productos electrónicos.  
El sistema permite visualizar productos, registrar clientes, administrar productos y gestionar un carrito de compras.

## Tecnologías utilizadas

- Blazor Web App
- .NET 8
- C#
- Entity Framework Core
- SQL Server
- Bootstrap 5
- JavaScript Interop
- CSS Isolation

## Funcionalidades principales

### Sitio público

- Página de inicio con banner principal.
- Carrusel de productos destacados.
- Sección de ofertas especiales.
- Sección de contacto.
- Catálogo de productos.
- Carrito de compras.

### Registro de clientes

- Formulario con validaciones.
- Registro de nombre, email, teléfono y producto de interés.
- Guardado de datos en base de datos SQL Server.

### Administración

- Panel de administración.
- Listado de productos.
- Alta, modificación y eliminación de productos.
- Listado de clientes registrados.
- Edición y eliminación de clientes.
- Búsqueda y paginación en listados.

## Componentes Razor reutilizables

El proyecto utiliza componentes reutilizables para mantener el código ordenado y facilitar el mantenimiento.

Componentes principales:

- `Banner.razor`
- `CarruselProductos.razor`
- `SeccionOfertas.razor`
- `SeccionContacto.razor`
- `Footer.razor`
- `ProductoCard.razor`
- `RegistroForm.razor`

## CSS Isolation

Se implementó CSS Isolation en componentes Razor para mantener estilos propios de cada componente.

Archivos utilizados:

- `Banner.razor.css`
- `ProductoCard.razor.css`
- `RegistroForm.razor.css`

## Base de datos

El proyecto utiliza Entity Framework Core con SQL Server.

Entidades principales:

- Cliente
- Producto
- Categoria

Relación:

- Una categoría puede tener muchos productos.
- Cada producto pertenece a una categoría.

## Migraciones

Se utilizaron migraciones de Entity Framework Core para crear y actualizar la base de datos.

Comandos utilizados:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update