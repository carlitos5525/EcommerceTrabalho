using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EcommerceTrabalho.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EcommerceTrabalho.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //injeção de dependecia
        private readonly DataContext _context;
        public UsuarioController(DataContext context)
        {
            _context = context;
        }

         [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Created("", usuario);
        }

        
    }
}