using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heranca_polimorfismo_exemplo_account.Entities
{
    class Account
    {
        public int Number { get; private set; }
        public string Holder { get; private set; }
        public double Balance { get; protected set; }

        public Account() 
        {
        }
        
        public Account(int number, string holder, double balance)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
        }

        //Operações de Saque(Withdraw) e Depósito(Deposit) 
        public virtual void Withdraw(double amount)
        //amount(quantia) que entra como parametro do saque(Withdraw) é retirado do Balance(saldo)    
        {
            Balance -= amount + 5.0;
        }

        public void Deposit (double amount)
        { 
            Balance += amount; 
        }
    }
}