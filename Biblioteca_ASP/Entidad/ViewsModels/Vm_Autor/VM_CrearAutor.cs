using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.ViewsModels.Vm_Autor
{
    public class VM_CrearAutor
    {
        [Required]
        public String Nombre { get; set; }
        [Required]
        public String Nacionalidad { get; set; }
    }
}
