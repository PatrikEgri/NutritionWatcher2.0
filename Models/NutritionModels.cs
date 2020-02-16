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
    }
}