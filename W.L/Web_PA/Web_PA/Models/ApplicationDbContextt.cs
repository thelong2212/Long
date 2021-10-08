using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Web_PA.Models
{
    public partial class ApplicationDbContextt : DbContext
    {
        public ApplicationDbContextt()
            : base("name=ApplicationDbContextt5")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
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
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<SanPhamDonHang> SanPhamDonHangs { get; set; }
        public virtual DbSet<sysdiagram> Sysdiagrams { get; set; }
        public virtual DbSet<ThongSoSanPham> ThongSoSanPhams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUserRoles)
                .WithRequired(e => e.AspNetRole)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<UserGroup>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.UserGroup)
                .HasForeignKey(e => e.GroupID);
        }
    }
}
