namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Historial")]
    public partial class Historial
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(100)]
        public string ListaOriginal { get; set; }

        [Required]
        [StringLength(100)]
        public string ListaResultado { get; set; }

        [Required]
        [StringLength(100)]
        public string listaPerdidos { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
