using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroEstabelecimentos.Models;
using CadastroEstabelecimentos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroEstabelecimentos.Controllers
{
    public class EstabelecimentosController : Controller
    {
        private readonly EstabelecimentoService _estabelecimentoService;

        public EstabelecimentosController(EstabelecimentoService estabelecimentoService)
        {
            _estabelecimentoService = estabelecimentoService;
        }
        public IActionResult Index()
        {
            var list = _estabelecimentoService.FindAll(); //retorna uma lista de estabelecimentos
            return View(list);
        }

        public IActionResult Create()
        {
            return View(); //retorna a View Create
        }

        [HttpPost] //indicar que é uma ação de Post
        [ValidateAntiForgeryToken] //evitar ataques
        public IActionResult Create(Estabelecimento estabelecimento)
        {
            _estabelecimentoService.Insert(estabelecimento); //chama o método Insert de service (que cadastra no DB) e terna a View Index
            return RedirectToAction(nameof(Index));
        }
    }
}