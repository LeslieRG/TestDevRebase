using System;
using System.Reflection.Metadata;
using Autofac;
using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        var container = AutofacContainerSetup.Configure();
        using (var scope = container.BeginLifetimeScope())
        {
            var rebateService = scope.Resolve<IRebateService>();

            Console.WriteLine("Enter Product Identifier: ");
            var productIdentifier = Console.ReadLine();

            Console.WriteLine("Enter Rebate Identifier: ");
            var rebateIdentifier = Console.ReadLine();

            Console.WriteLine("Enter Volume: ");
            var volumeInput = Console.ReadLine();

            if (!decimal.TryParse(volumeInput, out decimal volume))
            {
                Console.WriteLine("Invalid volume. Please enter a valid decimal number.");
                return;
            }

            var request = new CalculateRebateRequest
            {
                ProductIdentifier = productIdentifier,
                RebateIdentifier = rebateIdentifier,
                Volume = volume
            };

            var result = rebateService.Calculate(request);

            if (result.Success)
            {
                Console.WriteLine("Rebate calculation successful!");
            }
            else
            {
                Console.WriteLine("Rebate calculation failed.");
            }
        }
    }
}
