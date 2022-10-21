using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofrinho
{
    public abstract class Moeda
    {
        public double valor { get; set; }
        public string nome { get; set; }

        public double cotacao { get; set; }

        public Moeda(double valor, string nome, double cotacao)
        {
            this.valor = valor;
            this.nome = nome;
            this.cotacao = cotacao;
        }

        public abstract void info();

        public abstract double converter();

    }
}