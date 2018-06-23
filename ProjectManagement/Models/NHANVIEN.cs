namespace ProjectManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [Key]
        [StringLength(50)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string HoNV { get; set; }

        [StringLength(150)]
        public string TenNV { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        public int? GioiTinh { get; set; }

        [StringLength(50)]
        public string DienThoai { get; set; }

        [Required]
        [StringLength(50)]
        public string MaPB { get; set; }

        public virtual PHONGBAN PHONGBAN { get; set; }
    }
}
