using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CsaludApp.Web.Data.Entities
{
    public class InquiryType
    {
        public int Id { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(10, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Code { get; set; }

        [Display(Name = "Name Inquiry")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(200)]
        public string NameInquiry { get; set; }

        [Display(Name = "Inquiry Types")]
        public string FullDiagnosisWithCode => $"{NameInquiry} - {Code}";

        public Consent Consent { get; set; }
    }
}
