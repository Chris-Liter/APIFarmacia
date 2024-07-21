using APIFarmacia.Models;
using Microsoft.EntityFrameworkCore;

namespace APIFarmacia.Contexts
{
    public class ConexionPostgreSQL:DbContext
    {
        public ConexionPostgreSQL(DbContextOptions<ConexionPostgreSQL> options) : base(options)
        {
            
        }

        public DbSet<Detalle_Factura> Detalle_Facturas => Set<Detalle_Factura>();
        public DbSet<Cliente> Cliente => Set<Cliente>();
        public DbSet<Factura> Factura => Set<Factura>();
        public DbSet<Productos> Productos => Set<Productos>();
        public DbSet<Usuarios> Usuarios => Set<Usuarios>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Carrito>(entity =>
            //{
            //    entity.HasKey(e => e.Car_id);
            //    entity.ToTable("Carrito");
            //    entity.Property(e => e.Car_id).HasColumnName("Car_id");

            //    entity.Property(e => e.id_usuario)
            //            .IsRequired()
            //            .HasMaxLength(50)
            //            .HasColumnName("id_usuario");

            //    entity.Property(e => e.Id_producto)
            //           .IsRequired()
            //           .HasMaxLength(50)
            //           .HasColumnName("Id_producto");

            //    entity.Property(e => e.Id_dunio)
            //           .IsRequired()
            //           .HasMaxLength(50)
            //           .HasColumnName("Id_dunio");

            //});
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.cli_id);
            });
        }
    }
}
