using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceTrabalho.Models
{
    public class CategoriaProduto
    {
        public int Id {get; set;}
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public String Nome {get; set;}
        [Required(ErrorMessage = "O campo descrição é obrigatório.")]
        [StringLength(
            100,
            ErrorMessage = "O campo de descrição deve conter no máximo 100 caracteres!"
        )]
        public String Descricao {get; set;}
    }
}