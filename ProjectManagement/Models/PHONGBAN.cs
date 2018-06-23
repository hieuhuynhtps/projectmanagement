namespace ProjectManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONGBAN")]
    public partial class PHONGBAN
    {
        [Key]
        [StringLength(50)]
        public string MaPB { get; set; }

        [Required]
        [StringLength(255)]
        public string TenPB { get; set; }

        [StringLength(255)]
        public string TrPhong { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NgayNhanChuc { get; set; }

        public virtual ICollection<DUAN> DUANs { get; set; }

        public virtual ICollection<NHANVIEN> NHANVIENs { get; set; }

        public virtual TRUSO_PHONG TRUSO_PHONG { get; set; }
    }
}
