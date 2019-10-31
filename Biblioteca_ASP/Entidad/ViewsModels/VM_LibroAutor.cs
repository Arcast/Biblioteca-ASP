using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.ViewsModels
{
    public class VM_LibroAutor
    {
        public int IdLibro { get; set; }
        public String Titulo { get; set; }
        public String Editorial { get; set; }
        public String Area { get; set; }
        public IEnumerable<Autor> Autor { get; set; }
    }
}
