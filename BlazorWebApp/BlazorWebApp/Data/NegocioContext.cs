using BlazorWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BlazorWebApp.Data
{
    public class NegocioContext : DbContext
    {
        public NegocioContext(DbContextOptions<NegocioContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Promocion> Promociones { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { CategoriaId = 1, Nombre = "Notebooks" },
                new Categoria { CategoriaId = 2, Nombre = "Celulares" },
                new Categoria { CategoriaId = 3, Nombre = "Accesorios" }
            );
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    ProductoId = 1,
                    Nombre = "Notebook Lenovo",
                    Descripcion = "Notebook ideal para estudiar, trabajar y navegar por internet. Cuenta con buen rendimiento para tareas diarias.",
                    Precio = 850000,
                    Stock = 10,
                    Imagen = "assets/img/portfolio/1.jpg",
                    CategoriaId = 1
                },
                new Producto
                {
                    ProductoId = 2,
                    Nombre = "Samsung Galaxy",
                    Descripcion = "Celular moderno con buena cámara, gran capacidad de almacenamiento y excelente rendimiento.",
                    Precio = 620000,
                    Stock = 15,
                    Imagen = "assets/img/portfolio/2.jpg",
                    CategoriaId = 2
                },
                new Producto
                {
                    ProductoId = 3,
                    Nombre = "Auriculares Gamer RGB",
                    Descripcion = "Auriculares gamer con sonido envolvente, micrófono integrado y luces RGB.",
                    Precio = 95000,
                    Stock = 25,
                    Imagen = "assets/img/portfolio/3.jpg",
                    CategoriaId = 3
                }
            );
            modelBuilder.Entity<Usuario>().HasData(
    new Usuario
    {
        UsuarioId = 1,
        NombreApellido = "Administrador",
        Email = "admin@electroshop.com",
        Password = "admin123",
        Rol = "Administrador",
        Activo = true
    },
    new Usuario
    {
        UsuarioId = 2,
        NombreApellido = "Cliente Demo",
        Email = "cliente@electroshop.com",
        Password = "cliente123",
        Rol = "Cliente",
        Activo = true
    }


);
            modelBuilder.Entity<Promocion>().HasData(
    new Promocion
    {
        PromocionId = 1,
        Titulo = "Notebook Lenovo",
        Descripcion = "Potencia para trabajar y estudiar. Intel i5 - 16GB RAM - SSD 512GB.",
        Imagen = "assets/img/portfolio/1.jpg",
        PorcentajeDescuento = 15,
        PrecioPromocional = 850000,
        Activo = true,
        Orden = 1
    },
    new Promocion
    {
        PromocionId = 2,
        Titulo = "Samsung Galaxy",
        Descripcion = "Smartphone de última generación con 256GB y cámara de alta calidad.",
        Imagen = "assets/img/portfolio/2.jpg",
        PorcentajeDescuento = 10,
        PrecioPromocional = 620000,
        Activo = true,
        Orden = 2
    },
    new Promocion
    {
        PromocionId = 3,
        Titulo = "Auriculares Gamer",
        Descripcion = "Sonido envolvente, luces RGB y micrófono integrado.",
        Imagen = "assets/img/portfolio/3.jpg",
        PorcentajeDescuento = 20,
        PrecioPromocional = 95000,
        Activo = true,
        Orden = 3
    }

    );



        }
    }
}