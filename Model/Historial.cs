namespace Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
                
        public string numerosIni { get; set; }
        
        public string numerosSec { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
