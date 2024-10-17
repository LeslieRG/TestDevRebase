using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Interfaces
{
    public interface IRebateCalculator
    {
        bool IsValid(Rebate rebate, Product product);
        decimal CalculateRebate(Rebate rebate, Product product, decimal volume);
    }
}
