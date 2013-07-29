using FysEtt.Models.Entitites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysEtt.Data.Configurations
{
    public class NewsConfiguration : EntityTypeConfiguration<NewsItem>
    {
        public NewsConfiguration()
        {
            HasKey(k => k.Id).ToTable("News", "webcontent");
            Property(p => p.Text).IsRequired();
            Property(p => p.Title).HasMaxLength(128).IsRequired();
            Property(p => p.Created).HasColumnType("datetime").IsRequired();
            Property(p => p.CreatedBy).IsOptional();

        }
    }
}
