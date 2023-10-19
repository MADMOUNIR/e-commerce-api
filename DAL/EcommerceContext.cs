using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EcommerceApi.DAL
{
    public partial class EcommerceContext : DbContext
    {
        public EcommerceContext()
        {
        }

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Ecommerce;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {

                entity.HasKey(e => new { e.Id });

                entity.ToTable("products");

                entity.Property(e => e.Category)                    
                    .HasColumnName("category");

                entity.Property(e => e.Code)                    
                    .HasColumnName("code");

                entity.Property(e => e.DateCreat)
                    .HasColumnType("datetime")
                    .HasColumnName("date_creat");

                entity.Property(e => e.Description)                    
                    .HasColumnName("description");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image)                    
                    .HasColumnName("image");

                entity.Property(e => e.InventoryStatus)                   
                    .HasColumnName("inventory_status");

                entity.Property(e => e.Name)                   
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rating).HasColumnName("rating");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
