using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceTrabalho.Models
{
    public class Produto
    {
        public int Id {get; set;}
        public String Nome {get; set;}
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public float Preco {get; set;}
         [Range(
            0,
            999,
            ErrorMessage = "O valor do produto deve ser até R$999."
        )]
        public String Descricao {get; set;}
         [StringLength(
            100,
            ErrorMessage = "O campo de descrição deve conter no máximo 100 caracteres!"
        )]
        public int CategoriaProdutoId {get; set;}
        public CategoriaProduto CategoriaProduto {get; set;}
    }
}