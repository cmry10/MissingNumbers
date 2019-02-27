namespace Model.Migrations
{
    using System.Data.Entity.Migrations;
    using Model;

    internal sealed class Configuration : DbMigrationsConfiguration<Model.MissingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Model.MissingContext context)
        {
            context.TipoDocumentoes.AddOrUpdate(x => x.Id,
                   new TipoDocumento() { Descripcion = "C�dula de Ciudadan�a" },
                   new TipoDocumento() { Descripcion = "C�dula de Extranjer�a" },
                   new TipoDocumento() { Descripcion = "Tarjeta de Identidad" }
                   );             
        }
    }
}
