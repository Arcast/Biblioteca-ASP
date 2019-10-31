using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteca_ASP.Models
{
    public class Biblioteca_ASPContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Biblioteca_ASPContext() : base("name=Biblioteca_ASPContext")
        {
        }

        public System.Data.Entity.DbSet<Entidad.LibAut> LibAuts { get; set; }

        public System.Data.Entity.DbSet<Entidad.Libro> Libroes { get; set; }
    }
}
