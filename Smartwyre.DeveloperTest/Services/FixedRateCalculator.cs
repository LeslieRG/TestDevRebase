using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services
{
    public class FixedRateCalculator : IRebateCalculator
    {
        public bool IsValid(Rebate rebate, Product product)
        {
            return rebate != null && product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate);
        }

        public decimal CalculateRebate(Rebate rebate, Product product, decimal volume)
        {
            return product.Price * rebate.Percentage * volume;
        }
    }
}
