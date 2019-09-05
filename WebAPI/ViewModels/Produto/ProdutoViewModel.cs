using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels.Produto
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Imagem { get; set; }       
        public int CategoriaId { get; set; }
    }
}
