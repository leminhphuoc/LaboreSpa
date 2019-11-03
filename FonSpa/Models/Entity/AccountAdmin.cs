namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountAdmin")]
    public partial class AccountAdmin
    {
        public long id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage ="Vui lòng điền UserName !")]
        public string userName { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng điền Password !")]
        public string passWord { get; set; }

        public bool? type { get; set; }

        public bool? STATUS { get; set; }
    }
}
