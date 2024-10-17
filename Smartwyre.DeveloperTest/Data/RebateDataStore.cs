using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System;
using Smartwyre.DeveloperTest.Interfaces;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore: IRebateDataStore
{
    private readonly Dictionary<string, Rebate> _rebateDatabase = new Dictionary<string, Rebate>
    {
        { "REBATE123", new Rebate { Identifier = "REBATE123", Amount = 100, Incentive = IncentiveType.FixedCashAmount } },
        { "REBATE456", new Rebate { Identifier = "REBATE456", Percentage = 0.1m, Incentive = IncentiveType.FixedRateRebate } }
    };

    public Rebate GetRebate(string rebateIdentifier)
    {
        return _rebateDatabase.ContainsKey(rebateIdentifier) ? _rebateDatabase[rebateIdentifier] : null;
    }

    public void StoreCalculationResult(Rebate rebate, decimal rebateAmount)
    {
        Console.WriteLine($"Rebate calculation stored: Rebate ID {rebate.Identifier}, Amount: {rebateAmount}");
    }
}
