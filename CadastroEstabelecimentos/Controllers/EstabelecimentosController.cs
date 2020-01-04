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
        public IActionResult Index()
        {
            var list = _estabelecimentoService.FindAll(); //retorna uma lista de estabelecimentos
            return View(list);
        }

        public IActionResult Create()
        {
            var categorias = _categoriaService.FindAll(); //carregar as categorias cadastradas no banco
            var viewModel = new EstabelecimentoFormViewModel { Categorias = categorias }; //carregar o formulário
            return View(viewModel);
        }

        [HttpPost] //indicar que é uma ação de Post
        [ValidateAntiForgeryToken] //evitar ataques
        public IActionResult Create(Estabelecimento estabelecimento)
        {
            _estabelecimentoService.Insert(estabelecimento); //chama o método Insert de service (que cadastra no DB) e terna a View Index
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) //se o id for null, retorna página de erro
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _estabelecimentoService.FindById(id.Value); //pega o objeto do id
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj); //se não for null, retorna a view com o objeto confirmando a deleção
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _estabelecimentoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _estabelecimentoService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            var obj = _estabelecimentoService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Categoria> categorias = _categoriaService.FindAll(); //carregar as categorias para edição
            EstabelecimentoFormViewModel viewModel = new EstabelecimentoFormViewModel { Estabelecimento = obj, Categorias = categorias }; //preenche o formulário com os dados do objeto
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Estabelecimento estabelecimento)
        {
            if (id != estabelecimento.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id incompatível" });
            }
            try
            {
                _estabelecimentoService.Update(estabelecimento);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message }); //mensagem da própria exceção
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {

                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier //pegar o id interno da requisição
            };
            return View(viewModel);
        }
    }
}