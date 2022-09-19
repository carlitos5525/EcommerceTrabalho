using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EcommerceTrabalho.Models;

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


    }


}