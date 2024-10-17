using Autofac;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Runner
{
    public class AutofacContainerSetup
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            // Register the data stores as their interfaces
            builder.RegisterType<RebateDataStore>().As<IRebateDataStore>();
            builder.RegisterType<ProductDataStore>().As<IProductDataStore>();

            // Register incentive calculators as their interface
            builder.RegisterType<FixedCashAmountCalculator>().As<IRebateCalculator>();
            builder.RegisterType<FixedRateCalculator>().As<IRebateCalculator>();
            builder.RegisterType<AmountPerUomCalculator>().As<IRebateCalculator>();

            // Register the RebateService
            builder.RegisterType<RebateService>().As<IRebateService>();

            // Build the container
            return builder.Build();
        }
    }
}
