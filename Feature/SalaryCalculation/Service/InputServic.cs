using SalaryCalculation.Models;

namespace SalaryCalculation.Service
{
    public class InputServic
    {
        private int _grossSalary;
        private string _payFreequency;
        public Input UserInput()
        {
            Input userInput = new Input();
            Console.WriteLine("Enter gross salary");
            // validation for gross income 
            SalaryValidation();
            userInput.GrossSalary = _grossSalary;
            Console.WriteLine("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly):");
            PayFreequencyValidation();
            userInput.PayFreequency= _payFreequency;
            return userInput;
        }
        private void SalaryValidation()
        {
            int salary;
            string grossSalary = Console.ReadLine();
            // will check any invalid input like string, combination of number and string
            // it will also check out of range value
            // check for negative salary as well
            if (int.TryParse(grossSalary, out salary) && salary>=0)
            {
                 _grossSalary = salary;
            }
            else
            {
                Console.WriteLine("Please enter valid salary again");
                SalaryValidation();
            }
        }
        private void PayFreequencyValidation()
        {
            string payFreequency = Console.ReadLine();
            // validate if any input without upper and lower case of w, f and m
            if(payFreequency.ToLower() == "w" || payFreequency.ToLower() != "f" || payFreequency.ToLower() != "m")
            {
                _payFreequency = payFreequency;
            }
            else
            {
                Console.WriteLine("Enter correct your pay frequency again (W for weekly, F for fortnightly, M for monthly):");
                PayFreequencyValidation();
            }
        }
    }
}
