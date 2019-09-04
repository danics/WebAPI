using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("v1/categorias")]
        [HttpGet]
        public IEnumerable<Categoria> Index()
        {
            return _context.Categorias.AsNoTracking().ToList();
        }

        [Route("v1/categorias/{id}")]
        [HttpGet]
        public Categoria Get(int id)
        {
            return _context.Categorias.Include(x=>x.Produtos).AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        [Route("v1/categorias/{id}/produtos")]
        [HttpPost]
        public IEnumerable<Produto> GetProdutos(int id)
        {
            return _context.Produtos.AsNoTracking().Where(x => x.CategoriaId == id).ToList();
        }

        [Route("v1/categorias")]
        [HttpPost]
        public Categoria Post([FromBody] Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return categoria;
        }

        [Route("v1/categorias")]
        [HttpPut]
        public Categoria Put([FromBody] Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();

            return categoria;
        }

        [Route("v1/categorias")]
        [HttpDelete]
        public Categoria Delete([FromBody] Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return categoria;
        }
    }
}
