﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroEstabelecimentos.Models;
using CadastroEstabelecimentos.Models.ViewModels;
using CadastroEstabelecimentos.Services;
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
    }
}