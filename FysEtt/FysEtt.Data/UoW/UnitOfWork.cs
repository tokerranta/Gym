using FysEtt.Data.Context;
using FysEtt.Data.Repositories;
using FysEtt.Models.Entities;
using FysEtt.Models.Entitites;
using FysEtt.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysEtt.Data.UoW
{
    public class UnitOfWork : IDisposable
    {

        private readonly FysettContext _context;

        public UnitOfWork()
        {
            _context = new FysettContext();
        }

        private IUserRepository userRepository;
        public IUserRepository UserRepository 
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_context);

                return userRepository;
            }
        }

        private GenericRepository<NewsItem> newsRepository;
        public GenericRepository<NewsItem> NewsRepository 
        { 
            get 
            {
                if (newsRepository == null)
                    newsRepository = new GenericRepository<NewsItem>(_context);

                return newsRepository;
            } 
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
