using System.ComponentModel.DataAnnotations;

namespace DesafioAPI.Models
{
    public class Starter
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        [Required]
        [MinLength(14)]
        [MaxLength(14)]
        public string CPF {get;set;}
        [Required] 
        [MinLength(4)]
        [MaxLength(4)]       
        public string Login {get;set;}
        [EmailAddress]
        public string Email {get;set;}
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}