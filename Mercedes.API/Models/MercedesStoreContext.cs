using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Mercedes.API.Models
{
    public partial class MercedesStoreContext : DbContext
    {
        public MercedesStoreContext()
        {
        }

        public MercedesStoreContext(DbContextOptions<MercedesStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCar> TblCars { get; set; }
        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblOrder> TblOrders { get; set; }
        public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; }
        public virtual DbSet<TblRole> TblRoles { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HN830IQ;Database=MercedesStore;User Id= sa; Password=030798;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblCar>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PK__tblCars__1436F0942C29013D");

                entity.ToTable("tblCars");

                entity.Property(e => e.CarId).HasColumnName("carID");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.Color)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Description)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblCars)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__tblCars__categor__1A14E395");
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__tblCateg__23CAF1F8C6C8B514");

                entity.ToTable("tblCategories");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("categoryName");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__tblOrder__0809337DF0BA8105");

                entity.ToTable("tblOrders");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.DateOrder)
                    .HasColumnType("date")
                    .HasColumnName("dateOrder");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tblOrders__userI__15502E78");
            });

            modelBuilder.Entity<TblOrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrdDetailId)
                    .HasName("PK__tblOrder__F50B7E8A4C7BCEEB");

                entity.ToTable("tblOrderDetails");

                entity.Property(e => e.OrdDetailId).HasColumnName("ordDetailID");

                entity.Property(e => e.CarId).HasColumnName("carID");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.TblOrderDetails)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__tblOrderD__carID__1CF15040");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TblOrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__tblOrderD__order__1DE57479");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__tblRoles__CD98460AEAD8EB54");

                entity.ToTable("tblRoles");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("roleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("roleName");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tblUsers__CB9A1CDF50D71391");

                entity.ToTable("tblUsers");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userID");

                entity.Property(e => e.Address)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birthDate");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("createDate");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fullName");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("roleID");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__tblUsers__roleID__1273C1CD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
