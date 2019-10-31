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
    public class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }
        public int IdLector { get; set; }
        public int IdLibro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public Boolean Devuelto { get; set; }

        public Libro libro{ get; set; }
        public Estudiante Estudiante { get; set; }
        public class map
        {
            public map(ref DbModelBuilder modelBuilder)
            {

                modelBuilder.Entity<Prestamo>().HasKey(x => x.IdPrestamo);

                modelBuilder.Entity<Prestamo>().Property(x => x.IdLector).IsRequired();
                modelBuilder.Entity<Prestamo>().Property(x => x.IdLibro).IsRequired();
                modelBuilder.Entity<Prestamo>().Property(x => x.FechaPrestamo).IsRequired();
                modelBuilder.Entity<Prestamo>().Property(x => x.FechaDevolucion).IsRequired();
                modelBuilder.Entity<Prestamo>().Property(x => x.Devuelto).IsRequired();

            }
        }
    }
}
