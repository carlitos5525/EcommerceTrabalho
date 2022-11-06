using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceTrabalho.Models
{
    public class Usuario
    {
        public int Id {get; set;}
        
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Login {get; set;}
        
        [Required]
        [StringLength(12, MinimumLength = 6)]
        public string Senha {get; set;}
        [Required]
        public string Nome {get; set;}

        public bool IsLogged {get; set;}
    }
}