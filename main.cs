using System;
using System.Collections.Generic;

class ProgramaControleGastos
{
    static List<double> InserirValores(List<string> categorias)
    {
        var gastos = new List<double>();
        foreach (var categoria in categorias)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Insira o valor gasto em {categoria}: ");
                    var valor = double.Parse(Console.ReadLine());
                    if (valor < 0)
                    {
                        throw new ArgumentException("O valor não pode ser negativo.");
                    }
                    gastos.Add(valor);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Entrada inválida: {e.Message}. Tente novamente.");
                }
            }
        }
        return gastos;
    }

    static double TotalGastos(List<double> gastos)
    {
        double total = 0;
        foreach (var gasto in gastos)
        {
            total += gasto;
        }
        return total;
    }

    static double MediaGastos(List<double> gastos)
    {
        return TotalGastos(gastos) / gastos.Count;
    }

    static (double, string) MaiorGasto(List<double> gastos, List<string> categorias)
    {
        double maior = double.MinValue;
        string categoria = "";
        for (int i = 0; i < gastos.Count; i++)
        {
            if (gastos[i] > maior)
            {
                maior = gastos[i];
                categoria = categorias[i];
            }
        }
        return (maior, categoria);
    }

    static (double, string) MenorGasto(List<double> gastos, List<string> categorias)
    {
        double menor = double.MaxValue;
        string categoria = "";
        for (int i = 0; i < gastos.Count; i++)
        {
            if (gastos[i] < menor)
            {
                menor = gastos[i];
                categoria = categorias[i];
            }
        }
        return (menor, categoria);
    }

    static void ExibirResultados(List<double> gastos, List<string> categorias)
    {
        double total = TotalGastos(gastos);
        double media = MediaGastos(gastos);
        var (maior, categoriaMaior) = MaiorGasto(gastos, categorias);
        var (menor, categoriaMenor) = MenorGasto(gastos, categorias);

        Console.WriteLine($"Total de gastos: R$ {total:F2}");
        Console.WriteLine($"Gasto médio mensal: R$ {media:F2}");
        Console.WriteLine($"Maior gasto: R$ {maior:F2} em {categoriaMaior}");
        Console.WriteLine($"Menor gasto: R$ {menor:F2} em {categoriaMenor}");
    }

    static void Main()
    {
        var categorias = new List<string> { "Alimentação", "Transporte", "Lazer", "Saúde", "Educação" };
        while (true)
        {
            var gastos = InserirValores(categorias);
            ExibirResultados(gastos, categorias);
            Console.Write("Deseja inserir novos valores? (s/n): ");
            var opcao = Console.ReadLine();
            if (opcao.ToLower() != "s")
            {
                break;
            }
        }
    }
}
