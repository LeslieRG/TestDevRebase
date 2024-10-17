using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;
using Smartwyre.DeveloperTest.Interfaces;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
   private readonly IRebateDataStore _rebateDataStore;
    private readonly IProductDataStore _productDataStore;
    private readonly IEnumerable<IRebateCalculator> _calculators;

    public RebateService(
        IRebateDataStore rebateDataStore, 
        IProductDataStore productDataStore, 
        IEnumerable<IRebateCalculator> calculators)
    {
        _rebateDataStore = rebateDataStore;
        _productDataStore = productDataStore;
        _calculators = calculators;
    }

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        var rebate = _rebateDataStore.GetRebate(request.RebateIdentifier);
        var product = _productDataStore.GetProduct(request.ProductIdentifier);
        var result = new CalculateRebateResult();

        if (rebate == null || product == null)
        {
            result.Success = false;
            return result;
        }

        var calculator = _calculators.FirstOrDefault(c => c.IsValid(rebate, product));
        
        if (calculator == null)
        {
            result.Success = false;
            return result;
        }

        var rebateAmount = calculator.CalculateRebate(rebate, product, request.Volume);
        
        _rebateDataStore.StoreCalculationResult(rebate, rebateAmount);
        
        result.Success = true;
        return result;
    }
}
