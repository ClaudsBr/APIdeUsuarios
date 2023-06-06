using System.ComponentModel.DataAnnotations;

namespace DesafioAPI.Models
{
    public class Usuario
    {
         public int Id { get; set; }           
        [Required]
        [MaxLength(5)]
        [MinLength(4)]
        public string Login {get;set;}
        
       [Required]
       [MinLength(6)]
        public string Senha { get; set; }
        [EmailAddress]
        public string Email{get;set;}
        public string Role {get;set;}

       public Usuario(string login, string senha, string email){
           this.Login = login;
           this.Senha = senha;
           this.Email = email;
           this.Role = "Usuario";
       }

        
    }
}