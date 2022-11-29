using System.ComponentModel.DataAnnotations;

namespace AluraFlix.Models
{
    public class Categorias
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Título não pode ficar em branco")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Cor não pode ficar em branco")]
        public string Cor { get; set; }
    }
}
