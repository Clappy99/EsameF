using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traccia1.BLL.Models;

namespace Traccia1.BLL.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookModel> GetAll();
        BookModel? GetById(int id);
        void Insert(BookModel model);
        void Update(BookModel model);
        void Delete(int id);

    }
}
