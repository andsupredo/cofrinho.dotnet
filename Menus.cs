using System;

namespace Cofrinho
{

    public class Menus
    { // Essa classe foi criada com o intuito de diminuir repetição de código.

        Cofrinho cofrinho = new Cofrinho();

        public int menuPrincipal()
        { // Método do menu principal, que ficará em loop, sempre que terminar uma
          // transação no cofrinho.
            int menu = 0; // iniciando a variável fora do escopo do 'do while'.

            do
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\n\n***COFRINHO***\n");
                        Console.WriteLine("Menu\n");
                        Console.WriteLine("1 - Adicionar moedas");
                        Console.WriteLine("2 - Remover moedas moedas");
                        Console.WriteLine("3 - Listar moedas moedas");
                        Console.WriteLine("4 - Calcular valor do cofrinho em R$");
                        Console.WriteLine("0 - Fechar cofrinho");
                        Console.Write(">>> ");

                        menu = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nDigite apenas números inteiros!");
                    }
                }
                switch (menu)
                { // Utilizei a opção de desvio switch case para obter um código menos repetitivo
                  // e funcional.

                    case 0:
                        Console.WriteLine("Encerrando o programa...");
                        break;

                    case 1:
                        selecionaAdd();
                        break;

                    case 2:
                        if (cofrinho.listaMoedas.Count == 0)
                        {
                            Console.WriteLine("\nNão existem moedas para serem removidas!");
                            break;
                        }
                        else
                        {
                            selecionaRemovida();
                            break;
                        }

                    case 3:

                        cofrinho.listagemMoedas();
                        break;

                    case 4:

                        cofrinho.totalConvertido();
                        break;

                    default:
                        Console.WriteLine("Opção inválida"); // opção para valor incorreto inserido.
                        break;
                }

            } while (menu != 0);// condição do loop.
            if (menu == 1)
            {
                return menu;
            }
            else if (menu == 2)
            {
                return menu;
            }
            else
            {
                return 0;
            }
        }

        public void selecionaAdd()
        { // Método criado para poupar tempo e repetição de código sem necessidade.
            int select;

            do
            {
                while (true)
                { // Laço para que só saia do bloco try quando inserido um dado válido.
                    try
                    { // Captura erro de input para evitar que sejam introduzidos caracteres que não
                      // sejam números inteiros e quebrar a aplicação.
                        Console.WriteLine("\nSelecione a moeda\n");
                        Console.WriteLine("1 - Dólar");
                        Console.WriteLine("2 - Euro");
                        Console.WriteLine("3 - Real");
                        Console.WriteLine("0 - Retornar ao menu principal");
                        Console.Write(">>> ");
                        select = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nDigite apenas números inteiros!");
                    }
                }
                switch (select)
                {

                    case 0:
                        Console.WriteLine("Voltando ao menu anterior...");
                        break; // Encerra o loop e retorna.

                    case 1:
                        Console.WriteLine("Selecionado dólar");
                        var dolar = new Dolar(valorMoeda(), null, 0.0);
                        cofrinho.adicionar(dolar);
                        break;

                    case 2:
                        Console.WriteLine("Selecionado euro");
                        var euro = new Euro(valorMoeda(), null, 0.0);
                        cofrinho.adicionar(euro);
                        break;

                    case 3:
                        Console.WriteLine("Selecionado real");
                        var real = new Real(valorMoeda(), null, 0.0);
                        cofrinho.adicionar(real);
                        break;

                    default:
                        Console.WriteLine("Seleção inválida...");
                        break;
                }
                break;
            } while (select != 0);
        }

        // Novo método

        public void selecionaRemovida()
        { // Método criado para poupar tempo e repetição de código sem necessidade.
            int select;

            do
            {
                while (true)
                { // Laço para que só saia do bloco try quando inserido um dado válido.
                    try
                    {
                        Console.WriteLine("\nSelecione a moeda\n");
                        Console.WriteLine("1 - Dólar");
                        Console.WriteLine("2 - Euro");
                        Console.WriteLine("3 - Real");
                        Console.WriteLine("0 - Retornar ao menu principal");
                        Console.Write(">>> ");
                        select = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    { // Captura erro de input para evitar que sejam introduzidos
                      // caracteres que não sejam números inteiros e quebrar a
                      // aplicação.
                        Console.WriteLine("\nDigite apenas números inteiros!");
                    }
                }

                switch (select)
                {

                    case 0:
                        Console.WriteLine("Voltando ao menu anterior...");
                        break; // Encerra o loop e retorna.

                    case 1:
                        try
                        { // bloco try para evitar puxar moedas inexistentes no cofrinho e gerar alguma
                          // excessão que quebre o sistema.
                            Console.WriteLine("\nSelecionado dólar");
                            var valor = valorMoeda(); // invocação do método que seleciona o valor escolhido de moeda
                                                      // salva em uma variável local.
                            foreach (Moeda m in cofrinho.listaMoedas)
                            { // Laço para iterar na ArrayList cofrinho toda.
                                if (m is Dolar)
                                { // Capturando todo m que for objeto da classe Dolar.
                                    Dolar dolar = (Dolar)m; // Casting de n salvo na variável dolar.
                                    if (dolar.valor == valor)
                                    {
                                        cofrinho.listaMoedas.Remove(dolar);// Se o valor for igual, a moeda é removida.
                                        break; // Encerrando o laço para não remover uma segunda moeda que possua mesmo
                                               // valor.
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nOperação não permitida, tente novamente!");
                            break;
                        }
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("\nSelecionado euro");
                            var valor = valorMoeda(); // invocação do método que seleciona o valor escolhido de
                                                      // moeda e salva em uma variável local.
                            foreach (Moeda m in cofrinho.listaMoedas)
                            { // Laço para iterar na ArrayList cofrinho toda.
                                if (m is Euro)
                                { // Capturando todo m que for objeto da classe Euro.
                                    Euro euro = (Euro)m; // Casting de n salvo na variável euro.
                                    if (euro.valor == valor)
                                    { // Verficiar se o valor do euro iterado é o mesmo do valor
                                      // da variável local de nome valor.
                                        cofrinho.listaMoedas.Remove(euro);// Se o valor for igual, a moeda é removida.
                                        break; // Encerrando o laço para não remover uma segunda moeda que possua mesmo
                                               // valor.
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nNão existem moedas desse tipo & valor no cofrinho!");
                            break;
                        }
                        break;

                    case 3:

                        try
                        {
                            Console.WriteLine("\nSelecionado real");
                            var valor = valorMoeda(); // invocação do método que seleciona o valor escolhido de
                                                      // moeda e salva em uma variável local.
                            foreach (Moeda m in cofrinho.listaMoedas)
                            { // Laço para iterar na ArrayList cofrinho toda.
                                if (m is Real)
                                { // Capturando todo m que for objeto da classe Real.
                                    Real real = (Real)m; // Casting de n salvo na variável real.
                                    if (real.valor == valor)
                                    { // Verficiar se o valor do real iterado é o mesmo do valor
                                      // da variável local de nome valor.
                                        cofrinho.listaMoedas.Remove(real);// Se o valor for igual, a moeda é removida.
                                        break; // Encerrando o laço para não remover uma segunda moeda que possua mesmo
                                               // valor.
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nNão existem moedas desse tipo & valor no cofrinho!");
                            break;
                        }
                        break;

                    default:
                        Console.WriteLine("\nEntrada inválida");
                        break;
                }
                break;
            } while (select != 0);

        }

        public static double valorMoeda()
        {
            int valor;
            do
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nQual o valor da moeda?\n");
                        Console.WriteLine("1 - 0,10");
                        Console.WriteLine("2 - 0,25");
                        Console.WriteLine("3 - 0,50");
                        Console.WriteLine("4 - 1,00");
                        Console.Write(">>> ");

                        valor = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nDigite apenas números inteiros!");
                    }
                }
                switch (valor)
                {

                    case 1:
                        Console.WriteLine("\nrealziando transação...");
                        return 0.10;

                    case 2:
                        Console.WriteLine("\nrealziando transação...");
                        return 0.25;

                    case 3:
                        Console.WriteLine("\nrealziando transação...");
                        return 0.50;

                    case 4:
                        Console.WriteLine("\nrealziando transação...");
                        return 1;

                    default:
                        Console.WriteLine("\nOpção inválida, selecione um valor de moeda existente");
                        return 0;
                }

            } while (valor != 1 && valor != 2 && valor != 3 && valor != 4);
        }
    }
}