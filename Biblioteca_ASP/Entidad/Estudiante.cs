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
    public class Estudiante
    {
        [Key]
        public int IdLector { get; set; }
        public String CI { get; set; }
        public String Nombre { get; set; }
        public String Direccion { get; set; }
        public String Carrera { get; set; }
        public int Edad { get; set; }

        public ICollection<Prestamo> Prestamo { get; set; }

        public class map
        {
            public map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Estudiante>().HasKey(x => x.IdLector);

                modelBuilder.Entity<Estudiante>().Property(x => x.Nombre).IsRequired();
                modelBuilder.Entity<Estudiante>().Property(x => x.Direccion).IsRequired();
                modelBuilder.Entity<Estudiante>().Property(x => x.Carrera).IsRequired();
                modelBuilder.Entity<Estudiante>().Property(x => x.Edad).IsRequired();

            }
        }
    }
}
