using System.ComponentModel.DataAnnotations;

namespace DesafioAPI.DTO
{
    public class CategoriaDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage ="O Nome da Categoria não pode ter de 50 caracteres")]
        [MinLength(1, ErrorMessage ="O nome da Categoria não pode ter menos de 1 caractere")]
        public string Nome { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage ="O Nome da Tecnologia não pode ter de 50 caracteres")]
        [MinLength(1, ErrorMessage ="O nome da Tecnologia não pode ter menos de 1 caractere")]
        public string Tecnologia {get;set;}
    }
}