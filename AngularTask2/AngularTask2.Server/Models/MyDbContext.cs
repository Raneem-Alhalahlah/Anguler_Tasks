using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AngularTask2.Server.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ContactU> ContactUs { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<SubService> SubServices { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-0O2CUA4;Database=Anguler;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE488126AD820");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.Email, "UQ__Admin__A9D1053473C8FE09").IsUnique();

            entity.Property(e => e.AdminName).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD7B7865AA4F3");

            entity.ToTable("Cart");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Cart__UserId__5535A963");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Carts)
                .HasForeignKey(d => d.VoucherId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Cart__VoucherId__5629CD9C");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__CartItem__488B0B0A5E03879E");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__CartItems__CartI__59FA5E80");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__CartItems__Produ__59063A47");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0B07E1E8BA");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__ContactU__C87C037CF7525049");

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Subject).HasMaxLength(255);
            entity.Property(e => e.SubmittedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF6D04C62A");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ShippingStatus)
                .HasMaxLength(100)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cart).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Orders__CartId__619B8048");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Orders__UserId__60A75C0F");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Orders)
                .HasForeignKey(d => d.VoucherId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Orders__VoucherI__628FA481");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderitemId).HasName("PK__OrderIte__42A47DBF25EB6E85");

            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__OrderItem__Order__656C112C");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A5825EB008C");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentGateway).HasMaxLength(50);
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("TransactionID");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Payments__OrderI__6C190EBB");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CD784899FA");

            entity.Property(e => e.Color).HasColumnName("color");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DiscountPercentage)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(2, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.Visiblity).HasDefaultValue(true);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Products__Catego__4222D4EF");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79CEC47D1188");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_ReviewFk");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__4550733FD4A09661");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.ServiceDescription).HasMaxLength(500);
            entity.Property(e => e.ServiceName).HasMaxLength(50);
        });

        modelBuilder.Entity<SubService>(entity =>
        {
            entity.HasKey(e => e.SubServiceId).HasName("PK__subServi__C5C51FFA7AC0870C");

            entity.ToTable("subService");

            entity.Property(e => e.SubServiceId).HasColumnName("subServiceID");
            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.SubServiceDescription).HasMaxLength(500);
            entity.Property(e => e.SubServiceName).HasMaxLength(50);

            entity.HasOne(d => d.Service).WithMany(p => p.SubServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Service_SubService");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C0FB26FAC");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534153334D8").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.LoyaltyPoints).HasDefaultValue(0);
            entity.Property(e => e.Passwword)
                .HasMaxLength(50)
                .HasColumnName("passwword");
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.VoucherId).HasName("PK__Vouchers__3AEE79211FDDC9A5");

            entity.HasIndex(e => e.VoucherCode, "UQ__Vouchers__7F0ABCA9C14622F8").IsUnique();

            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(2, 2)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.VoucherCode).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
