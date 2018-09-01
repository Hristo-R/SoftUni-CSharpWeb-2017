namespace FDMC.App.Controllers
{
    using FDMC.App.Models.ViewModels;
    using FDMC.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class HomeController : Controller
    {
        public HomeController(CatContext context)
        {
            this.Context = context;
        }

        public CatContext Context { get; set; }

        public IActionResult Index()
        {
            var cats = this.Context
                .Cats
                .Select(cat => new CatConciseViewModel()
                {
                    Id = cat.Id,
                    Name = cat.Name
                })
                .ToArray();

            return View(model: cats);
        }
    }
}