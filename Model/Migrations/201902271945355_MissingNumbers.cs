namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MissingNumbers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Historial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        ListaOriginal = c.String(nullable: false, maxLength: 100),
                        ListaResultado = c.String(nullable: false, maxLength: 100),
                        listaPerdidos = c.String(nullable: false, maxLength: 100),
                        numerosIni = c.String(),
                        numerosSec = c.String(),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Documento = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Contrasena = c.String(nullable: false, maxLength: 50),
                        NombreUsuario = c.String(nullable: false, maxLength: 50),
                        TipoDocumentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoDocumento", t => t.TipoDocumentoId)
                .Index(t => t.TipoDocumentoId);
            
            CreateTable(
                "dbo.TipoDocumento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "TipoDocumentoId", "dbo.TipoDocumento");
            DropForeignKey("dbo.Historial", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Usuario", new[] { "TipoDocumentoId" });
            DropIndex("dbo.Historial", new[] { "UsuarioId" });
            DropTable("dbo.TipoDocumento");
            DropTable("dbo.Usuario");
            DropTable("dbo.Historial");
        }
    }
}
