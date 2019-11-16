namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bed")]
    public partial class Bed
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; } 

        [Required]
        public int IdRoom { get; set; }

       
        public int? IdBooking { get; set; }
    }
}