using CadastroEstabelecimentos.Models;
using CadastroEstabelecimentos.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
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
        //retorna o estabelecimento que possui o id, se não existir, retorna null
        public Estabelecimento FindById(int id)
        {
            return _context.Estabelecimento.Include(obj => obj.Categoria).FirstOrDefault(obj => obj.Id == id); //o include faz o join buscando também a categoria
        }

        //remover o objeto
        public void Remove(int id)
        {
            var obj = _context.Estabelecimento.Find(id);
            _context.Estabelecimento.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Estabelecimento obj)
        {
            if (!_context.Estabelecimento.Any(x => x.Id == obj.Id)) //verfica se o id existe no banco
            {
                throw new NotFoundException("Id not found"); 
            }
            try 
            {
                _context.Update(obj); //atualiza
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) //exceção de concorrência do banco de dados
            {
                throw new DbConcurrencyException(e.Message); 
            }
        }

    }
}
