using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore : IProductDataStore
{
    private readonly Dictionary<string, Product> _productDatabase = new Dictionary<string, Product>
    {
        { "PRODUCT123", new Product { Identifier = "PRODUCT123", Price = 50, SupportedIncentives = SupportedIncentiveType.FixedCashAmount | SupportedIncentiveType.FixedRateRebate } },
        { "PRODUCT456", new Product { Identifier = "PRODUCT456", Price = 30, SupportedIncentives = SupportedIncentiveType.AmountPerUom } },
        { "APPLE001", new Product { Identifier = "APPLE001", Price = 1.50m, SupportedIncentives = SupportedIncentiveType.FixedRateRebate } }, 
        { "BANANA002", new Product { Identifier = "BANANA002", Price = 0.75m, SupportedIncentives = SupportedIncentiveType.AmountPerUom } },  
        { "ORANGE003", new Product { Identifier = "ORANGE003", Price = 1.00m, SupportedIncentives = SupportedIncentiveType.FixedCashAmount } },  
        { "MANGO004", new Product { Identifier = "MANGO004", Price = 2.00m, SupportedIncentives = SupportedIncentiveType.FixedRateRebate | SupportedIncentiveType.AmountPerUom } },
        { "PINEAPPLE005", new Product { Identifier = "PINEAPPLE005", Price = 3.50m, SupportedIncentives = SupportedIncentiveType.FixedCashAmount } } 
    };

    public Product GetProduct(string productIdentifier)
    {
        // Return the product if it exists in the mock storage, otherwise null
        return _productDatabase.ContainsKey(productIdentifier) ? _productDatabase[productIdentifier] : null;
    }
}
