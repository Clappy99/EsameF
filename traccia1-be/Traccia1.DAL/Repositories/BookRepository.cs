using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traccia1.DAL.Entities;
using Traccia1.DAL.Repositories.Interfaces;

namespace Traccia1.DAL.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext _context) : base(_context)
        {
        }
    }
}
