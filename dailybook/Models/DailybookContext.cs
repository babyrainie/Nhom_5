using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dailybook.Models;

public partial class DailybookContext : DbContext
{
    public DailybookContext()
    {
    }

    public DailybookContext(DbContextOptions<DailybookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Attribute> Attributes { get; set; }

    public virtual DbSet<AttributesPrice> AttributesPrices { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TransactStatus> TransactStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-972F54DR;Initial Catalog=dailybook;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.AccountId).HasColumnName("accountID");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(200)
                .HasColumnName("fullname");
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .HasColumnName("pass");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("roleID");
            entity.Property(e => e.Salt)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("salt");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Roles");
        });

        modelBuilder.Entity<Attribute>(entity =>
        {
            entity.Property(e => e.AttributeId).HasColumnName("AttributeID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<AttributesPrice>(entity =>
        {
            entity.ToTable("AttributesPrice");

            entity.Property(e => e.AttributesPriceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("AttributesPriceID");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AttributeId).HasColumnName("AttributeID");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("productID");

            entity.HasOne(d => d.AttributesPriceNavigation).WithOne(p => p.AttributesPrice)
                .HasForeignKey<AttributesPrice>(d => d.AttributesPriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttributesPrice_Attributes");

            entity.HasOne(d => d.Product).WithMany(p => p.AttributesPrices)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttributesPrice_Products");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId);

            entity.Property(e => e.CatId).HasColumnName("catID");
            entity.Property(e => e.Alias)
                .HasMaxLength(250)
                .HasColumnName("alias");
            entity.Property(e => e.CatName)
                .HasMaxLength(200)
                .HasColumnName("catName");
            entity.Property(e => e.Cover)
                .HasMaxLength(250)
                .HasColumnName("cover");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Levels).HasColumnName("levels");
            entity.Property(e => e.MetaDesc).HasMaxLength(250);
            entity.Property(e => e.MetaKey).HasMaxLength(250);
            entity.Property(e => e.Ordering).HasColumnName("ordering");
            entity.Property(e => e.ParentId).HasColumnName("parentID");
            entity.Property(e => e.Published).HasColumnName("published");
            entity.Property(e => e.Thumb)
                .HasMaxLength(250)
                .HasColumnName("thumb");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CusId);

            entity.Property(e => e.CusId).HasColumnName("cusID");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Ava).HasMaxLength(255);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(200)
                .HasColumnName("fullname");
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.LocationId).HasColumnName("locationID");
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .HasColumnName("pass");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Salt)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("salt");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.LocationId).HasColumnName("locationID");
            entity.Property(e => e.Levels).HasColumnName("levels");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Namewithtype)
                .HasMaxLength(255)
                .HasColumnName("namewithtype");
            entity.Property(e => e.Parentcode).HasColumnName("parentcode");
            entity.Property(e => e.Pathwithtype)
                .HasMaxLength(255)
                .HasColumnName("pathwithtype");
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .HasColumnName("slug");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.CusId).HasColumnName("cusID");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.Paid).HasColumnName("paid");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("paymentDate");
            entity.Property(e => e.PaymentId).HasColumnName("paymentID");
            entity.Property(e => e.ShipDate)
                .HasColumnType("datetime")
                .HasColumnName("shipDate");
            entity.Property(e => e.TransactStatusId).HasColumnName("transactStatusID");

            entity.HasOne(d => d.Cus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.TransactStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TransactStatusId)
                .HasConstraintName("FK_Orders_TransactStatus");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.OrderDetailId).HasColumnName("orderDetailID");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.OrderNumber).HasColumnName("orderNumber");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ShipDate)
                .HasColumnType("datetime")
                .HasColumnName("shipDate");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderDetails_Orders");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .HasColumnName("alias");
            entity.Property(e => e.Bestsellers).HasColumnName("bestsellers");
            entity.Property(e => e.CatId).HasColumnName("catID");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("dateCreated");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("dateModified");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Homeflag).HasColumnName("homeflag");
            entity.Property(e => e.MetaDesc).HasMaxLength(255);
            entity.Property(e => e.MetaKey).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("productName");
            entity.Property(e => e.ShortDesc)
                .HasMaxLength(255)
                .HasColumnName("shortDesc");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.Thumb)
                .HasMaxLength(255)
                .HasColumnName("thumb");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Cat).WithMany(p => p.Products)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK_Products_Categories");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId).HasColumnName("roleID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<TransactStatus>(entity =>
        {
            entity.ToTable("TransactStatus");

            entity.Property(e => e.TransactStatusId).HasColumnName("TransactStatusID");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
