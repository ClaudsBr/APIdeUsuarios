using System.ComponentModel.DataAnnotations;

namespace DesafioAPI.DTO
{
    public class LoginDTO
    {
        [Required]
        [MaxLength(5)]
        [MinLength(4)]
        public string Login {get;set;}
        
        [Required]
        [MinLength(6)]
        public string Senha { get; set; }
    }
}