using dailybook.Models;
using dailybook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dailybook.Models.ViewComponents
{
    public class CategoryMenuViewComponent :ViewComponent
    {
        private readonly DailybookContext db;
        public CategoryMenuViewComponent(DailybookContext context) => db = context;

        public IViewComponentResult Invoke()
        {
            var data = db.Categories.Select(cat => new CategoryMenuVM
            {
                Id = cat.CatId,
                Name = cat.CatName,
                Number = cat.Products.Count
            }
            );
            return View(data);
        }
    }
}
