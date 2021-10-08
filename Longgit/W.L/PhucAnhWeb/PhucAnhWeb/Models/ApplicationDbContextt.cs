using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PhucAnhWeb.Models
{
    public partial class ApplicationDbContextt : DbContext
    {
        public ApplicationDbContextt()
            : base("name=ApplicationDbContextt3")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<CTSanPham> CTSanPhams { get; set; }
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<ImageSanPham> ImageSanPhams { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiDanhMucSanPham> LoaiDanhMucSanPhams { get; set; }
        public virtual DbSet<LoaiThongSo> LoaiThongSoes { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhanLoaiSanPham> PhanLoaiSanPhams { get; set; }
        public virtual DbSet<PhanLoaiTheoHangSp> PhanLoaiTheoHangSps { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<SanPhamDonHang> SanPhamDonHangs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThongSoSanPham> ThongSoSanPhams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Content>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Content>()
                .Property(e => e.Detail)
                .IsFixedLength();

            modelBuilder.Entity<Content>()
                .Property(e => e.Warranty)
                .IsFixedLength();

            modelBuilder.Entity<Content>()
                .Property(e => e.MetaKeywords)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.MetaDescriptions)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.Tags)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.Language)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.AnhSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
