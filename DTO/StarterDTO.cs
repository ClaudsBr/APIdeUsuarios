using System.ComponentModel.DataAnnotations;

namespace DesafioAPI.DTO
{
    public class StarterDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        [MaxLength(60)]
        [MinLength(5)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(14)]
        [MinLength(14)]        
        public string CPF { get; set; }
        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        public string Login { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int CategoriaID {get;set;}
    }
    
}