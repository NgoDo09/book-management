using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Model
{
    public partial class book_managementContext : DbContext
    {
        public book_managementContext()
        {
        }

        public book_managementContext(DbContextOptions<book_managementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccount> TblAccounts { get; set; }
        public virtual DbSet<TblCustomer> TblCustomers { get; set; }
        public virtual DbSet<TblOrder> TblOrders { get; set; }
        public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=12345;Database=book_management");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAccount>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__tbl_Acco__F3DBC573EE5DDEAE");

                entity.ToTable("tbl_Account");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__tbl_Cust__A4AE64D836608529");

                entity.ToTable("tbl_Customer");

                entity.HasIndex(e => e.Username, "UQ__tbl_Cust__F3DBC57267631C0B")
                    .IsUnique();

                entity.Property(e => e.Contact).HasMaxLength(30);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .HasColumnName("username");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.TblCustomer)
                    .HasForeignKey<TblCustomer>(d => d.Username)
                    .HasConstraintName("FK__tbl_Custo__usern__3A81B327");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__tbl_Orde__C3905BCFB4F235E0");

                entity.ToTable("tbl_Order");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Order__Total__3D5E1FD2");
            });

            modelBuilder.Entity<TblOrderDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_Order_Details");

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Order__Order__412EB0B6");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Order__Produ__4222D4EF");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tbl_Prod__B40CC6CD5F5ED8E0");

                entity.ToTable("tbl_Product");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
