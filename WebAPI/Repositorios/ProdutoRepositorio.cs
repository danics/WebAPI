using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.ViewModels.Produto;

namespace WebAPI.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        ApplicationDbContext _context;

        public ProdutoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProdutoViewModel> Get()
        {
            var produtos = _context.Produtos.Include(x => x.Categoria).AsNoTracking().ToList();
            List<ProdutoViewModel> produtosViewModel = new List<ProdutoViewModel>();
            foreach (var produto in produtos)
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

        public Produto GetById(int id)
        {
            return _context.Produtos.Find(id);
        }

        public Produto Post(ProdutoViewModel produtoViewModel)
        {
            var produto = new Produto
            {
                Id = produtoViewModel.Id,
                Title = produtoViewModel.Title,
                Descricao = produtoViewModel.Descricao,
                Preco = produtoViewModel.Preco,
                Quantidade = produtoViewModel.Quantidade,
                Imagem = produtoViewModel.Imagem,
                DataDeCriacao = DateTime.Now,
                UltimaAtualizacao = DateTime.Now,
                CategoriaId = produtoViewModel.CategoriaId
            };

            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }
       
        public Produto Put(Produto produtoAtualizado)
        {
            //Produto produto = GetById(produtoAtualizado.Id);

 

            _context.Produtos.Update(produtoAtualizado);
            _context.SaveChanges();

            return produtoAtualizado;
        }

        public Produto Delete(ProdutoViewModel produtoViewModel)
        {
            var produto = GetById(produtoViewModel.Id);

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
