using System;

namespace EcommerceTrabalho.Models
{
    public class Produto
    {
        public int Id {get; set;}
        public String Nome {get; set;}
        public float Preco {get; set;}
        public String Descricao {get; set;}
        public int IdCategoriaProduto {get; set;}
        public virtual CategoriaProduto CategoriaProduto {get; set;}
    }
}