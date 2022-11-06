using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceTrabalho.Models

{
    public class Carrinho
    {
        public int Id {get; set;}
        public bool IsPaid {get; set;}
        public int UsuarioId {get; set;}
        public Usuario Usuario {get; set;}
        public ICollection<Produto> Produtos {get; set;}
    }
}