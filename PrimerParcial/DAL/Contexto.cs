using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }

    public Contexto(DbContext0ptions<Contexto> options) : base(options) { }
    }
}
