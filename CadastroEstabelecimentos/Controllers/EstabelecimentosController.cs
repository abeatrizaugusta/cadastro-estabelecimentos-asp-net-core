using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}