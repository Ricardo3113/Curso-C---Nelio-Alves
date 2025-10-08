using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heranca_polimorfismo_exemplo_account.Entities
{
    class BusinessAccount : Account
    {
        public double LoanLimit { get; set; }        

        public BusinessAccount()
        {
        }
        public BusinessAccount(int number, string holder, double balance, double loanLimit) 
            : base (number, holder, balance) 
        //construtor da subclasse reutilizando construtores da classe base Account
        {
            LoanLimit = loanLimit;
        }
        //implementação da operação empréstimo Loan 
        public void Loan (double amount)
        {
            if (amount <= LoanLimit)
            {
                Balance += amount;
            }
        }
    } 
}
