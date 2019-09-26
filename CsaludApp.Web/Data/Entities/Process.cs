using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CsaludApp.Web.Data.Entities
{
    public class Process
    {
        public int Id { get; set; }

        [Display(Name = "Code Process")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(10, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string CodePx { get; set; }

        [Display(Name = "Name Diagnosis")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(200)]
        public string NamePx { get; set; }

        [Display(Name = "Process")]
        public string FullProcessWithCode => $"{NamePx} - {CodePx}";

        public Consent Consent { get; set; }
    }
}