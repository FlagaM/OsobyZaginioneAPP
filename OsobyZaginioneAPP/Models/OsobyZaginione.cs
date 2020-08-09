using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OsobyZaginioneAPP.Models
{
    public class OsobaZaginiona
    {
        // model do bazy danych
            public int ID { get; set; }
            public string Opis { get; set; }
            public string Data { get; set; }
            public string Plec { get; set; }
            public string Zdjęcie { get; set; }
    
    }
        
        public class OsobaZaginionaDBContext : DbContext
    {
        public DbSet<OsobaZaginiona> OsobyZaginione { get; set; }
    }

}

