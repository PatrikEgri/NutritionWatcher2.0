using Microsoft.AspNet.Identity;
using NutritionWatcher2._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NutritionWatcher2._0.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {
        ApplicationDbContext _dataContext;

        public FoodController()
        {
            _dataContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _dataContext != null)
            {
                _dataContext.Dispose();
                _dataContext = null;
            }

            base.Dispose(disposing);
        }

        // GET: Food
        public ViewResult NewFood()
        {
            return View(new FoodModel());
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewFood(FoodModel food)
        {
            if (!ModelState.IsValid)
                return View("NewFood", food);

            string id = User.Identity.GetUserId();
            food.Owner = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
            _dataContext.Foods.Add(food);
            await _dataContext.SaveChangesAsync();

            return RedirectToAction("ViewFoods");
        }

        public ViewResult ViewFoods()
        {
            if (User.IsInRole("Admin"))
                return View();

            return View("MemberViewFoods");
        }

        public async Task<ViewResult> EditFood(int id)
        {
            return View(await _dataContext.Foods.FirstOrDefaultAsync(x => x.Id.Equals(id)));
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditFood(FoodModel food)
        {
            if (!ModelState.IsValid)
                return View(food);

            FoodModel foodInDb = await _dataContext.Foods.FirstOrDefaultAsync(x => x.Id.Equals(food.Id));
            foodInDb.Name = food.Name;
            foodInDb.ProteinAmount = food.ProteinAmount;
            foodInDb.FatAmount = food.FatAmount;
            foodInDb.HydrocarbonateAmount = food.HydrocarbonateAmount;
            foodInDb.Gramm = food.Gramm;

            await _dataContext.SaveChangesAsync();

            return RedirectToAction("ViewFoods");
        }
    }
}