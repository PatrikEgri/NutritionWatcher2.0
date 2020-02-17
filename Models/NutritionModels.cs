using System;
using System.ComponentModel.DataAnnotations;

namespace NutritionWatcher2._0.Models
{
    public class FoodModel
    {
        [Required]
        public int Id { get; set; }

        [Required] [Display(Name = "Név")]
        public string Name { get; set; }

        [Required] [Display(Name = "Fehérjetartalom")]
        public float ProteinAmount { get; set; }

        [Required] [Display(Name = "Zsírtartalom")]
        public float FatAmount { get; set; }

        [Required] [Display(Name = "Szénhidráttartalom")]
        public float HydrocarbonateAmount { get; set; }

        [Required] [Display(Name = "Tömeg (g)")]
        public int Gramm { get; set; }

        public ApplicationUser Owner { get; set; }
    }

    public class ConsumptionModel
    {
        [Required]
        public int Id { get; set; }

        [Required] [Display(Name = "Dátum")]
        public string Date { get; set; }

        [Required] [Display(Name = "Idő")]
        public string Time { get; set; }

        public ApplicationUser Owner { get; set; }
    }

    public class AssignmentModel
    {
        [Required]
        public int Id { get; set; }

        [Required] [Display(Name = "Étel")]
        public FoodModel Food { get; set; }

        [Required] [Display(Name = "Fogyasztás")]
        public ConsumptionModel Consumption { get; set; }

        [Required] [Display(Name = "Fogyasztott tömeg (g)")]
        public int ConsumedGramm { get; set; }

        public float GetConsumedCalorie()
        {
            return (Food.ProteinAmount * 4 + Food.FatAmount * 9 + Food.HydrocarbonateAmount * 4) / Food.Gramm * ConsumedGramm;
        }

        public float GetConsumedProtein()
        {
            return Food.ProteinAmount / Food.Gramm * ConsumedGramm;
        }

        public float GetConsumedFat()
        {
            return Food.FatAmount / Food.Gramm * ConsumedGramm;
        }

        public float GetConsumedHydrocarbonate()
        {
            return Food.HydrocarbonateAmount / Food.Gramm * ConsumedGramm;
        }

        public bool IsThisDay()
        {
            return DateTime.Today.ToString("yyyy-MM-dd").Equals(Consumption.Date);
        }

        public bool IsPastWeek()
        {
            string dates = "";

            for (int i = 0; i < 8; i++)
                dates += DateTime.Today.AddDays(-i).ToString("yyyy-MM-dd");

            return dates.Contains(Consumption.Date);
        }

        public bool IsThisMonth()
        {
            int year = DateTime.Parse(Consumption.Date).Year;
            int month = DateTime.Parse(Consumption.Date).Month;

            return DateTime.Today.Year.Equals(year) && DateTime.Today.Month.Equals(month);
        }
    }
}