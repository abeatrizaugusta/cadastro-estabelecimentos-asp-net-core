using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CadastroEstabelecimentos.Models;
using CadastroEstabelecimentos.Models.ViewModels;
using CadastroEstabelecimentos.Services;
using CadastroEstabelecimentos.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CadastroEstabelecimentos.Controllers
{
    public class EstabelecimentosController : Controller
    {
        private readonly EstabelecimentoService _estabelecimentoService;
        private readonly CategoriaService _categoriaService; //Dependência com Categorias 

        public EstabelecimentosController(EstabelecimentoService estabelecimentoService, CategoriaService categoriaService)
        {
            _estabelecimentoService = estabelecimentoService;
            _categoriaService = categoriaService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _estabelecimentoService.FindAllAsync(); //retorna uma lista de estabelecimentos
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var categorias = await _categoriaService.FindAllAsync(); //carregar as categorias cadastradas no banco
            var viewModel = new EstabelecimentoFormViewModel { Categorias = categorias }; //carregar o formulário
            return View(viewModel);
        }

        [HttpPost] //indicar que é uma ação de Post
        [ValidateAntiForgeryToken] //evitar ataques
        public async Task<IActionResult> Create(Estabelecimento estabelecimento)
        {
            if (!ModelState.IsValid) //verifica se os campos foram preenchidos, se n for válido, retorna a view novamente
            {
                var categorias = await _categoriaService.FindAllAsync();
                var viewModel = new EstabelecimentoFormViewModel { Estabelecimento = estabelecimento, Categorias = categorias };
                return View(viewModel);
            }
            await _estabelecimentoService.InsertAsync(estabelecimento);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) //se o id for null, retorna página de erro
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _estabelecimentoService.FindByIdAsync(id.Value); //pega o objeto do id
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj); //se não for null, retorna a view com o objeto confirmando a deleção
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _estabelecimentoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _estabelecimentoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            var obj = await _estabelecimentoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            List<Categoria> categorias = await _categoriaService.FindAllAsync(); //carregar as categorias para edição
            EstabelecimentoFormViewModel viewModel = new EstabelecimentoFormViewModel { Estabelecimento = obj, Categorias = categorias }; //preenche o formulário com os dados do objeto
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Estabelecimento estabelecimento)
        {
            if (!ModelState.IsValid) //verifica se os campos foram preenchidos, se n for válido, retorna a view novamente
            {
                var categorias = await _categoriaService.FindAllAsync();
                var viewModel = new EstabelecimentoFormViewModel { Estabelecimento = estabelecimento, Categorias = categorias };
                return View(viewModel);
            }
            if (id != estabelecimento.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id incompatível" });
            }
            try
            {
                await _estabelecimentoService.UpdateAsync(estabelecimento);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message }); //mensagem da própria exceção
            }
        }

        public IActionResult Error(string message) //não precisa ser assíncrona pq não tem acesso a dados
        {
            var viewModel = new ErrorViewModel
            {

                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier //pegar o id interno da requisição
            };
            return View(viewModel);
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("dd-MM-yyyy");
            ViewData["maxDate"] = maxDate.Value.ToString("dd-MM-dd");
            var result = await _estabelecimentoService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

    }
}
