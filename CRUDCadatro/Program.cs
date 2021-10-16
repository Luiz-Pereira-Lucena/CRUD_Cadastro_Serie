using CRUDCadatro.Interfaces;
using System;

namespace CRUDCadatro
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

           while(opcaoUsuario.ToUpper() != "x")
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
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VisualizarSerie();
                        break;

                    case "c":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Lista Serie CRUD");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1, Listar Serie");
            Console.WriteLine("2, Inserir nova serie");
            Console.WriteLine("3, Atualizar serie");
            Console.WriteLine("4, Excluir serie");
            Console.WriteLine("5, Vizualizar serie");
            Console.WriteLine("C, Limpar tela");
            Console.WriteLine("X, Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        //LISTAR
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Serie");

            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada!");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                if(excluido)

                Console.WriteLine("#ID {0} : - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "EXCLUIDO" : ""));
            }
        }

        //INSERIR
        private static void InserirSeries()
        {
            Console.WriteLine("Inserir nova serie");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual é o título da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Ano de início da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        //ATUALIZAR
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da serie que deseja atualizar");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual é o título da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Ano de início da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        //EXCLUIR
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da serie que deseja excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        //VISUALIZAR
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da serie que deseja excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
    }
}
