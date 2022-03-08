using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Models
{
    public class IngresoBanco
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public decimal Fecha { get; set; }

        public decimal Ingreso { get; set; }

        public decimal Planillas { get; set; }

        public decimal Empleados { get; set; }
    }
}
