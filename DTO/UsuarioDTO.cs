using System.ComponentModel.DataAnnotations;

namespace DesafioAPI.DTO
{
    public class UsuarioDTO
    {
        [Required]
        [MaxLength(5)]
        [MinLength(4)]
        public string Login {get;set;}
        
        [Required]
        [MinLength(6)]
        public string Senha { get; set; }
        [EmailAddress]
        public string Email {get;set;}

       
    }
}