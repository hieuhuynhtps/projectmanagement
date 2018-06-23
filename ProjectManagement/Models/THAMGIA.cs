namespace ProjectManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THAMGIA")]
    public partial class THAMGIA
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string MaDA { get; set; }

        public double? SoGio { get; set; }

        public virtual DUAN DUAN { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
