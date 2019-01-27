namespace SzakdolgozatAppMvc
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=PlayerModel")
        {
        }

        public virtual DbSet<T_PLAYER> T_PLAYER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_PLAYER>()
                .Property(e => e.C_NAME)
                .IsFixedLength();
        }
    }
}
