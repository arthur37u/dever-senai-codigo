
using System;
using System.Collections.Generic;
using System.IO;

namespace ClientLab
{
    public class SistemaDeClientes
    {
        private List<Cliente> clientes = new List<Cliente>();
        private const string arquivoPessoasFisicas = "pessoasFisicas.txt";
        private const string arquivoPessoasJuridicas = "pessoasJuridicas.txt";

        public void AdicionarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
            SalvarClienteEmArquivo(cliente);
        }

        private void SalvarClienteEmArquivo(Cliente cliente)
        {
            string linha = cliente is PessoaFisica pf
                ? $"\{pf.Nome},\{pf.CPF},\{pf.DataNascimento:yyyy-MM-dd}"
                : $"\{((PessoaJuridica)cliente).Nome},\{((PessoaJuridica)cliente).CNPJ}";

            string caminhoArquivo = cliente is PessoaFisica ? arquivoPessoasFisicas : arquivoPessoasJuridicas;
            File.AppendAllText(caminhoArquivo, linha + Environment.NewLine);
        }

        public void ListarClientes()
        {
            Console.WriteLine("Clientes:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine(cliente is PessoaFisica
                    ? $"\{cliente.Nome}, CPF: \{((PessoaFisica)cliente).CPF}, Nascimento: \{((PessoaFisica)cliente).DataNascimento:yyyy-MM-dd}"
                    : $"\{cliente.Nome}, CNPJ: \{((PessoaJuridica)cliente).CNPJ}");
            }
        }
    }
}
