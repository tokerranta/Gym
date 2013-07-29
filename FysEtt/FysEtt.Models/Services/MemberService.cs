using FysEtt.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysEtt.Models.Services
{
    public class MemberService
    {
        private readonly IUserRepository _repo;

        public MemberService(IUserRepository repo)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo");
            }

            _repo = repo;
        }

        public bool CheckIfValidUser(string email, string password)
        {
            var user = _repo.FindByEmail(email);

            if (user != null && PasswordService.Crypt(password).Equals(user.Password))
            {
                return true;
            }

            return false;

        }

        public bool DoesUserExist(string email)
        {
            return _repo.FindByEmail(email) != null;
        }

    }
}
