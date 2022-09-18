using System;
using System.Collections.Generic;

namespace EcommerceTrabalho.Models
{
    public class CategoriaProduto
    {
        public int Id {get; set;}
        public String Nome {get; set;}
        public String Descricao {get; set;}
        public virtual ICollection<Produto> Produtos {get; set;}
    }
}