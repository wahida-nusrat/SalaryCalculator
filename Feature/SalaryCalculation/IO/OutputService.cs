using SalaryCalculation.Models;
using SalaryCalculator.Foundation.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculation.IO
{
    public class OutputService
    {
        public void Dispaly(SingleTaxPayer taxPayer)
        {
            // convert all value in currency format
            Console.WriteLine("Gross Package: " + taxPayer.GrossSalary.ToString("C"));
            Console.WriteLine("Superannumation: " + taxPayer.SuberContribution.ToString("C"));
            Console.WriteLine("Taxable income: " + taxPayer.TaxableIncome.ToString("C"));
            Console.WriteLine("Deductions");
            // get the deductions name like medical levy, budget repeair levy, income tax from object
            foreach (var item in taxPayer.TaxableDeductions)
            {
                Console.WriteLine(item.DeductionName + ": " + item.DeductionAmount.ToString("C"));
            }
            Console.WriteLine("Net income: " + taxPayer.NetIncome.ToString("C"));
            Console.WriteLine("Pay packet: " + taxPayer.PayPacket);
        }

    }
}
