namespace SzakdolgozatAppMvc.Datamodel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel1")
        {
        }

        public virtual DbSet<T_USER> T_USER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_USER>()
                .Property(e => e.C_USERNAME)
                .IsFixedLength();
        }
    }
}
