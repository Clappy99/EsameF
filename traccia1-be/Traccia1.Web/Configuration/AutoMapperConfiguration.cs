using AutoMapper;
using Traccia1.DAL.Entities;
using Traccia1.BLL.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Traccia1.Web.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Book,BookModel>().ReverseMap();
        }
    }
}
