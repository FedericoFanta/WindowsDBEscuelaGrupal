namespace WindowsDBEscuela.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionFinal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Detalle",
                c => new
                    {
                        DetalleId = c.Int(nullable: false, identity: true),
                        PlantillaId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        Planilla_PlanillaId = c.Int(),
                    })
                .PrimaryKey(t => t.DetalleId)
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: true)
                .ForeignKey("dbo.Planilla", t => t.Planilla_PlanillaId)
                .Index(t => t.EstadoId)
                .Index(t => t.Planilla_PlanillaId);
            
            CreateTable(
                "dbo.Evaluacion",
                c => new
                    {
                        EvaluacionId = c.Int(nullable: false, identity: true),
                        TipoId = c.Int(nullable: false),
                        EstudianteId = c.Int(nullable: false),
                        DetalleId = c.Int(nullable: false),
                        Nota = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.EvaluacionId)
                .ForeignKey("dbo.Detalle", t => t.DetalleId, cascadeDelete: true)
                .ForeignKey("dbo.Estudiante", t => t.EstudianteId, cascadeDelete: true)
                .ForeignKey("dbo.Tipo", t => t.TipoId, cascadeDelete: true)
                .Index(t => t.TipoId)
                .Index(t => t.EstudianteId)
                .Index(t => t.DetalleId);
            
            CreateTable(
                "dbo.Estudiante",
                c => new
                    {
                        EstudianteId = c.Int(nullable: false, identity: true),
                        LocalidadId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                        Telefono = c.String(nullable: false, maxLength: 50, unicode: false),
                        Calle = c.String(nullable: false, maxLength: 50, unicode: false),
                        Numero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstudianteId)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId, cascadeDelete: true)
                .Index(t => t.LocalidadId);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        LocalidadId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.LocalidadId);
            
            CreateTable(
                "dbo.Profesor",
                c => new
                    {
                        ProfesorId = c.Int(nullable: false, identity: true),
                        LocalidadId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ProfesorId)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId, cascadeDelete: true)
                .Index(t => t.LocalidadId);
            
            CreateTable(
                "dbo.Planilla",
                c => new
                    {
                        PlanillaId = c.Int(nullable: false, identity: true),
                        CarreraId = c.Int(nullable: false),
                        MateriaId = c.Int(nullable: false),
                        ProfesorId = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PlanillaId)
                .ForeignKey("dbo.Carrera", t => t.CarreraId, cascadeDelete: true)
                .ForeignKey("dbo.Curso", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.Materia", t => t.MateriaId, cascadeDelete: true)
                .ForeignKey("dbo.Profesor", t => t.ProfesorId, cascadeDelete: true)
                .Index(t => t.CarreraId)
                .Index(t => t.MateriaId)
                .Index(t => t.ProfesorId)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Carrera",
                c => new
                    {
                        CarreraId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CarreraId);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        CarreraId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.PlanId)
                .ForeignKey("dbo.Carrera", t => t.CarreraId, cascadeDelete: true)
                .Index(t => t.CarreraId);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CursoId);
            
            CreateTable(
                "dbo.Materia",
                c => new
                    {
                        MateriaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MateriaId);
            
            CreateTable(
                "dbo.Tipo",
                c => new
                    {
                        TipoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.TipoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluacion", "TipoId", "dbo.Tipo");
            DropForeignKey("dbo.Planilla", "ProfesorId", "dbo.Profesor");
            DropForeignKey("dbo.Planilla", "MateriaId", "dbo.Materia");
            DropForeignKey("dbo.Detalle", "Planilla_PlanillaId", "dbo.Planilla");
            DropForeignKey("dbo.Planilla", "CursoId", "dbo.Curso");
            DropForeignKey("dbo.Planilla", "CarreraId", "dbo.Carrera");
            DropForeignKey("dbo.Plan", "CarreraId", "dbo.Carrera");
            DropForeignKey("dbo.Profesor", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Estudiante", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Evaluacion", "EstudianteId", "dbo.Estudiante");
            DropForeignKey("dbo.Evaluacion", "DetalleId", "dbo.Detalle");
            DropForeignKey("dbo.Detalle", "EstadoId", "dbo.Estado");
            DropIndex("dbo.Plan", new[] { "CarreraId" });
            DropIndex("dbo.Planilla", new[] { "CursoId" });
            DropIndex("dbo.Planilla", new[] { "ProfesorId" });
            DropIndex("dbo.Planilla", new[] { "MateriaId" });
            DropIndex("dbo.Planilla", new[] { "CarreraId" });
            DropIndex("dbo.Profesor", new[] { "LocalidadId" });
            DropIndex("dbo.Estudiante", new[] { "LocalidadId" });
            DropIndex("dbo.Evaluacion", new[] { "DetalleId" });
            DropIndex("dbo.Evaluacion", new[] { "EstudianteId" });
            DropIndex("dbo.Evaluacion", new[] { "TipoId" });
            DropIndex("dbo.Detalle", new[] { "Planilla_PlanillaId" });
            DropIndex("dbo.Detalle", new[] { "EstadoId" });
            DropTable("dbo.Tipo");
            DropTable("dbo.Materia");
            DropTable("dbo.Curso");
            DropTable("dbo.Plan");
            DropTable("dbo.Carrera");
            DropTable("dbo.Planilla");
            DropTable("dbo.Profesor");
            DropTable("dbo.Localidad");
            DropTable("dbo.Estudiante");
            DropTable("dbo.Evaluacion");
            DropTable("dbo.Detalle");
        }
    }
}
