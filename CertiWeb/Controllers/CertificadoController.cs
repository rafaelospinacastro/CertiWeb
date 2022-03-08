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
    public class CertificadoController : ControllerBase
    {
        private readonly CertificadoService _bookService;

        public CertificadoController(CertificadoService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Certificado>> Get() =>
            _bookService.Get().Take(20).ToList();


        [HttpPost]
        public ActionResult<PU_Dispersion_FIC> Create(Certificado book)
        {
            _bookService.Create(book);

            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        }
               

        [HttpGet("NumCert")]
        public ActionResult<Certificado> GetTicket(string ticket)
        {
            var book = _bookService.NumCert(ticket);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
    }
}
