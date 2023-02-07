using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APImercaderias.Modelos;

public partial class UsersContext : DbContext
{
    public UsersContext()
    {
    }

    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Familia> Familia { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-RDML62O\\SQLEXPRESS;Initial Catalog=MERCADERIAS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Familia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FAMILIA__3214EC07A7A68B03");

            entity.ToTable("FAMILIA");

            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MARCA__3214EC07DE7D816B");

            entity.ToTable("MARCA");

            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoProducto).HasName("PK__PRODUCTO__785B009E065EEBBF");

            entity.ToTable("PRODUCTOS");

            entity.Property(e => e.CodigoProducto).HasMaxLength(50);
            entity.Property(e => e.DescripcionProducto).HasMaxLength(50);
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.PrecioCosto).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdFamiliaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdFamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCTOS__IdFam__3D5E1FD2");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCTOS__IdMar__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
