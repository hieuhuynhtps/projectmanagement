namespace ProjectManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DUAN")]
    public partial class DUAN
    {
        [Key]
        [StringLength(50)]
        public string MaDA { get; set; }

        public string TenDA { get; set; }

        public string DiaDiem { get; set; }

        [StringLength(50)]
        public string MaPB { get; set; }

        public virtual PHONGBAN PHONGBAN { get; set; }
    }
}
