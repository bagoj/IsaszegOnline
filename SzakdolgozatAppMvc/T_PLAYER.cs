namespace SzakdolgozatAppMvc
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_PLAYER
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(100)]
        public string C_NAME { get; set; }

        public int C_POSZTID { get; set; }

        public int C_CSAPATID { get; set; }

        public int? C_AGE { get; set; }

        public int? C_BORNYEAR { get; set; }
    }
}
