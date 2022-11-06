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

        [HttpPost]
        [Route("logar")]
        public IActionResult Logar([FromBody] Usuario usuario)
        {
            var usuario_encontrado = _context.Usuarios.FirstOrDefault(
                f => f.Login == usuario.Login && f.Senha == usuario.Senha
            );

            if(usuario_encontrado == null)
            {
                return NotFound();
            }
            else
            {
                usuario_encontrado.IsLogged = true;
                _context.Usuarios.Update(usuario_encontrado);
                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpPost]
        [Route("deslogar")]
        public IActionResult Deslogar([FromBody] Usuario usuario)
        {
             var usuario_encontrado = _context.Usuarios.FirstOrDefault(
                f => f.Login == usuario.Login && f.Senha == usuario.Senha
            );

            if(usuario_encontrado == null)
            {
                return NotFound();
            }
            else
            {
                usuario_encontrado.IsLogged = false;
                _context.Usuarios.Update(usuario_encontrado);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}