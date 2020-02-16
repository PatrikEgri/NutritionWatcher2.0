using Microsoft.AspNet.Identity;
using NutritionWatcher2._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace NutritionWatcher2._0.Controllers
{
    [Authorize]
    public class ConsumptionController : Controller
    {
        ApplicationDbContext _dataContext;

        public ConsumptionController()
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

        // GET: Consumption
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult NewConsumption()
        {
            return View();
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewConsumption(SaveConsumptionViewModel consumption)
        {
            if (!ModelState.IsValid)
                return View(consumption);

            string id = User.Identity.GetUserId();
            ConsumptionModel con = new ConsumptionModel
            {
                Owner = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id.Equals(id)),
                Date = consumption.Date.ToString("yyyy-MM-dd"),
                Time = consumption.Time.ToString("HH:mm")               
            };

            _dataContext.Consumptions.Add(con);
            await _dataContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<ViewResult> EditConsumption(int id)
        {
            ConsumptionModel consumption = await _dataContext.Consumptions.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return View(new SaveConsumptionViewModel 
            { 
                Id = consumption.Id,
                Date = DateTime.Parse(consumption.Date),
                Time = DateTime.Parse($"1999-12-31 {consumption.Time}:00")
            });
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditConsumption(SaveConsumptionViewModel consumption)
        {
            if (!ModelState.IsValid)
                return View(consumption);

            ConsumptionModel consumptionInDb = await _dataContext.Consumptions.FirstOrDefaultAsync(x => x.Id.Equals(consumption.Id));
            consumptionInDb.Date = consumption.Date.ToString("yyyy-MM-dd");
            consumptionInDb.Time = consumption.Time.ToString("HH:mm");

            await _dataContext.SaveChangesAsync();

            return RedirectToAction("Index");
        } 

        public async Task<ViewResult> Assign()
        {
            string id = User.Identity.GetUserId();
            return View(await _dataContext.Consumptions.Include(x => x.Owner).Where(x => x.Owner.Id.Equals(id)).ToListAsync());
        }

        public async Task<ViewResult> Assignments(int id)
        {
            string userId = User.Identity.GetUserId();
            return View(new AssignmentsViewModel
            {
                Assignments = await _dataContext.Assignments
                                .Include(x => x.Consumption)
                                .Include(x => x.Consumption.Owner)
                                .Include(x => x.Food)
                                .Where(x => x.Consumption.Id.Equals(id) && x.Consumption.Owner.Id.Equals(userId))
                                .ToListAsync(),
                Consumption = await _dataContext.Consumptions.FirstOrDefaultAsync(x => x.Id.Equals(id))
            });
        }
    }
}