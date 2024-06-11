using System;
using System.Collections.Generic;
using BestCoffee.Entities;
using Microsoft.EntityFrameworkCore;

namespace BestCoffee;

public partial class BestCoffeeDbContext : DbContext
{
    public BestCoffeeDbContext(DbContextOptions<BestCoffeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OrdenDeCompra> OrdenDeCompra { get; set; }

    public virtual DbSet<OrdenDeCompraProducto> OrdenDeCompraProducto { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Proveedor> Proveedor { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrdenDeCompra>(entity =>
        {
            entity.HasKey(e => e.IdOrdenDeCompra).HasName("PK__OrdenDeC__5874C406ED8300BC");

            entity.Property(e => e.IdOrdenDeCompra).HasColumnName("idOrdenDeCompra");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.ImporteTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("importeTotal");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.OrdenDeCompra)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenDeCompra_Proveedor");
        });

        modelBuilder.Entity<OrdenDeCompraProducto>(entity =>
        {
            entity.HasKey(e => new { e.IdOrdenDeCompra, e.IdProducto }).HasName("PK__OrdenDeC__680B8E15BCB26EB5");

            entity.ToTable("OrdenDeCompra_Producto");

            entity.Property(e => e.IdOrdenDeCompra).HasColumnName("idOrdenDeCompra");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");

            entity.HasOne(d => d.IdOrdenDeCompraNavigation).WithMany(p => p.OrdenDeCompraProducto)
                .HasForeignKey(d => d.IdOrdenDeCompra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenDeCompra_Producto_OrdenDeCompra");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.OrdenDeCompraProducto)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenDeCompra_Producto_Producto");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__07F4A132DBCEE5E8");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaVenc)
                .HasColumnType("datetime")
                .HasColumnName("fechaVenc");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Importe)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("importe");
            entity.Property(e => e.NumeroLote).HasColumnName("numeroLote");
            entity.Property(e => e.StockActual).HasColumnName("stockActual");
            entity.Property(e => e.StockMax).HasColumnName("stockMax");
            entity.Property(e => e.StockMin).HasColumnName("stockMin");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Proveedor");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__A3FA8E6B33B93E3A");

            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Cuit).HasColumnName("cuit");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(200)
                .HasColumnName("razonSocial");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
