namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MissingContext : DbContext
    {
        public MissingContext()
            : base("name=MissingContext")
        {
        }

        public virtual DbSet<Historial> Historials { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentoes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDocumento>()
                .HasMany(e => e.Usuarios)
                .WithRequired(e => e.TipoDocumento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Historials)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
