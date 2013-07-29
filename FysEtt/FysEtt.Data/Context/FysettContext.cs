using FysEtt.Data.Configurations;
using FysEtt.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysEtt.Data.Context
{
    public class FysettContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public FysettContext()
            :base(nameOrConnectionString: "DefaultConnectionString")
        {
            Database.SetInitializer<FysettContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new NewsConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
