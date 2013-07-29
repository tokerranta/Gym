using FysEtt.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysEtt.Models.Entitites
{
    public class NewsItem : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string CreatedBy { get; set; }
    }
}
