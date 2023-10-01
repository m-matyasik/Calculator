using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Calculator(CalculatorModel calc, string calculate)
        {
            if (calculate == "add") calc.result = calc.firstNumber + calc.secondNumber;
            if (calculate == "sub") calc.result = calc.firstNumber - calc.secondNumber;
            if (calculate == "mul") calc.result = calc.firstNumber * calc.secondNumber;
            if (calculate == "div")
            {
                if (calc.secondNumber == 0)
                {
                    ViewBag.DivisionByZeroError = "You can't divide by zero!";
                }
                else calc.result = calc.firstNumber / calc.secondNumber;
            }

            ViewBag.result = $"{calc.firstNumber} + {calc.secondNumber} = {calc.result}";

            return View(calc);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}