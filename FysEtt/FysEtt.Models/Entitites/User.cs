﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysEtt.Models.Entities
{
    public class User : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Email{ get; set; }
        public virtual string Password { get; set; }
    }
}
