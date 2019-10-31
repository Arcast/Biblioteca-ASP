using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Entidad;

namespace Datos
{
    public class BibliotecaDbContext : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'BibliotecaDbContext' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'Datos.BibliotecaDbContext' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'BibliotecaDbContext'  en el archivo de configuración de la aplicación.
        public BibliotecaDbContext()
            : base("name=BibliotecaDbContext")
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<LibAut> LibAuts { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            new Autor.map(ref modelBuilder);
            new Estudiante.map(ref modelBuilder);
            new LibAut.map(ref modelBuilder);
            new Libro.map(ref modelBuilder);
            new Prestamo.map(ref modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}