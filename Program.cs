using System;
using Dio.Series.Interfaces;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositiorio repositorio  = new SerieRepositiorio();
        static void Main(string[] args)
        {
        string opcaoUsuario = ObterOpcaoUsuario();
        while (opcaoUsuario != "X")
        {
            switch(opcaoUsuario)
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
                case "C":
                    Console.Clear();
                    break;
                default:
                throw new ArgumentOutOfRangeException();
            }
            opcaoUsuario = ObterOpcaoUsuario();
        }

        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");
            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "Excluido":"");
            }
        }
        private static void InserirSeries()
        {
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            descricao: entradaDescricao,
            ano: entradaAno
            );

            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

           Serie atualizaSerie = new Serie(indiceSerie, 
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            descricao: entradaDescricao,
            ano: entradaAno
            );

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o Id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
