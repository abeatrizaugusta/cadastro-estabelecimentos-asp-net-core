using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CadastroEstabelecimentos.Models
{
    public class CadastroEstabelecimentosContext : DbContext
    {
        public CadastroEstabelecimentosContext (DbContextOptions<CadastroEstabelecimentosContext> options)
            : base(options)
        {
        }

        public DbSet<CadastroEstabelecimentos.Models.Categoria> Categoria { get; set; }
    }
}
