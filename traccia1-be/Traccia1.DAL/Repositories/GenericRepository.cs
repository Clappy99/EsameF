using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traccia1.DAL.Repositories.Interfaces;

namespace Traccia1.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private LibraryDbContext _context;
        private DbSet<T> table;

        public GenericRepository(LibraryDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public void Delete(int id)
        {
            T? existing = table.Find(id);
            if (existing != null)
            {
                table.Remove(existing);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T? GetById(int id)
        {
            return table.Find(id);
        }

        public void Insert(T? obj)
        {
            if(obj == null) throw new ArgumentNullException(nameof(obj));
            table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T? obj)
        {
            if(obj == null) throw new ArgumentNullException(nameof(obj));
            _context.Entry(obj).State = EntityState.Modified;
            _context.Update(obj);
        }
    }
}
