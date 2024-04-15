using Logging.Interface;
using Microsoft.Extensions.Configuration;
using SalaryCalculation.Models;
using SalaryCalculaton.Services.Interface;

namespace SalaryCalculaton.Services.Implementation
{
    public class IncomeCalculation : IIncomeCalculation
    {
        private readonly IConfiguration _configuration;
        const string _taxableDeductionConfigSection = "TaxableDeduction";
        const string _payFreequencyConfiguration = "PayFreequency";
        private decimal _taxableIncome;
        private readonly Ilogger _logger;
        public IncomeCalculation(IConfiguration configuration, Ilogger logger) 
        {
            _configuration = configuration;
            _logger = logger;
        }
        public decimal CalculateSuper(int grossSalary)
        {
            decimal super = 0;
            try
            {
                // throwing and logging error for negative out of range
                if (grossSalary < 0)
                {
                    throw new Exception("OverflowException");
                }
                // get super rate from config
                string? superRatestring = _configuration.GetSection("Super:Rate")?.Value;
                decimal superRate = string.IsNullOrEmpty(superRatestring) ? 0: Convert.ToDecimal(superRatestring);
                super = Math.Round((grossSalary / (1 + superRate) * superRate * 100) / 100, 2);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    _logger.Error(ex.InnerException.ToString());
                }
                else
                {
                    _logger.Error(ex.ToString());
                    throw;
                }
            }
            return super;
        }
        public decimal CalculateTaxableIncome(int grossSalary, decimal super)
        {
            decimal taxableIncome = 0;
            taxableIncome = Math.Round((grossSalary - super), 2);
            return taxableIncome;
        }
        public decimal CaclulateNetIncome(decimal grossIncome, decimal super, decimal taxableDeductions)
        {
            decimal netIncome = 0;
            netIncome= grossIncome - (super + taxableDeductions);
            return netIncome;
        }
        public string CalculatePayPacket(string payFreequency, decimal netIncome)
        {
            string payPacket=string.Empty;
            var payPocketConfigurations = _configuration.GetSection(_payFreequencyConfiguration)?.GetChildren()?.ToList();
            if (payPocketConfigurations != null)
            {
                var payPocketModel = new PayPacket();
                foreach (var payPocketConfig in payPocketConfigurations)
                {
                    // take the pay packet config as per user input 
                    if(payPocketConfig.Key.ToLower()==payFreequency.ToLower())
                    {
                        payPocketModel.PayFreequency = payPocketConfig.Key;
                        payPocketModel.NoOfPayPerYear = Convert.ToInt32(payPocketConfig.GetSection("NoOfPayPerYear").Value);
                        payPocketModel.PayFreequencyName = payPocketConfig.GetSection("DisplayFreequency").Value;
                        break;    
                    }
                }
                payPacket = buildPayPacketAsString(payPocketModel, netIncome);
            }
            return payPacket;
        }

        private string buildPayPacketAsString(PayPacket payPacket, decimal netIncome)
        {
            decimal pay = Math.Round((netIncome / payPacket.NoOfPayPerYear), 2);
            return string.Concat(pay.ToString("C"), " ", payPacket.PayFreequencyName);
        }
        public List<TaxableDeduction>? GetTaxableDeductions(decimal taxableIncome)
        {
            _taxableIncome = taxableIncome;
            var taxableDeductionConfiguration = _configuration.GetSection(_taxableDeductionConfigSection)?.GetChildren()?.ToList();
            if (taxableDeductionConfiguration != null)
            {
                List<TaxableDeduction> taxableDeductions = new List<TaxableDeduction>();
                // get all taxable deduction(medical levy, budget repair levy, income tax) from config file
                // and mapp it to  object
                foreach (var taxableDeductionConfig in taxableDeductionConfiguration)
                {
                    var taxableDeduction = new TaxableDeduction();
                    taxableDeduction.DeductionName = taxableDeductionConfig.Key;
                    taxableDeduction.DeductionAmount = CalculateDeduction(taxableDeduction.DeductionName);
                    taxableDeductions.Add(taxableDeduction);
                }
                return taxableDeductions;
            }
            return null;
        }
        private int CalculateDeduction(string deductionName)
        {
            int deduction = 0;
            try
            {
                // get setting name 
                string deductionIncomeSetting = string.Concat(_taxableDeductionConfigSection, ":", deductionName, ":IncomeTier");
                string deductionRateSetting = string.Concat(_taxableDeductionConfigSection, ":", deductionName, ":Rate");
                string deductionExtraTaxSetting = string.Concat(_taxableDeductionConfigSection, ":", deductionName, ":ExtraTax");

                // get income tier and rate value from config
                int[]? incomeTiers = _configuration.GetSection(deductionIncomeSetting)?
                        .GetChildren()?.Select(x => Convert.ToInt32(x.Value)).ToArray();
                decimal[]? rate = _configuration.GetSection(deductionRateSetting)?
                        .GetChildren()?.Select(x => Convert.ToDecimal(x.Value)).ToArray();
                int[]? extraTaxTier = _configuration.GetSection(deductionExtraTaxSetting)?
                                        .GetChildren()?.Select(x => Convert.ToInt32(x.Value)).ToArray();

                // Determine which tier taxable income is and calculate the rate accordingly
                int extraTax;
                if (incomeTiers != null && rate != null && incomeTiers.Length > 0 && rate.Length > 0)
                {
                    for (int index = 1; index < incomeTiers.Length; index++)
                    {
                        if (_taxableIncome >= incomeTiers[index - 1] + 1 && _taxableIncome <= incomeTiers[index])
                        {
                            // exception in income excess in medical levy and heighest tier 
                            int incomeExcess = (index == incomeTiers.Length - 1 && deductionName == "MedicalLevy") ? 0 : incomeTiers[index - 1];
                            deduction = (int)Math.Ceiling((_taxableIncome - incomeExcess) * rate[index - 1] / 100);
                            //income tax has extra tax amount except for firat two tier
                            // cofig 0 for extra tax for first two tier
                            // for other deduction like medical levy, ExtraTaxTier will be empty, so it will be 0
                            extraTax= extraTaxTier.Length > 0  ? extraTaxTier[index-1] : 0;
                            deduction = deduction + extraTax;
                            break;
                        }

                    }
                    
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }
            return deduction;
        }
        public decimal CalculateDeductions(List<TaxableDeduction> taxableDeductions)
        {
            decimal taxableDeductionAmount = 0;
            taxableDeductionAmount = taxableDeductions.Sum(item => item.DeductionAmount);
            return taxableDeductionAmount;
        }
    }
}
