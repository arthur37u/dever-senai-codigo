
using System;
using System.Text.RegularExpressions;

namespace ClientLab
{
    public abstract class Cliente
    {
        public string Nome { get; set; }
        public abstract void PagarImposto();

        public Cliente(string nome)
        {
            Nome = nome;
        }
    }

    public class PessoaFisica : Cliente
    {
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public PessoaFisica(string nome, string cpf, DateTime dataNascimento) : base(nome)
        {
            if (!Regex.IsMatch(cpf, @"^\d{11}$"))
                throw new ArgumentException("CPF inválido.");

            CPF = cpf;
            DataNascimento = dataNascimento;
        }

        public override void PagarImposto()
        {
            Console.WriteLine($"\{Nome} (CPF: \{CPF}) pagou imposto.");
        }
    }

    public class PessoaJuridica : Cliente
    {
        public string CNPJ { get; set; }

        public PessoaJuridica(string nome, string cnpj) : base(nome)
        {
            if (!Regex.IsMatch(cnpj, @"^\d{14}$"))
                throw new ArgumentException("CNPJ inválido.");

            CNPJ = cnpj;
        }

        public override void PagarImposto()
        {
            Console.WriteLine($"\{Nome} (CNPJ: \{CNPJ}) pagou imposto.");
        }
    }
}
