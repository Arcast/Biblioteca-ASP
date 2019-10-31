using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Entidad.FluentValidation
{
    public class LibAutValidator : AbstractValidator<LibAut>
    {
        public LibAutValidator()
        {
            RuleFor(LibAut => LibAut.IdLibro).NotNull().WithMessage("Seleccione el libro");
            RuleFor(LibAut => LibAut.IdAutor).NotNull().WithMessage("Seleccione el Autor");

        }
    }
}
