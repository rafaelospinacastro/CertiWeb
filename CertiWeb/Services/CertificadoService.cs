using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using BooksApi.Models;

namespace CertiWeb.Services
{
    public class CertificadoService
    {
        private readonly IMongoCollection<Certificado> _books;

        public CertificadoService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Certificado>(settings.CollectionName);
        }

        public List<Certificado> Get() =>
            _books.Find(book => true).ToList();

        public Certificado Get(string id) =>
            _books.Find<Certificado>(book => book.NumCert == id).FirstOrDefault();

        public Certificado Create(Certificado book)
        {
            _books.InsertOne(book);
            return book;
        }
        public Certificado NumCert(string numcert) =>
            _books.Find<Certificado>(book => book.NumCert == numcert).FirstOrDefault();

        public void Update(string id, Certificado bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Certificado bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);
    }
}
