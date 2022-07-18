using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace shoppingAPP_EF.Models.EF
{
    public partial class shoppingAPPContext : DbContext
    {
        public shoppingAPPContext()
        {
        }

        public shoppingAPPContext(DbContextOptions<shoppingAPPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=WIN8\\NIKHILINSTANCE; database= shoppingAPP;user id=sa ; password=Password1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__Products__DD36D5627393BA12");

                entity.Property(e => e.PId)
                    .ValueGeneratedNever()
                    .HasColumnName("pId");

                entity.Property(e => e.PCategory)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pCategory");

                entity.Property(e => e.PIsInStock).HasColumnName("pIsInStock");

                entity.Property(e => e.PName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pName");

                entity.Property(e => e.PPrice).HasColumnName("pPrice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
