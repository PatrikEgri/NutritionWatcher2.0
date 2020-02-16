using Microsoft.AspNet.Identity;
using NutritionWatcher2._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NutritionWatcher2._0.Controllers.api
{
    public class ConsumptionController : ApiController
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

        [HttpGet]
        public ConsumptionModel GetConsumption(int id)
        {
            ConsumptionModel consumption = _dataContext.Consumptions.FirstOrDefault(x => x.Id.Equals(id));

            if (consumption == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return consumption;
        }

        [HttpGet]
        public IEnumerable<ConsumptionModel> GetConsumptions()
        {
            string id = User.Identity.GetUserId();
            return _dataContext.Consumptions.Include(x => x.Owner).Where(x => x.Owner.Id.Equals(id)).ToList();
        }

        [HttpDelete]
        public async Task DeleteConsumption(int id)
        {
            ConsumptionModel consumption = await _dataContext.Consumptions.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (consumption == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dataContext.Consumptions.Remove(consumption);
            await _dataContext.SaveChangesAsync();
        }

        [HttpPut]
        public async Task UpdateConsumption(int id, ConsumptionModel consumption)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            ConsumptionModel consumptionInDb = await _dataContext.Consumptions.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (consumptionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            consumptionInDb.Date = consumption.Date;
            consumptionInDb.Time = consumption.Time;

            await _dataContext.SaveChangesAsync();
        }

        [HttpPost]
        public async Task<ConsumptionModel> CreateConsumption(ConsumptionModel consumption)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _dataContext.Consumptions.Add(consumption);
            await _dataContext.SaveChangesAsync();

            return consumption;
        }

        [HttpPost]
        public async Task<ConsumptionModel> CreateAssign(int id1, int id2, int id3)
        {
            FoodModel food = await _dataContext.Foods.FirstOrDefaultAsync(x => x.Id.Equals(id1));
            ConsumptionModel consumption = await _dataContext.Consumptions.FirstOrDefaultAsync(x => x.Id.Equals(id2));

            if (food == null || consumption == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dataContext.Assignments.Add(new AssignmentModel
            {
                Food = food,
                Consumption = consumption,
                ConsumedGramm = id3
            });
            await _dataContext.SaveChangesAsync();

            return consumption;
        }

        [HttpDelete]
        public async Task DeleteAssignment(int id)
        {
            AssignmentModel assignment = await _dataContext.Assignments.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (assignment == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dataContext.Assignments.Remove(assignment);
            await _dataContext.SaveChangesAsync();
        }
    }
}
