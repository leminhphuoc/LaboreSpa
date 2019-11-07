namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public long Id { get; set; }

        public long? IdCustomer { get; set; }

        public long? IdServices { get; set; }

        public long? IdProduct { get; set; }
    }
}
