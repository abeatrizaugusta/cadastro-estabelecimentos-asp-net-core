using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroEstabelecimentos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroEstabelecimentos.Controllers
{
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            List<Categoria> list = new List<Categoria>();
            list.Add(new Categoria { Id = 1, Nome = "Supermercado" });
            list.Add(new Categoria { Id = 2, Nome = "Restaurante" });
            list.Add(new Categoria { Id = 3, Nome = "Borracharia" });
            list.Add(new Categoria { Id = 4, Nome = "Posto" });
            list.Add(new Categoria { Id = 5, Nome = "Oficina" });

            return View(list);
        }
    }
}