using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Formula1_WebApplication.Models
{
    public class Team
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Range(1850, 2020)]
        [DisplayName("Year of foundation")]
        [Required(ErrorMessage = "Year of foundation is required.")]
        public int YearOfFoundation { get; set; }

        [Range(0, 500)]
        [DisplayName("Attained World Championships")]
        [DefaultValue(0)]
        public int AttainedWorldChampionships { get; set; }

        //[Required]
        [DisplayName("Paid entry fee.")]
        [DefaultValue(false)]
        public bool PaidEntryFee { get; set; }
    }
}
