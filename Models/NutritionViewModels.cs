using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NutritionWatcher2._0.Models
{
    public class EditUsernameViewModel
    {
        [Required] [Display(Name = "Felhasználónév")]
        public string Username { get; set; }
    }

    public class EditEmailViewModel
    {
        [Required] [Display(Name = "E-Mail cím")]
        public string Email { get; set; }
    }

    public class EditPhoneNumberViewModel
    {
        [Required] [Display(Name = "Telefonszám")]
        public string PhoneNumber { get; set; }
    }

    public class EditFirstnameViewModel
    {
        [Required] [Display(Name = "Keresztnév")]
        public string Firstname { get; set; }
    }

    public class EditLastnameViewModel
    {
        [Required] [Display(Name = "Vezetéknév")]
        public string Lastname { get; set; }
    }

    public class SaveConsumptionViewModel
    {
        public int Id { get; set; }

        [Required] [Display(Name = "Dátum")]
        public DateTime Date { get; set; }

        [Required] [Display(Name = "idő")]
        public DateTime Time { get; set; }
    }

    public class AssignmentsViewModel
    {
        public ConsumptionModel Consumption { get; set; }
        public IEnumerable<AssignmentModel> Assignments { get; set; }
    }

    public class StatisticViewModel
    {
        public IEnumerable<ConsumptionModel> Consumptions { get; set; }
        public IEnumerable<AssignmentModel> Assignments { get; set; }
    }
}