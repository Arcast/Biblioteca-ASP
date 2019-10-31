using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Entidad.FluentValidation
{
    public class LibroValidator: AbstractValidator<Libro>
    {
        public LibroValidator()
        {
            RuleFor(Libro => Libro.Titulo).NotNull().MaximumLength(250).WithMessage("Ingrese el Titulo del libro");
            RuleFor(Libro => Libro.Editorial).NotNull().MaximumLength(250).WithMessage("Ingrese el editorial del lobro");
            RuleFor(Libro => Libro.Area).NotNull().MaximumLength(250).WithMessage("Ingrese el área a la que pertenece el libro");

        }
    }
}
