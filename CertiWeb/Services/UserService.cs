using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using BooksApi.Models;

namespace CertiWeb.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _books;

        public UserService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<User>("User");
        }

        public List<User> Get() =>
            _books.Find(book => true).ToList();

        public User Get(string id) =>
            _books.Find<User>(book => book.Id == id).FirstOrDefault();

        public List<User> Nit(string nit) =>
            _books.Find<User>(book => book.Nit == nit).ToList();

        public User NameUser(string username) =>
            _books.Find<User>(book => book.NameUser == username).First();

        public User Create(User book)
        {
            _books.InsertOne(book);
            return book;
        }
    }
}
