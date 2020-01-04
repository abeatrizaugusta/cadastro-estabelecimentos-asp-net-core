using CadastroEstabelecimentos.Models;
using System.Collections.Generic;
using System.Linq;

namespace CadastroEstabelecimentos.Services
{
    public class CategoriaService
    {
        private readonly CadastroEstabelecimentosContext _context;

        public CategoriaService(CadastroEstabelecimentosContext context)
        {
            _context = context;
        }

        //Listar as categorias ordenadas por nome
        public List<Categoria> FindAll()
        {
            return _context.Categoria.OrderBy(x => x.Nome).ToList(); 
        }
    }
}
