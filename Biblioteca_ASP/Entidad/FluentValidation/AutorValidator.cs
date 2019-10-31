using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.FluentValidation
{
    public class AutorValidator : AbstractValidator<Autor>
    {
        public AutorValidator()
        {
            RuleFor(Autor => Autor.Nombre).NotEmpty().Length(0, 250).WithMessage("El Nombre del autor es requerido");
            RuleFor(Autor => Autor.Nacionalidad).NotEmpty().Length(0, 250).WithMessage("La Nacionalidad del autor es requerida");
            //RuleFor(Autor => Autor.Estatus).NotEmpty().WithMessage("Error al guardar el Estado del autor");                          
        }
    }
}
 