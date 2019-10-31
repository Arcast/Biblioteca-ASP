using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class LibAut
    {
        [Key]
        public int IdLibAut { get; set; }
        public int IdLibro { get; set; }
        public int IdAutor { get; set; }

        public Libro Libro { get; set; }
        public Autor Autor { get; set; }
        public class map
        {
            public map(ref DbModelBuilder modelBuilder)
            {

                modelBuilder.Entity<LibAut>().HasKey(x => x.IdLibAut);

                modelBuilder.Entity<LibAut>().Property(x => x.IdLibro).IsRequired();
                modelBuilder.Entity<LibAut>().Property(x => x.IdAutor).IsRequired();

            }
        }
    }
}
