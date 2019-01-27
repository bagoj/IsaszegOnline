namespace SzakdolgozatAppMvc.Datamodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_USER
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string C_NAME { get; set; }

        [StringLength(50)]
        public string C_ADRESS { get; set; }

        [StringLength(50)]
        public string C_CITY { get; set; }

        [StringLength(50)]
        public string C_PASSWORD { get; set; }

        [StringLength(10)]
        public string C_USERNAME { get; set; }
    }
}
