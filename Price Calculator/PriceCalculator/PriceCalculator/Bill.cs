using System;

namespace Price_Calculator
{
    [Serializable]

    ///<summary>
    ///this file handles the calculations
    ///</summary>
    class Bill
    {
        private decimal price;
        private decimal tax;
        private decimal tip;
        private string resturant;
        private string date;

        //using decimal for we are caclulating with decimal points
        public Bill(decimal Price, decimal Tax, decimal Tip, string Resturant, string Date)
        {
            price = Price;
            tax = Tax;
            tip = Tip;
            resturant = Resturant;
            date = Date;
        }

        public decimal Price
        {
            get { return price; }
        }

        public decimal Tax
        {
            get { return tax; }
        }

        public decimal Tip
        {
            get { return tip; }
        }

        public string Resturant
        {
            get { return resturant; }
        }

        public string Date
        {
            get { return date;  }
        }

        public decimal Total
        {
            get { return Math.Round(price + (price * tax / 100) + (price * tip / 100), 2); }
        }
    }
}
