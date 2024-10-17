using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services
{
    public class AmountPerUomCalculator : IRebateCalculator
    {
        public bool IsValid(Rebate rebate, Product product)
        {
            return rebate != null && product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom);
        }

        public decimal CalculateRebate(Rebate rebate, Product product, decimal volume)
        {
            return rebate.Amount * volume;
        }
    }
}
