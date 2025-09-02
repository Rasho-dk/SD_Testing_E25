using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartridges
{
    public class Calcualte_Cartridges
    {
        public int cartridges { get; set; }
        private double discount = 0.0;

        public double Calculate_Discount(int cartridges)
        {
            if (cartridges < 5)
            {
                throw new ArgumentOutOfRangeException("The Minimum number of cartridges is 5");
            }
            if (cartridges >= 100)
            {
                return 0.2;  // 20% discount
            }

            return discount;
        }
    }
}
