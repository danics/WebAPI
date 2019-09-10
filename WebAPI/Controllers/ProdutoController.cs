using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.ViewModels.Produto;

namespace WebAPI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [Route("v1/produtos")]
        [HttpGet]
        public IEnumerable<ProdutoViewModel> Get()
        {
            return _produtoRepositorio.Get();
        }

        [Route("v1/produtos/{id}")]
        [HttpGet]
        public Produto Get(int id)
        {
            return _produtoRepositorio.GetById(id);
        }

        [Route("v1/{CategoriaId}/produtos/")]
        [HttpPost]
        public Produto Post([FromBody]ProdutoViewModel produtoViewModel)
        {
            return _produtoRepositorio.Post(produtoViewModel);
        }

        [Route("v1/produtos/{id}")]
        [HttpPut]
        public Produto Put(int id, [FromBody]ProdutoViewModel produtoViewModel)
        {
            Produto produto = new Produto();
            produto.Id = id;
            produto.Title = produtoViewModel.Title;
            produto.Descricao = produtoViewModel.Descricao;
            produto.Preco = produtoViewModel.Preco;
            produto.Quantidade = produtoViewModel.Quantidade;
            produto.Imagem = produtoViewModel.Imagem;
            produto.CategoriaId = produtoViewModel.CategoriaId;

            return _produtoRepositorio.Put(produto);
        }

        [Route("v1/produtos")]
        [HttpDelete]
        public Produto Delete([FromBody]ProdutoViewModel produtoViewModel)
        {
            return _produtoRepositorio.Delete(produtoViewModel);
        }
    }
}
           