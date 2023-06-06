using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioAPI.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        public string Tecnologia {get;set;}
        [Required]
        public string Nome { get; set; }
        
        public List<Starter> Starters { get; set; }
    }
}