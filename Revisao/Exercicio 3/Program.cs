using System;

public class Program
{
    public static int CalcularSoma(int n)
    {
        if (n == 1)
        {
            return 1;
        }
        else
        {
            return (2 * n - 1) + CalcularSoma(n - 1);
        }
    }

    public static void Main()
    {
        Console.Write("Digite um número: ");
        int n = int.Parse(Console.ReadLine());
        int soma = CalcularSoma(n);
        Console.WriteLine("Resultado Soma(n) = " + soma);
    }
}

