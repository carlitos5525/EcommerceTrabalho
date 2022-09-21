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


    }
}