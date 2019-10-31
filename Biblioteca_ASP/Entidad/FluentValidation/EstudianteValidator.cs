using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Entidad.FluentValidation
{
    public class EstudianteValidator : AbstractValidator<Estudiante>
    {
        public EstudianteValidator()
        {
            RuleFor(Estudiante => Estudiante.CI).NotNull().WithMessage("Ingrese el CI del Estudiante").MaximumLength(250);
            RuleFor(Estudiante => Estudiante.Nombre).NotNull().WithMessage("Ingrese el nombre del Estudiante").MaximumLength(250);
            RuleFor(Estudiante => Estudiante.Direccion).NotNull().WithMessage("Ingrese la dirección del Estudiante").MaximumLength(2500);
            RuleFor(Estudiante => Estudiante.Carrera).NotNull().WithMessage("Ingrese la carrera del Estudiante").MaximumLength(250);
            RuleFor(Estudiante => Estudiante.Edad).GreaterThan(0).LessThan(120).WithMessage("Ingrese una edad Válida").NotNull();

        }
    }
}
