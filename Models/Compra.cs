using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceTrabalho.Models
{
    public class Compra
    {
        public Compra()
        {
            this.DataCompra = DateTime.Now;
        }
        
        public int Id {get; set;}
        
        [Required]
        public int CarrinhoId {get; set;}
        public Carrinho Carrinho {get; set;}
        
        [Required]
        public double Valor {get; set;}
        public DateTime DataCompra {get; set;}
        
        [Required]
        public string MetodoPagamento {get; set;}

    }
}