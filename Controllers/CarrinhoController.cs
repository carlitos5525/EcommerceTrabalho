using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EcommerceTrabalho.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EcommerceTrabalho.Controllers
{
    [Route("api/carrinho")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        //injeção de dependecia
        private readonly DataContext _context;
        public CarrinhoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("criar")]
        public IActionResult Criar([FromBody] Carrinho carrinho)
        {
            var id_usuario = carrinho.UsuarioId;

            var usuario_encontrado = _context.Usuarios.FirstOrDefault(u => u.Id == id_usuario);

            if(usuario_encontrado == null)
            {
                return NotFound("Usuário não existe");
            }

            if(usuario_encontrado.IsLogged == false)
            {
                return BadRequest("Usuário não está logado");
            }
            else
            {
                _context.Carrinhos.Add(carrinho);
                _context.SaveChanges();
                return Created("", carrinho);
            }
            
        }

        [HttpPost]
        [Route("adicionar/{id_carrinho}/{id_produto}")]
        public IActionResult Adicionar([FromRoute] int id_carrinho, int id_produto)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id_produto);
            var carrinho = _context.Carrinhos.Include(p => p.Produtos).FirstOrDefault( c => c.Id == id_carrinho);

            if(produto == null || carrinho == null)
            {
                return NotFound();
            }
            else
            {
                carrinho.Produtos.Add(produto);
                _context.SaveChanges();
                return Ok(carrinho);
            }
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int id)
        {
            var carrinhos = _context.Carrinhos.Include(p => p.Produtos).Include(u => u.Usuario).ToList();

            var carrinho_encontrado = carrinhos.FirstOrDefault(c => c.Id == id);

            if(carrinho_encontrado == null)
            {
                return NotFound();
            }
            else if(carrinho_encontrado.IsPaid == true)
            {
                return NotFound("O carrinho já foi pago");
            }
            else
            {
                return Ok(carrinho_encontrado);
            }
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            foreach (var carrinho in _context.Carrinhos.ToList())
            {
                if (carrinho.Id == id)
                {
                    _context.Carrinhos.Remove(carrinho);
                    _context.SaveChanges();
                    return Ok(carrinho);
                }
            }

            return NotFound();
        }
    }
}