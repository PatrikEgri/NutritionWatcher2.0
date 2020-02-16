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
    public class FoodController : ApiController
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

        [HttpGet]
        public FoodModel GetFood(int id)
        {
            FoodModel food =  _dataContext.Foods.FirstOrDefault(x => x.Id.Equals(id));
            
            if (food == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return food;
        }

        [HttpGet]
        public IEnumerable<FoodModel> GetFoods()
        {
            return  _dataContext.Foods.ToList();
        }

        [HttpDelete]
        public async Task DeleteFood(int id)
        {
            FoodModel food = await _dataContext.Foods.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (food == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dataContext.Foods.Remove(food);
            await _dataContext.SaveChangesAsync();
        }

        [HttpPut]
        public async Task UpdateFood(int id, FoodModel food)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            FoodModel foodInDb = await _dataContext.Foods.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (foodInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            foodInDb.Name = food.Name;
            foodInDb.ProteinAmount = food.ProteinAmount;
            foodInDb.FatAmount = food.FatAmount;
            foodInDb.HydrocarbonateAmount = food.HydrocarbonateAmount;
            foodInDb.Gramm = food.Gramm;

            await _dataContext.SaveChangesAsync();
        }

        [HttpPost]
        public async Task<FoodModel> CreateFood(FoodModel food)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _dataContext.Foods.Add(food);
            await _dataContext.SaveChangesAsync();

            return food;
        }


        [HttpGet]
        public IEnumerable<FoodModel> GetSystemFoods()
        {
            return  _dataContext.Foods.Include(x => x.Owner).Where(x => x.Owner.Equals(null)).ToList();
        }

        [HttpGet]
        public IEnumerable<FoodModel> GetUsersFoods()
        {
            string id = User.Identity.GetUserId();
            List<FoodModel> foods =  _dataContext.Foods.Include(x => x.Owner).Where(x => x.Owner.Id.Equals(id)).ToList();

            if (foods == null || foods.Count == 0)
                return new List<FoodModel>();

            return foods;          
        }

        [HttpGet]
        public IEnumerable<FoodModel> GetOtherUsersFoods()
        {
            string id = User.Identity.GetUserId();
            List<FoodModel> foods =  _dataContext.Foods.Include(x => x.Owner).Where(x => !x.Owner.Equals(null) && !x.Owner.Id.Equals(id)).ToList();

            if (foods == null || foods.Count == 0)
                return new List<FoodModel>();

            return foods;
        }
    }
}
