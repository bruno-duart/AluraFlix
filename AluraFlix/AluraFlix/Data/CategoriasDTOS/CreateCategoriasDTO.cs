using System.ComponentModel.DataAnnotations;

namespace AluraFlix.Data.CategoriasDTOS
{
    public class CreateCategoriasDTO
    {
        [Required(ErrorMessage = "Título não pode ficar em branco")]
        [StringLength(50, ErrorMessage = "Título não pode exceder 50 caracteres")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Cor não pode ficar em branco")]
        [StringLength(7, ErrorMessage ="Código de cor em hexadecimal não pode ultrapassar 7 caracteres, incluindo o #")]
        public string Cor { get; set; }
    }
}
