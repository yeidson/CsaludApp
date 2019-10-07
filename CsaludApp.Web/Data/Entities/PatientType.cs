using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CsaludApp.Web.Data.Entities
{
    public class PatientType
    {
        public int Id { get; set; }

        [Display(Name = "Patient Type")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(200)]
        public string NamePatientType { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}
