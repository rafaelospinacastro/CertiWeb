using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using BooksApi.Models;

namespace CertiWeb.Services
{
    public class DispersionService
    {
        private readonly IMongoCollection<PU_Dispersion_FIC> _books;

        public DispersionService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<PU_Dispersion_FIC>("Dispersion");
        }

        public List<PU_Dispersion_FIC> Get() =>
            _books.Find(book => true).ToList();

        public PU_Dispersion_FIC Get(string id) =>
            _books.Find<PU_Dispersion_FIC>(book => book.Id == id).FirstOrDefault();

        public List<PU_Dispersion_FIC> Nit(string nit) =>
            _books.Find<PU_Dispersion_FIC>(book => book.Nit == nit).ToList();

        public List<PU_Dispersion_FIC> Ticket(string ticket) =>
            _books.Find<PU_Dispersion_FIC>(book => book.Referencia == ticket).ToList();

        public PU_Dispersion_FIC Create(PU_Dispersion_FIC book)
        {
            _books.InsertOne(book);
            return book;
        }
    }
}
