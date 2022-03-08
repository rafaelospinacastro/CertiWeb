using BooksApi.Models;
using CertiWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _bookService;

        public UserController(UserService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _bookService.Get().Take(20).ToList();


        [HttpPost]
        public ActionResult<PU_Dispersion_FIC> Create(User book)
        {
            _bookService.Create(book);

            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        }

        [HttpGet("ObtenerUsuario")]
        public ActionResult<User> GetUser(string username)
        {
            var book = _bookService.NameUser(username);

            if (book == null)
            {
                return NotFound();
            }
            return book;
        }
        
    }
}
