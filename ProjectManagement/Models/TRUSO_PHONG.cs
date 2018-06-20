namespace ProjectManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRUSO_PHONG
    {
        [Key]
        [StringLength(50)]
        public string MaPB { get; set; }

        public string TruSo { get; set; }

        public virtual PHONGBAN PHONGBAN { get; set; }
    }
}
