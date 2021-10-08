namespace PhucAnhWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTSanPham")]
    public partial class CTSanPham
    {
        public int CTSanPhamID { get; set; }

        public int? SanPhamID { get; set; }

        [Column(TypeName = "ntext")]
        public string ChiTiet { get; set; }

        [Column(TypeName = "ntext")]
        public string ƯuDai { get; set; }

        public int? BaoHanh { get; set; }

        [Column(TypeName = "ntext")]
        public string ChiTietSP { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
