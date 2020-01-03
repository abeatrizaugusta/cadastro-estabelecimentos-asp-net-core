using CadastroEstabelecimentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroEstabelecimentos.Services
{
    public class EstabelecimentoService
    {
        //Dependência com o DBContext - readonly previne que a classe seja alterada
        private readonly CadastroEstabelecimentosContext _context;

        //Construtor para que aconteça a inserção de dependências
        public EstabelecimentoService(CadastroEstabelecimentosContext context)
        {
            _context = context;
        }
        //FindAll para retornar uma lista com todos estabelecimentos cadastrados no banco de dados
        public List<Estabelecimento> FindAll()
        {
            return _context.Estabelecimento.ToList();
        }

        public void Insert(Estabelecimento obj) //inserir dados do estabelecimento no DB
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
