using System;

namespace EcommerceTrabalho.Models
{
    public class Produto
    {
        public int Id {get; set;}
        public String Nome {get; set;}
        public float Preco {get; set;}
        public String Descricao {get; set;}
        public int CategoriaProdutoId {get; set;}
        public CategoriaProduto CategoriaProduto {get; set;}
    }
}