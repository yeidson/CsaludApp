using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CsaludApp.Web.Data.Entities
{
    public class Dentist
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<Consent> Consents { get; set; }
        public string Document { get; internal set; }
    }
}
