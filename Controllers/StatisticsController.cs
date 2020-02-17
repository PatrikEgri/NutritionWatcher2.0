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
    public class StatisticsController : Controller
    {
        ApplicationDbContext _dataContext;

        public StatisticsController()
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

        // GET: Statistics
        public async Task<ViewResult> CalorieConsumption()
        {
            string id = User.Identity.GetUserId();
            return View(new StatisticViewModel
            {
                Consumptions = await _dataContext.Consumptions.Include(x => x.Owner).Where(x => x.Owner.Id.Equals(id)).ToListAsync(),
                Assignments = await _dataContext.Assignments
                                        .Include(x => x.Consumption)
                                        .Include(x => x.Consumption.Owner)
                                        .Include(x => x.Food)
                                        .Where(x => x.Consumption.Owner.Id.Equals(id))
                                        .ToListAsync()
            });
        }

        public async Task<ViewResult> ProteinConsumption()
        {
            string id = User.Identity.GetUserId();
            return View(new StatisticViewModel
            {
                Consumptions = await _dataContext.Consumptions.Include(x => x.Owner).Where(x => x.Owner.Id.Equals(id)).ToListAsync(),
                Assignments = await _dataContext.Assignments
                                        .Include(x => x.Consumption)
                                        .Include(x => x.Consumption.Owner)
                                        .Include(x => x.Food)
                                        .Where(x => x.Consumption.Owner.Id.Equals(id))
                                        .ToListAsync()
            });
        }

        public async Task<ViewResult> FatConsumption()
        {
            string id = User.Identity.GetUserId();
            return View(new StatisticViewModel
            {
                Consumptions = await _dataContext.Consumptions.Include(x => x.Owner).Where(x => x.Owner.Id.Equals(id)).ToListAsync(),
                Assignments = await _dataContext.Assignments
                                        .Include(x => x.Consumption)
                                        .Include(x => x.Consumption.Owner)
                                        .Include(x => x.Food)
                                        .Where(x => x.Consumption.Owner.Id.Equals(id))
                                        .ToListAsync()
            });
        }

        public async Task<ViewResult> HydrocarbonateConsumption()
        {
            string id = User.Identity.GetUserId();
            return View(new StatisticViewModel
            {
                Consumptions = await _dataContext.Consumptions.Include(x => x.Owner).Where(x => x.Owner.Id.Equals(id)).ToListAsync(),
                Assignments = await _dataContext.Assignments
                                        .Include(x => x.Consumption)
                                        .Include(x => x.Consumption.Owner)
                                        .Include(x => x.Food)
                                        .Where(x => x.Consumption.Owner.Id.Equals(id))
                                        .ToListAsync()
            });
        }

        public async Task<ViewResult> MealCount()
        {
            string id = User.Identity.GetUserId();
            return View(new StatisticViewModel
            {
                Consumptions = await _dataContext.Consumptions.Include(x => x.Owner).Where(x => x.Owner.Id.Equals(id)).ToListAsync(),
                Assignments = await _dataContext.Assignments
                                        .Include(x => x.Consumption)
                                        .Include(x => x.Consumption.Owner)
                                        .Include(x => x.Food)
                                        .Where(x => x.Consumption.Owner.Id.Equals(id))
                                        .ToListAsync()
            });
        }

        public async Task<ViewResult> Summary()
        {
            string id = User.Identity.GetUserId();
            return View(new StatisticViewModel
            {
                Consumptions = await _dataContext.Consumptions.Include(x => x.Owner).Where(x => x.Owner.Id.Equals(id)).ToListAsync(),
                Assignments = await _dataContext.Assignments
                                        .Include(x => x.Consumption)
                                        .Include(x => x.Consumption.Owner)
                                        .Include(x => x.Food)
                                        .Where(x => x.Consumption.Owner.Id.Equals(id))
                                        .ToListAsync()
            });
        }
    }
}