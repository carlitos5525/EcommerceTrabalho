using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EcommerceTrabalho.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EcommerceTrabalho.Controllers
{
    [Route("api/compra")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly DataContext _context;
        public CompraController(DataContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        [Route("comprar")]
        public IActionResult Comprar([FromBody] Compra compra)
        {
            var id_carrinho = compra.CarrinhoId;

            var carrinho_encontrado = _context.Carrinhos.FirstOrDefault(f => f.Id == id_carrinho);

            if(carrinho_encontrado == null)
            {
                return NotFound("Carrinho não existe");
            }
            else if(carrinho_encontrado.IsPaid == true)
            {
                return BadRequest("O carrinho informado já foi pago");
            }
            else
            {
                _context.Compras.Add(compra);
                _context.SaveChanges();

                carrinho_encontrado.IsPaid = true;
                _context.Carrinhos.Update(carrinho_encontrado);
                _context.SaveChanges();
                return Created("", compra);
            }
        }
    }
}