
using System;

namespace ClientLab
{
    class Program
    {
        static void Main(string[] args)
        {
            SistemaDeClientes sistema = new SistemaDeClientes();

            while (true)
            {
                Console.WriteLine("1. Adicionar Pessoa Física");
                Console.WriteLine("2. Adicionar Pessoa Jurídica");
                Console.WriteLine("3. Listar Clientes");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarPessoaFisica(sistema);
                        break;
                    case "2":
                        AdicionarPessoaJuridica(sistema);
                        break;
                    case "3":
                        sistema.ListarClientes();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static void AdicionarPessoaFisica(SistemaDeClientes sistema)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("CPF (11 dígitos): ");
            string cpf = Console.ReadLine();
            Console.Write("Data de Nascimento (yyyy-mm-dd): ");
            DateTime dataNascimento;
            if (!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
            {
                Console.WriteLine("Data de nascimento inválida.");
                return;
            }

            try
            {
                var pessoaFisica = new PessoaFisica(nome, cpf, dataNascimento);
                sistema.AdicionarCliente(pessoaFisica);
                Console.WriteLine("Pessoa Física adicionada com sucesso.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void AdicionarPessoaJuridica(SistemaDeClientes sistema)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("CNPJ (14 dígitos): ");
            string cnpj = Console.ReadLine();

            try
            {
                var pessoaJuridica = new PessoaJuridica(nome, cnpj);
                sistema.AdicionarCliente(pessoaJuridica);
                Console.WriteLine("Pessoa Jurídica adicionada com sucesso.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
