namespace RentalCar_com_interface.Services
{
    class BrazilTaxService : ITaxService  //o : não é herança é implemtação de interface
    {
        public double Tax(double amount)
        {
            if (amount <= 100.0)
            {
                return amount * 0.2;
            }
            else
            {
                return amount * 0.15;
            }
        }
    }
}
