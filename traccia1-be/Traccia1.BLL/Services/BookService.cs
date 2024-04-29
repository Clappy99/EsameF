using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traccia1.BLL.Models;
using Traccia1.BLL.Services.Interfaces;
using Traccia1.DAL.Entities;
using Traccia1.DAL.Repositories.Interfaces;

namespace Traccia1.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public BookService(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
            _bookRepository.Save();
        }

        public IEnumerable<BookModel> GetAll()
        {
            return _mapper.Map<IEnumerable<BookModel>>(_bookRepository.GetAll());
        }

        public BookModel? GetById(int id)
        {
            return _mapper.Map<BookModel>(_bookRepository.GetById(id));
        }

        public void Insert(BookModel model)
        {
            model.Created = DateTime.Now;
            model.Updated = DateTime.Now;
            _bookRepository.Insert(_mapper.Map<Book>(model));
            _bookRepository.Save();
        }

        public void Update(BookModel model)
        {
            model.Updated = DateTime.Now;
            _bookRepository.Update(_mapper.Map<Book>(model));
            _bookRepository.Save();
        }
    }
}
