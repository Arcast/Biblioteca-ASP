namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        IdAutor = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Nacionalidad = c.String(nullable: false),
                        Estatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdAutor);
            
            CreateTable(
                "dbo.LibAut",
                c => new
                    {
                        IdLibAut = c.Int(nullable: false, identity: true),
                        IdLibro = c.Int(nullable: false),
                        IdAutor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdLibAut)
                .ForeignKey("dbo.Autor", t => t.IdAutor, cascadeDelete: true)
                .ForeignKey("dbo.Libro", t => t.IdLibro, cascadeDelete: true)
                .Index(t => t.IdLibro)
                .Index(t => t.IdAutor);
            
            CreateTable(
                "dbo.Libro",
                c => new
                    {
                        IdLibro = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 500),
                        Editorial = c.String(nullable: false, maxLength: 500),
                        Area = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.IdLibro);
            
            CreateTable(
                "dbo.Prestamo",
                c => new
                    {
                        IdPrestamo = c.Int(nullable: false, identity: true),
                        IdLector = c.Int(nullable: false),
                        IdLibro = c.Int(nullable: false),
                        FechaPrestamo = c.DateTime(nullable: false),
                        FechaDevolucion = c.DateTime(nullable: false),
                        Devuelto = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdPrestamo)
                .ForeignKey("dbo.Estudiante", t => t.IdLector, cascadeDelete: true)
                .ForeignKey("dbo.Libro", t => t.IdLibro, cascadeDelete: true)
                .Index(t => t.IdLector)
                .Index(t => t.IdLibro);
            
            CreateTable(
                "dbo.Estudiante",
                c => new
                    {
                        IdLector = c.Int(nullable: false, identity: true),
                        CI = c.String(),
                        Nombre = c.String(nullable: false),
                        Direccion = c.String(nullable: false),
                        Carrera = c.String(nullable: false),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdLector);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prestamo", "IdLibro", "dbo.Libro");
            DropForeignKey("dbo.Prestamo", "IdLector", "dbo.Estudiante");
            DropForeignKey("dbo.LibAut", "IdLibro", "dbo.Libro");
            DropForeignKey("dbo.LibAut", "IdAutor", "dbo.Autor");
            DropIndex("dbo.Prestamo", new[] { "IdLibro" });
            DropIndex("dbo.Prestamo", new[] { "IdLector" });
            DropIndex("dbo.LibAut", new[] { "IdAutor" });
            DropIndex("dbo.LibAut", new[] { "IdLibro" });
            DropTable("dbo.Estudiante");
            DropTable("dbo.Prestamo");
            DropTable("dbo.Libro");
            DropTable("dbo.LibAut");
            DropTable("dbo.Autor");
        }
    }
}
