using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EcommerceTrabalho.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EcommerceTrabalho.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        //injeção de dependecia
        private readonly DataContext _context;
        public ProdutoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Created("", produto);
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            return Ok(_context.Produtos.Include(p => p.CategoriaProduto).ToList());
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int Id)
        {
            foreach (Produto produto in _context.Produtos.ToList())
            {
                if (produto.Id == Id)
                {
                    return Ok(produto);
                }
            }

            return NotFound();
        }

        
        [HttpDelete]
        [Route("excluir/{id}")]
        public IActionResult Excluir([FromRoute] int id)
        {
            foreach (var produto in _context.Produtos.ToList())
            {
                if (produto.Id == id)
                {
                    _context.Produtos.Remove(produto);
                    _context.SaveChanges();
                    return Ok(produto);
                }
            }

            return NotFound();
        }
    }
}