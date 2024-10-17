using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services
{
    public class FixedCashAmountCalculator : IRebateCalculator
    {

        public decimal CalculateRebate(Rebate rebate, Product product, decimal volume)
        {
            return rebate.Amount;
        }

        public bool IsValid(Rebate rebate, Product product)
        {
            return rebate != null && product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount);
        }
    }
}
