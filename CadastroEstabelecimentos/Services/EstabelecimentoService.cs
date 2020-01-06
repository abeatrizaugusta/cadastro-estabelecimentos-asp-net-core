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
        public async Task<List<Estabelecimento>> FindAllAsync()
        {
            return await _context.Estabelecimento.ToListAsync();
        }

        public async Task InsertAsync(Estabelecimento obj) //inserir dados do estabelecimento no DB
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        //retorna o estabelecimento que possui o id, se não existir, retorna null
        public async Task<Estabelecimento> FindByIdAsync(int id)
        {
            return await _context.Estabelecimento.Include(obj => obj.Categoria).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        //remover o objeto
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Estabelecimento.FindAsync(id);
            _context.Estabelecimento.Remove(obj);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Estabelecimento obj)
        {
            bool hasAny = await _context.Estabelecimento.AnyAsync(x => x.Id == obj.Id); //testa se no banco de dados tem um mesmo Id do obj
            if (!hasAny)
            {
                throw new NotFoundException("Id not found"); 
            }
            try 
            {
                _context.Update(obj); //atualiza
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) //exceção de concorrência do banco de dados
            {
                throw new DbConcurrencyException(e.Message); 
            }
        }

        public async Task<List<Estabelecimento>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Estabelecimento select obj; 
            if (minDate.HasValue)
            {
                result = result.Where(x => x.DataCadastro >= minDate.Value); 
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.DataCadastro <= maxDate.Value);
            }
            return await result
                .OrderByDescending(x => x.DataCadastro)
                .ToListAsync();
        }

    }
}
