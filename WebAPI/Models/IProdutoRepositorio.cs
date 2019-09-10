using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ViewModels.Produto;

namespace WebAPI.Models
{
    public interface IProdutoRepositorio
    {
       IEnumerable<ProdutoViewModel> Get();
       Produto GetById(int id);
       Produto Post(ProdutoViewModel produtoViewModel);
       Produto Put(Produto produtoAtualizado);
       Produto Delete(ProdutoViewModel produtoViewModel);
    }
}
