using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPortalNoticias.Models
{
    [Table("Noticias")]
    public class Noticia
    {
        [Key]
        public int NoticiaId { get; set; }
        [Required]
        public string Titulo { get; set; }

    }
}
