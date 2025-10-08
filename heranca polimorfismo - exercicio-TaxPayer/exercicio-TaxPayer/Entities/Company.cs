namespace exercicio_TaxPayer.Entities
{
    class Company : TaxPayer
    {
        public int NumberOfEmployess { get; set; }

        public Company(string name, double anualIncome, int numberOfEmployess) 
            : base(name, anualIncome)
        {
            NumberOfEmployess = numberOfEmployess;
        }

        public override double Tax()
        {
            if (NumberOfEmployess > 10)
            {
                return AnualIncome * 0.14;
            }
            else
            {
                return AnualIncome * 0.16;
            }
        }
    }
}
