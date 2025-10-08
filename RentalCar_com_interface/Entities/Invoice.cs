using System.Globalization;

namespace RentalCar_com_interface.Entities
{
    class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public double TotalPaymet
        {
            get { return BasicPayment + Tax; }
        }

        public override string ToString()
        {
            return "Basic Payment: "
                + BasicPayment.ToString("F2", CultureInfo.InvariantCulture)
                + "\nTax: "
                + Tax.ToString("F2", CultureInfo.InvariantCulture)
                + "\nTotal payment: "
                + TotalPaymet.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}