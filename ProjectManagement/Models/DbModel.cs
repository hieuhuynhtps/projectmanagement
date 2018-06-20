namespace ProjectManagement.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<DUAN> DUANs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHONGBAN> PHONGBANs { get; set; }
        public virtual DbSet<TRUSO_PHONG> TRUSO_PHONGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DUAN>()
                .Property(e => e.MaDA)
                .IsUnicode(false);

            modelBuilder.Entity<DUAN>()
                .Property(e => e.MaPB)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MaPB)
                .IsUnicode(false);

            modelBuilder.Entity<PHONGBAN>()
                .Property(e => e.MaPB)
                .IsUnicode(false);

            modelBuilder.Entity<PHONGBAN>()
                .HasMany(e => e.NHANVIENs)
                .WithRequired(e => e.PHONGBAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONGBAN>()
                .HasOptional(e => e.TRUSO_PHONG)
                .WithRequired(e => e.PHONGBAN);

            modelBuilder.Entity<TRUSO_PHONG>()
                .Property(e => e.MaPB)
                .IsUnicode(false);
        }
    }
}
