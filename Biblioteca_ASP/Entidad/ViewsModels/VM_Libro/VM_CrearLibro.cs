using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.ViewsModels
{
       public class VM_CrearLibro {
            public String Titulo { get; set; }
            public String Editorial { get; set; }
            public String Area { get; set; }
            public IEnumerable<int> IdAutor { get; set; }
        }
    
}
