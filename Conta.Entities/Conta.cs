using System;

namespace Conta.Entities
{
    public class Conta
    {
        public string NomeTitular { get; set; }
        public int NumeroConta { get; set; }
        public double PrimeiroDeposito { get; set; }
        public double Saldo { get; private set; }

        public bool Sacar(double valor)
        {
            bool podeSacar = !(this.Saldo < valor);
            this.Saldo = podeSacar ? this.Saldo - valor : this.Saldo = this.Saldo;
            return podeSacar;
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;
        }
    }
}
