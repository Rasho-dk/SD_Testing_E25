using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop
{
    public interface IEShop
    {
        decimal GetShippingCosts();
        decimal GetDiscount();
        decimal GetSalary();
    }
}
