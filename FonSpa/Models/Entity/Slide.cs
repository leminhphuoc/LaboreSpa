namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public long id { get; set; }

        [StringLength(250)]
        public string image { get; set; }

        public int? displayOrder { get; set; }

        [StringLength(250)]
        public string link { get; set; }

        [StringLength(250)]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createdDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? modifiedDate { get; set; }

        public bool? status { get; set; }
    }
}
