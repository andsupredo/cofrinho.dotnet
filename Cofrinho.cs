using System;
using System.Collections;

namespace Cofrinho
{
    class Cofrinho
    {
        public List<Moeda> listaMoedas = new List<Moeda>();


        public void adicionar(Moeda moeda)
        {
            listaMoedas.Add(moeda);
            Console.WriteLine("Adicionando $" + moeda.valor + " " + moeda.nome + " ao cofrinho.");
            Thread.Sleep(1000);
        }

        public void remover(Moeda moeda)
        {
            listaMoedas.Remove(moeda);
            Thread.Sleep(1500);
        }

        public void listagemMoedas()
        {
            Console.WriteLine();
            Console.WriteLine("Lista de moedas:");
            foreach (Moeda m in listaMoedas)
            {
                Console.WriteLine(m);
                Thread.Sleep(1500);
            }
        }

        public void totalConvertido()
        {
            double soma = 0;
            foreach (Moeda m in listaMoedas)
            {
                soma += ((Moeda)m).converter();
            }
            Console.WriteLine("Total convertido em R$: ", soma);
            Thread.Sleep(1500);
        }
    }
}