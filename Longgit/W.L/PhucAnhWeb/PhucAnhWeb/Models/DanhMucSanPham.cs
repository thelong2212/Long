namespace PhucAnhWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucSanPham")]
    public partial class DanhMucSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucSanPham()
        {
            PhanLoaiSanPhams = new HashSet<PhanLoaiSanPham>();
        }

        public int DanhMucSanPhamID { get; set; }

        public int? DanhMucSanPhamPID { get; set; }

        [StringLength(100)]
        public string TenDanhMucSanPham { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public bool? Status { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        [Column("Laptop & Linh phụ kiện")]
        public bool? Laptop___Linh_phụ_kiện { get; set; }

        [Column("Điện thoại, Tavlet & Phụ kiện")]
        public bool? Điện_thoại__Tavlet___Phụ_kiện { get; set; }

        [Column("Máy tính đồng bộ")]
        public bool? Máy_tính_đồng_bộ { get; set; }

        [Column("Server & Workstation")]
        public bool? Server___Workstation { get; set; }

        [Column("PC chơi Game, Gaming Gear")]
        public bool? PC_chơi_Game__Gaming_Gear { get; set; }

        [Column("Laptop theo khoảng tiền")]
        public bool? Laptop_theo_khoảng_tiền { get; set; }

        [Column("Linh kiện máy tính")]
        public bool? Linh_kiện_máy_tính { get; set; }

        [Column("Phụ kiện máy tính & nghe nhìn")]
        public bool? Phụ_kiện_máy_tính___nghe_nhìn { get; set; }

        [Column("Màn hình máy tính")]
        public bool? Màn_hình_máy_tính { get; set; }

        [Column("Thiết bị văn phòng")]
        public bool? Thiết_bị_văn_phòng { get; set; }

        public virtual LoaiDanhMucSanPham LoaiDanhMucSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanLoaiSanPham> PhanLoaiSanPhams { get; set; }
    }
}
