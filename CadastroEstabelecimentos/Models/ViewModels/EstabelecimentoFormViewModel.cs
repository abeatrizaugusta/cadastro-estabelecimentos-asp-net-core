using System;
using System.Collections.Generic;

namespace CadastroEstabelecimentos.Models.ViewModels
{
    public class EstabelecimentoFormViewModel
    {
        //dados necessários para o formulário: dados do estabelecimento e lista de categorias
        public Estabelecimento Estabelecimento{ get; set; }
        public ICollection<Categoria> Categorias{ get; set; }
    }
}
