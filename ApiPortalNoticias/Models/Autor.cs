using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPortalNoticias.Models
{
    [Table("Autores")]
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string DataNascimento { get; set; }
        [Required]
        public string ImagemApresentacao { get; set; }
        [Required]
        public string TextoApresentacao { get; set; }
    }

}
