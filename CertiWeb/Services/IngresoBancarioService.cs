using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using BooksApi.Models;

namespace CertiWeb.Services
{
    public class IngresoBancarioService
    {
        private readonly IMongoCollection<IngresoBanco> _books;

        public IngresoBancarioService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<IngresoBanco>(settings.CollectionName);
        }

        public List<IngresoBanco> Get() =>
            _books.Find(book => true).ToList();

        public IngresoBanco Get(string id) =>
            _books.Find<IngresoBanco>(book => book.Id == id).FirstOrDefault();

        public IngresoBanco Create(IngresoBanco book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, IngresoBanco bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(IngresoBanco bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);
    }
}
