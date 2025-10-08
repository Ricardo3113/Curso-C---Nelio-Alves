namespace exercicio_TaxPayer.Entities
{
    abstract class TaxPayer
    {
        public string Name { get; set; }
        public double AnualIncome { get; set; }

        public TaxPayer() 
        {
        }

        protected TaxPayer(string name, double anualIncome)
        {
            Name = name;
            AnualIncome = anualIncome;
        }
        //apenas chamada da função Tax,
        //pq possui atributos diferentes de cada tipo de tax   
        //na verdade, a operação será feita por cada tipo, exemplo
        //individual tem um tipo de tax
        //company tem outro tipo de tax
        //por isso, na superclasse só faz a chamada 
        //da função
        public abstract double Tax();        
    }
}
