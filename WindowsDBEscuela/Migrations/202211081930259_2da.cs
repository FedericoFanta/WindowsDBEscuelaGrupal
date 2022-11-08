namespace WindowsDBEscuela.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2da : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.EstadoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Estado");
        }
    }
}
