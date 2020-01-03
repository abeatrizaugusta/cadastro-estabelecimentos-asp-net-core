using CadastroEstabelecimentos.Models.Enums;
using System;

namespace CadastroEstabelecimentos.Models
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public EstabeStatus Status { get; set; } //Ativo ou Inativo
        public Categoria Categoria { get; set; } //Categoria do Estabelecimento (Supermercado, Restaurante, Borracharia, Posto, Oficina)
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
