namespace Web_PA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanLoaiTheoHangSp")]
    public partial class PhanLoaiTheoHangSp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDHang { get; set; }

        public int? PhanLoaiSanPhamID { get; set; }

        [StringLength(50)]
        public string TenSanPhamTheoHang { get; set; }

        public virtual PhanLoaiSanPham PhanLoaiSanPham { get; set; }
    }
}
