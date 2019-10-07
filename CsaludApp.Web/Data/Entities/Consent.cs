using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CsaludApp.Web.Data.Entities
{
    public class Consent
    {
        public int Id { get; set; }

        [Display(Name = "Description*")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Description { get; set; }

        [Display(Name = "Date*")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Remarks { get; set; }

        [Display(Name = "Date*")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateLocal => Date.ToLocalTime();

        //public ICollection<Diagnosis> Diagnoses { get; set; }
        public Diagnosis Diagnosis { get; set; }

        //public ICollection<Process> Processes { get; set; }
        public Process Process { get; set; }

        public Patient Patient { get; set; }

        public Dentist Dentist { get; set; }

    }
}