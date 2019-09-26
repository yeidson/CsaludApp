using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CsaludApp.Web.Data.Entities
{
    public class Diagnosis
    {
        public int Id { get; set; }

        [Display(Name = "Code Diagnosis")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(10, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string CodeDx { get; set; }

        [Display(Name = "Name Diagnosis")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(200)]
        public string NameDx { get; set; }

        [Display(Name = "Diagnosis")]
        public string FullDiagnosisWithCode => $"{NameDx} - {CodeDx}";

        public Consent Consent { get; set; }
    }
}
