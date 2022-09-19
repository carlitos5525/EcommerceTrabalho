using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EcommerceTrabalho.Models;
using System.Linq;

namespace EcommerceTrabalho.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaProdutoController : ControllerBase
    {
        //injeção de dependecia
        private readonly DataContext _context;
        public CategoriaProdutoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            return Ok(_context.Categorias.ToList());

        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] CategoriaProduto categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return Created("", categoria);
        }

    }


}