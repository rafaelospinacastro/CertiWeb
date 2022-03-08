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
    public class IngresoBancarioController : ControllerBase
    {
        private readonly IngresoBancarioService _bookService;

        public IngresoBancarioController(IngresoBancarioService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<IngresoBanco>> Get() =>
            _bookService.Get().Take(20).ToList();
    }
}
