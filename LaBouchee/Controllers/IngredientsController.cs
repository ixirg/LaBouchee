using LaBouchee.DAL;
using LaBouchee.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaBouchee.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IngredientsDbContext _context;

        public IngredientsController(IngredientsDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ingredients=_context.Ingredients.ToList();
            List<IngredientsViewModel> ingredientList = new List<IngredientsViewModel>();

            if (ingredients != null)
            {

                foreach(var ingredient in ingredients)
                {
                    var IngredientsViewModel = new IngredientsViewModel()
                    {
                        Id = ingredient.Id,
                        Ingredient=ingredient.Ingredient,
                        Description=ingredient.Description
                    };
                    ingredientList.Add(IngredientsViewModel);
                }
                return View(ingredientList);
            }
            return View(ingredientList);

        }
    }
}
