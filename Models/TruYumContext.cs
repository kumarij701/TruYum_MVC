using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TruYum.Models
{
    public class TruYumContext : DbContext
    {
        public TruYumContext() :base("Data Source=BYODHSQ5DX2\\MSSQLSERVERNEW;Initial Catalog=dbs;Integrated Security=true")
        { }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
