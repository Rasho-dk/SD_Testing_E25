namespace E_shop
{
    public class DiscountCounter
    {
        private decimal discountRate;
        private const decimal lowerBound = 300.01m;
        private const decimal upperBound = 800.00m;
        private const decimal DiscountLowerBound = 0.05m;
        private const decimal DiscountUpperBound = 0.10m;
        private const decimal NoDiscount = 0.00m;

        private bool Between(decimal value, decimal lower, decimal upper)
        {
            return value >= lower && value <= upper;
        }
        public decimal CalculateDiscount(decimal totalAmount)
        {
            if(totalAmount <= 0)
            {
                throw new ArgumentException("Total amount must be greater than zero.");
            }
            if (totalAmount > upperBound)
            {
                discountRate = DiscountUpperBound;
            }
            else if (Between(totalAmount, lowerBound, upperBound))
            {
                discountRate = DiscountLowerBound; 
            }
            else
            {
                discountRate = NoDiscount; 
            }
            return discountRate;
        }
    }
}
