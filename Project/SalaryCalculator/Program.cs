using SalaryCalculation.IO;
using SalaryCalculator.Foundation.IoC;


var calculationService = Container.Register();
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


