using System;

namespace DIO.CadastroSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Sistema de Séries!");
            string opcaoUsuario = ObterOpcao();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        PesquisarSeries();
                        break;                  
                    default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcao();
            }
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries:");
            var lista = repositorio.Listar();

            if (lista.Count == 0)
            {
                Console.WriteLine("Ainda não foram cadastradas séries.");
                return;
            }
            foreach(var serie in lista)
            {
                if(!serie.retornarExcluido()){
                    Console.WriteLine("ID {0}: - {1}", serie.retornarId(), serie.retornarTitulo());
                }
            }
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir série:");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções anteriores: ");
            int opcaoGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string opcaoTitulo = Console.ReadLine();     
            
            Console.Write("Digite o ano de lançamento da série: ");
            int opcaoAnoLancamento = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string opcaoDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
                                        genero: (Genero)opcaoGenero,
                                        titulo: opcaoTitulo,
                                        anoLancamento: opcaoAnoLancamento,
                                        descricao: opcaoDescricao);
            repositorio.Inserir(novaSerie);          
        }

        private static void AtualizarSeries()
        {
            Console.Write("Digite o id da série que deseja atualizar: ");
            int idOpcao = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções anteriores: ");
            int opcaoGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string opcaoTitulo = Console.ReadLine();     
            
            Console.Write("Digite o ano de lançamento da série: ");
            int opcaoAnoLancamento = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string opcaoDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: idOpcao, 
                                        genero: (Genero)opcaoGenero,
                                        titulo: opcaoTitulo,
                                        anoLancamento: opcaoAnoLancamento,
                                        descricao: opcaoDescricao);
            repositorio.Atualizar(idOpcao, atualizaSerie);          
        }

        private static void ExcluirSeries()
        {
            Console.Write("Digite o id da série que deseja excluir: ");
            int idOpcao = int.Parse(Console.ReadLine());
            Console.WriteLine("Confirmar exclusão da série:\n{0}", repositorio.RetornarPorId(idOpcao));
            Console.WriteLine();
            Console.WriteLine("Digite (Y/N)");

            string opcaoConfirmacao = Console.ReadLine();
            if (opcaoConfirmacao.ToUpper() == "Y")
            {
                repositorio.Excluir(idOpcao);
                Console.WriteLine("Série excluída com sucesso.");
            } else
            {
                Console.WriteLine("Série não excluída.");
            }
        }

        private static void PesquisarSeries()
        {
            Console.Write("Digite o id da série que deseja pesquisar: ");
            int idOpcao = int.Parse(Console.ReadLine());
            Console.WriteLine(repositorio.RetornarPorId(idOpcao)); 
            Console.WriteLine();
        }

        private static string ObterOpcao(){
            Console.WriteLine();
            Console.WriteLine("Escolha uma opção válida a seguir:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar séries:");
            Console.WriteLine("2 - Inserir novas séries no repositório");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Remover série");
            Console.WriteLine("5 - Pesquisar por série");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
