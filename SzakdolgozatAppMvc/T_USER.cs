namespace SzakdolgozatAppMvc
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

        public int? C_ISZ { get; set; }

        [StringLength(100)]
        public string C_ADDRESS { get; set; }

        [StringLength(20)]
        public string C_USERNAME { get; set; }

        [StringLength(15)]
        public string C_PASSWORD { get; set; }

        [StringLength(100)]
        public string C_EMAIL { get; set; }
    }
}
