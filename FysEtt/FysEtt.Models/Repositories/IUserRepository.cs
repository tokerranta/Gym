﻿using FysEtt.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysEtt.Models.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByEmail(string email);
    }
}
