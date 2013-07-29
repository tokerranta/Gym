using FysEtt.Data.Context;
using FysEtt.Models.Entities;
using FysEtt.Models.Repositories;
using FysEtt.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysEtt.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(FysettContext context)
            : base(context)
        {
            
        }

        public User FindByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email.Equals(email));
        }

        public override void Add(User user)
        {
            user.Password = PasswordService.Crypt(user.Password); 
            base.Add(user);
        }
    }
}
