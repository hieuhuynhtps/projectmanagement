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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONGBAN()
        {
            DUANs = new HashSet<DUAN>();
            NHANVIENs = new HashSet<NHANVIEN>();
        }

        [Key]
        [StringLength(50)]
        public string MaPB { get; set; }

        [Required]
        [StringLength(255)]
        public string TenPB { get; set; }

        [StringLength(255)]
        public string TrPhong { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime? NgayNhanChuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DUAN> DUANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN> NHANVIENs { get; set; }

        public virtual TRUSO_PHONG TRUSO_PHONG { get; set; }
    }
}
