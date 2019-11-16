namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public long Id { get; set; }

        public DateTime ArrivalTime { get; set; }

        [Required]
        public long IdCustomer { get; set; }

        [Required]
        public long IdServices { get; set; }
    }
}