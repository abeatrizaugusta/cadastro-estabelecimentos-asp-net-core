using CadastroEstabelecimentos.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroEstabelecimentos.Models
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        [Display(Name ="Razão Social")]
        public string RazaoSocial { get; set; }

        [DisplayFormat(DataFormatString = "{0:000\\.000\\.000-00}", ApplyFormatInEditMode = true)]
        public string Cnpj { get; set; }
        [DataType(DataType.EmailAddress)] //transforma o email em link
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCadastro { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        [Display(Name = "Status")]
        public EstabeStatus Status { get; set; } //Ativo ou Inativo
        public Categoria Categoria { get; set; } //Categoria do Estabelecimento (Supermercado, Restaurante, Borracharia, Posto, Oficina)
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; } //garantir que o campo Categoria não será nulo
        public Estabelecimento()
        {

        }

        public Estabelecimento(int id, string razaoSocial, string cnpj, string email, string endereco, string cidade, string estado, string telefone, DateTime dataCadastro, string agencia, string conta, EstabeStatus status, Categoria categoria)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            Email = email;
            Endereco = endereco;
            Cidade = cidade;
            Estado = estado;
            Telefone = telefone;
            DataCadastro = dataCadastro;
            Agencia = agencia;
            Conta = conta;
            Status = status;
            Categoria = categoria;
        }
    }
}
