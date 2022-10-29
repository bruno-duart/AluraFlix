﻿using System.ComponentModel.DataAnnotations;

namespace AluraFlix.Models
{
    public class Videos
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage ="Título do Vídeo não pode exceder 50 caracteres")]
        public string Titulo { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage ="Descrição do Vídeo não pode exceder 1000 caracteres")]
        public string Descricao { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
