using SAMDesign.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMDesign.DataAccess
{
    public class Context : DbContext
    {
        public Context()
        {
            
            Database.SetInitializer<Context>(null);
        }
        //set default schema based on the database
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SAMDESIGN");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ProductsDA> Products { get; set; }
        public DbSet<EventLogDA> EventLogs { get; set; }
    }
}
