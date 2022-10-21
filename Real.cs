using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofrinho
{
    public class Real : Moeda
    {

        public Real(double valor, string nome, double cotacao) : base(valor, nome, cotacao)
        {
            valor = 0;
            nome = "Real";
            cotacao = 1;
        }

        public override void info()
        {
            Console.WriteLine("Valor da cotação do " + nome + " no dia 14/10/2022: R$" + cotacao);
        }

        public override double converter()
        {
            return valor * cotacao;
        }

        public override string ToString()
        {
            return "Real: " + valor;
        }



    }
}