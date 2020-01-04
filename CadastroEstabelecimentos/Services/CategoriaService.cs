using CadastroEstabelecimentos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<List<Categoria>> FindAllAsync() //operação assíncrona
        {
            return await _context.Categoria.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
