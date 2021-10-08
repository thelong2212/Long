namespace Web_PA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanLoaiSanPham")]
    public partial class PhanLoaiSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhanLoaiSanPham()
        {
            PhanLoaiTheoHangSps = new HashSet<PhanLoaiTheoHangSp>();
            SanPhams = new HashSet<SanPham>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PhanLoaiSanPhamID { get; set; }

        [StringLength(50)]
        public string TenPhanLoaiSanPham { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public int? DanhMucSanPhamID { get; set; }

        public virtual DanhMucSanPham DanhMucSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanLoaiTheoHangSp> PhanLoaiTheoHangSps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
