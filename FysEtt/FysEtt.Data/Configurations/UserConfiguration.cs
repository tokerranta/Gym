using FysEtt.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysEtt.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(k => k.Id).ToTable("Users", "member");

            Property(p => p.Password).IsRequired();

            Property(p => p.Email).IsRequired();
        }
    }
}
