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
    public class DispersionController : ControllerBase
    {
        private readonly DispersionService _bookService;

        public DispersionController(DispersionService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<PU_Dispersion_FIC>> Get() =>
            _bookService.Get().Take(20).ToList();


        [HttpPost]
        public ActionResult<PU_Dispersion_FIC> Create(PU_Dispersion_FIC book)
        {
            _bookService.Create(book);

            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        }

        [HttpGet("Nit")]
        public ActionResult<List<PU_Dispersion_FIC>> GetNit(string nit)
        {
            var book = _bookService.Nit(nit);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpGet("Ticket")]
        public ActionResult<List<PU_Dispersion_FIC>> GetTicket(string ticket)
        {
            var book = _bookService.Ticket(ticket);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
    }
}
