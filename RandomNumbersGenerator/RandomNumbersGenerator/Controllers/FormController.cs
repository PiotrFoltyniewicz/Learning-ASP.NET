using Microsoft.AspNetCore.Mvc;
using RandomNumbersGenerator.Models;

namespace RandomNumbersGenerator.Controllers
{
    public class FormController : Controller
    {
        [HttpPost]
        public IActionResult GenerateNumbers(FormModel model)
        {
            Random rnd = new Random();
            List<int> temp = new List<int>();
            for(int i = 0; i < model.numberOfDices; i++)
            {
                temp.Add(rnd.Next(1, model.range + 1));
            }
            GeneratedNumbers generatedNumbers = new GeneratedNumbers(temp);
            return Result(generatedNumbers);
        }

        public IActionResult Result(GeneratedNumbers model)
        {
            return View("Views/Home/Result.cshtml", model);
        }
    }

}
