using Datos;
using Datos.Datos.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad.ViewsModels.VM_Estudiantes;
using Entidad;

namespace Negocio
{
   public class N_Estudiante
    {
        public static List<Entidad.Estudiante> MostrarEstudiantes()
        {
            using (var unit = new UnitOfWork(new BibliotecaDbContext()))
            {
               return unit.Estudiante.ListAll().ToList();
            }
        }
        public static void GuardarEstudiante(VM_GuardarEstudiante vm)
        {
            using (var unit = new UnitOfWork(new BibliotecaDbContext()))
            {
                var estud = new Estudiante();
                estud.CI = vm.CI;
                estud.Nombre = vm.Nombre;
                estud.Direccion = vm.Direccion;
                estud.Carrera = vm.Carrera;
                estud.Edad = vm.Edad;

                unit.Estudiante.AddOrUpdate(estud);
                unit.Complete();
            }
        }

        public static Estudiante BuscarEstudiante(int id)
        {
            using (var unit = new UnitOfWork(new BibliotecaDbContext()))
            {
                var estud = unit.Estudiante.GetByID(id);
                return estud;
            }
        }

        public static void EditarEstudiante(Estudiante estudiante)
        {
            using (var unit = new UnitOfWork(new BibliotecaDbContext()))
            {
                unit.Estudiante.AddOrUpdate(estudiante);
                unit.Complete();
            }
        }

    }
}
