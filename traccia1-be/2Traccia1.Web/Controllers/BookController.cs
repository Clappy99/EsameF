using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Traccia1.BLL.Services.Interfaces;

namespace Traccia1.Web.Controllers
{
    [Route("/api")]
    [EnableCors("cors")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService,IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
