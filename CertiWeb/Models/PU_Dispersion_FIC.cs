using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Models
{
    public class PU_Dispersion_FIC
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nit { get; set; }
        public string Periodo { get; set; }
        public string FechaPago { get; set; }
        
        public string NumObra { get; set; }
        
        public string NombreObra { get; set; }
        public int Trabajadores { get; set; }
       
        public string Referencia { get; set; }
        
        public decimal Valor { get; set; }
        
        public int Posicion { get; set; }
        public int Estado { get; set; }
        public string Usuario { get; set; }
        public string Fecha { get; set; }
        public string Razon { get; set; }        
    }
    public class DispersionFile
    {
        public string Nit { get; set; }
        public string NumObra { get; set; }
        public string NombreObra { get; set; }
        public int Trabajadores { get; set; }
        public string Periodo { get; set; }
        public decimal Valor { get; set; }
        public string Referencia { get; set; }
        public string FechaPago { get; set; }
    }

    public class FicFile
    {

        public string Nit { get; set; }
        public string NumObra { get; set; }
        public string NombreObra { get; set; }
        public int Trabajadores { get; set; }
        public string Periodo { get; set; }
        public decimal Valor { get; set; }
        public string Referencia { get; set; }
        public string FechaPago { get; set; }
    }


}
