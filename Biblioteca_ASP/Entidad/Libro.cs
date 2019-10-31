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
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }
        public String Titulo { get; set; }
        public String Editorial { get; set; }
        public String Area { get; set; }

        public ICollection<LibAut> libAuts { get; set; }
        public ICollection<Prestamo> Prestamos { get; set; }
        public class map
        {
            public map(ref DbModelBuilder modelBuilder)
            {


                modelBuilder.Entity<Libro>().HasKey(x => x.IdLibro);

                modelBuilder.Entity<Libro>().Property(x => x.Titulo).IsRequired();
                modelBuilder.Entity<Libro>().Property(x => x.Editorial).IsRequired();

                modelBuilder.Entity<Libro>().Property(x => x.Titulo).HasMaxLength(500);
                modelBuilder.Entity<Libro>().Property(x => x.Editorial).HasMaxLength(500);
                modelBuilder.Entity<Libro>().Property(x => x.Area).HasMaxLength(500);

            }
        }
    }
}
