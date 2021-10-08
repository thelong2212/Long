namespace PhucAnh_done.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImageSanPham")]
    public partial class ImageSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ImageSPID { get; set; }

        public int? SanPhamID { get; set; }

        [StringLength(250)]
        public string Ảnh { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
