using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
