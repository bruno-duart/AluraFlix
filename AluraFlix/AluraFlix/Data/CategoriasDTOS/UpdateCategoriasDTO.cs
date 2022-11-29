using System.ComponentModel.DataAnnotations;

namespace AluraFlix.Data.CategoriasDTOS
{
    public class UpdateCategoriasDTO
    {
        [Required(ErrorMessage = "Título não pode ficar em branco")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Cor não pode ficar em branco")]
        [StringLength(7, ErrorMessage ="Código de cor em hexadecimal não pode ultrapassar 7 caracteres, incluindo o #")]
        public string Cor { get; set; }
    }
}
