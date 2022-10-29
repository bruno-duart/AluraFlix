using System.ComponentModel.DataAnnotations;

namespace AluraFlix.Data.VideosDTOS
{
    public class UpdateVideosDTO
    {
        [Required]
        [StringLength(50, ErrorMessage = "Título do Vídeo não pode exceder 50 caracteres")]
        public string Titulo { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "Descrição do Vídeo não pode exceder 1000 caracteres")]
        public string Descricao { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
