using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.ViewModels.Produto;

namespace WebAPI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("v1/produtos")]
        [HttpGet]
        public IEnumerable<ProdutoViewModel> Get()
        {
            var produtos = _context.Produtos.AsNoTracking().ToList();
            List<ProdutoViewModel> produtosViewModel = new List<ProdutoViewModel>();
              foreach(var produto in produtos)
                {
                    produtosViewModel.Add(new ProdutoViewModel
                    {
                        Id = produto.Id,
                        Title = produto.Title,
                        Descricao = produto.Descricao,
                        Preco = produto.Preco,
                        Quantidade = produto.Quantidade,
                        Imagem = produto.Imagem,
                        CategoriaId = produto.CategoriaId
                    });
                }
            return (produtosViewModel);
        }

        [Route("v1/produtos/{id}")]
        [HttpGet]
        public Produto Get(int id)
        {
            return _context.Produtos.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        [Route("v1/produtos")]
        [HttpPost]
        public Produto Post(ProdutoViewModel produtoViewModel)
        {
           var produto = new Produto{
               Id = produtoViewModel.Id,
               Title = produtoViewModel.Title,
               Descricao = produtoViewModel.Descricao,
               Preco = produtoViewModel.Preco,
               Quantidade = produtoViewModel.Quantidade,
               Imagem = produtoViewModel.Imagem,
               CategoriaId = produtoViewModel.CategoriaId
           };

            _context.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        [Route("v1/produtos/{id}")]
        [HttpPut]
        public Produto Put(ProdutoViewModel produtoViewModel)
        {
            var produto = _context.Produtos.Find(produtoViewModel.Id);

            produto.Id = produtoViewModel.Id;
            produto.Title = produtoViewModel.Title;
            produto.Descricao = produtoViewModel.Descricao;
            produto.Preco = produtoViewModel.Preco;
            produto.Quantidade = produtoViewModel.Quantidade;
            produto.Imagem = produtoViewModel.Imagem;
            produto.CategoriaId = produtoViewModel.CategoriaId;

            _context.Update(produto);
            _context.SaveChanges();

            return produto;
        }

        [Route("v1/produtos")]
        [HttpDelete]
        public Produto Delete(ProdutoViewModel produtoViewModel)
        {
            var produto = _context.Produtos.Find(produtoViewModel.Id);

            produto.Id = produtoViewModel.Id;
            produto.Title = produtoViewModel.Title;
            produto.Descricao = produtoViewModel.Descricao;
            produto.Preco = produtoViewModel.Preco;
            produto.Quantidade = produtoViewModel.Quantidade;
            produto.Imagem = produtoViewModel.Imagem;
            produto.CategoriaId = produtoViewModel.CategoriaId;

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return produto;

        }
    }
}
           