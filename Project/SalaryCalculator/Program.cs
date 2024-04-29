using SalaryCalculation.IO;
using SalaryCalculation.Service;
using SalaryCalculator.Foundation.IoC;

var serviceProvider = Container.Register();
var calculationService = Container.GetService<CalculatorService>(serviceProvider);
mainService();


void mainService()
{
    // take input for gross salary and pay freequency
    var inputServic = new InputService();
    var userInput = inputServic.UserInput();
    var taxPayer = calculationService.Calculaton(userInput);

    // display income details
    var outputService = new OutputService();
    outputService.Dispaly(taxPayer);

    Console.WriteLine("Do you want to continue another calculation? (y/n)");
    string cont = Console.ReadLine();
    if (cont.ToLower() == "y")
    {
        mainService();
    }

}


