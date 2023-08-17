using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductInformationDemo.Models;

public partial class ProductDbContext : DbContext
{
    public ProductDbContext()
    {
    }

    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductMst> ProductMsts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=ARCHE-ITD440\\SQLEXPRESS;Database=Product_DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductMst>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product___B40CC6CD251B8830");

            entity.ToTable("Product_Mst");

            entity.Property(e => e.ProductDescription).HasMaxLength(100);
            entity.Property(e => e.ProductName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
