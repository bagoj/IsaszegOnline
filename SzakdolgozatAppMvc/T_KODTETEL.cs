namespace SzakdolgozatAppMvc
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_KODTETEL
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int C_LID { get; set; }

        [StringLength(10)]
        public string C_KODTETELNAME { get; set; }

        [StringLength(100)]
        public string C_DESCRIPTION { get; set; }
    }
}
