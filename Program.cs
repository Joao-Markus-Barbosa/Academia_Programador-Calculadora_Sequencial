using System;

namespace CalculadoraSequencialSimplificada
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculadora Sequencial Simplificada");
            Console.WriteLine("Digite uma expressão (ex: 2 + 3 * 4):");

            while (true)
            {
                Console.Write("> ");
                string expressao = Console.ReadLine();

                if (expressao.ToLower() == "sair")
                {
                    Console.WriteLine("Saindo...");
                    break;
                }

                try
                {
                    double resultado = CalcularExpressao(expressao);
                    Console.WriteLine($"Resultado: {resultado}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }

        // Função para calcular uma expressão sequencial com precedência
        static double CalcularExpressao(string expressao)
        {
            // Remove espaços em branco
            expressao = expressao.Replace(" ", "");

            // Variáveis para armazenar números e operadores
            double resultado = 0;
            double numeroAtual = 0;
            char operadorAtual = '+';

            // Percorre cada caractere da expressão
            for (int i = 0; i < expressao.Length; i++)
            {
                char c = expressao[i];

                // Se for um dígito ou ponto decimal, constrói o número atual
                if (char.IsDigit(c) || c == '.')
                {
                    string numeroTemp = "";
                    while (i < expressao.Length && (char.IsDigit(expressao[i]) || expressao[i] == '.'))
                    {
                        numeroTemp += expressao[i];
                        i++;
                    }
                    i--; // Volta uma posição para não pular o próximo caractere
                    numeroAtual = double.Parse(numeroTemp);
                }

                // Se for um operador ou o final da expressão, processa o número atual
                if (!char.IsDigit(c) && c != '.' || i == expressao.Length - 1)
                {
                    switch (operadorAtual)
                    {
                        case '+':
                            resultado += numeroAtual;
                            break;
                        case '-':
                            resultado -= numeroAtual;
                            break;
                        case '*':
                            resultado *= numeroAtual;
                            break;
                        case '/':
                            if (numeroAtual == 0)
                            {
                                throw new Exception("Divisão por zero.");
                            }
                            resultado /= numeroAtual;
                            break;
                    }

                    // Atualiza o operador atual
                    operadorAtual = c;
                }
            }

            return resultado;
        }
    }
}