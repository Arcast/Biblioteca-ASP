using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Entidad.FluentValidation
{
    public class PrestamoValidator : AbstractValidator<Prestamo>
    {
        public PrestamoValidator()
        {
            RuleFor(Prestamo => Prestamo.Devuelto).NotNull().WithMessage("No se logro determinar el estado del prestamo");
            RuleFor(Prestamo => Prestamo.FechaPrestamo).NotEmpty().GreaterThan(DateTime.Now).WithMessage("La fecha especificada no es válida");
            RuleFor(Prestamo => Prestamo.FechaDevolucion).Null().GreaterThan(x => x.FechaPrestamo).WithMessage("La fecha de Entrega debe ser mayor a la fecha del Prestamo");
            RuleFor(Prestamo => Prestamo.IdLibro).NotNull().WithMessage("Seleccione el libro que desea prestar");
            RuleFor(Prestamo => Prestamo.IdLector).NotNull().WithMessage("Seleccione el lector del libro");
        }
    }
}
