using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heranca_polimorfismo_exemplo_account.Entities
{
    class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        public SavingsAccount() 
        {
        }

        public SavingsAccount(int number, string holder, double balance, double interestRate)
            : base(number, holder, balance) 
        //construtor SavingsAccount herdando contrutor Account 
        {
            InterestRate = interestRate;
        }

        public void UpdateBalance() 
        {
            Balance += Balance * InterestRate;
        }

        public override void Withdraw(double amount)
        {
            //reutilizando metodo de saque de Account com a palavra base e colocando outras regras se necessário
            base.Withdraw(amount);
            Balance -= 2.00;
            //codigo anterior
            //Balance -= amount;
        }
    }
}