namespace SzakdolgozatAppMvc
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IsaszegDB : DbContext
    {
        public IsaszegDB()
            : base("name=IsaszegDB")
        {
        }

        public virtual DbSet<T_KODTETEL> T_KODTETEL { get; set; }
        public virtual DbSet<T_PLAYER> T_PLAYER { get; set; }
        public virtual DbSet<T_USER> T_USER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_KODTETEL>()
                .Property(e => e.C_KODTETELNAME)
                .IsFixedLength();

            modelBuilder.Entity<T_KODTETEL>()
                .Property(e => e.C_DESCRIPTION)
                .IsFixedLength();

            modelBuilder.Entity<T_PLAYER>()
                .Property(e => e.C_NAME)
                .IsFixedLength();

            modelBuilder.Entity<T_USER>()
                .Property(e => e.C_NAME)
                .IsFixedLength();

            modelBuilder.Entity<T_USER>()
                .Property(e => e.C_ADDRESS)
                .IsFixedLength();

            modelBuilder.Entity<T_USER>()
                .Property(e => e.C_USERNAME)
                .IsFixedLength();

            modelBuilder.Entity<T_USER>()
                .Property(e => e.C_PASSWORD)
                .IsFixedLength();

            modelBuilder.Entity<T_USER>()
                .Property(e => e.C_EMAIL)
                .IsFixedLength();
        }
    }
}
