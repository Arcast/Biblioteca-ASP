using Entidad.FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    [Validator(typeof (AutorValidator))]
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        //[DisplayName("Nombre del Autor")]
        public String Nombre { get; set; }
        public String Nacionalidad { get; set; }
        public Boolean Estatus { get; set; } = true;
        public ICollection<LibAut> LibAut { get; set; }

        public class map
        {
            public map(ref DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Autor>().HasKey(x => x.IdAutor);

                modelBuilder.Entity<Autor>().Property(x => x.Nombre).IsRequired();
                modelBuilder.Entity<Autor>().Property(x => x.Nacionalidad).IsRequired();
                               
            }
        }
    }
}

