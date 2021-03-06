﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace CadastroEstabelecimentos.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Estabelecimento> Estabelecimentos { get; set; } = new List<Estabelecimento>(); //Uma categoria possui uma lista de estabelecimentos

        public Categoria()
        {

        }
        public Categoria(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddEstabelecimento(Estabelecimento estabelecimento)
        {
            Estabelecimentos.Add(estabelecimento);
        }

    }
}
