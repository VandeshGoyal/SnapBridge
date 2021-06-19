using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SnapBridge.Models;

namespace SnapBridge.Context
{
    public class SqlDbContext : DbContext
    {
        /*
         * The connection string given in web.config will be passed in constructor
         */
        public SqlDbContext() : base("SqlDbContextConnString")
        {
        }

        public DbSet<Inventory> Inventories { get; set; }

        //To avoide Pluralized name for tabel created by builder by default
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}