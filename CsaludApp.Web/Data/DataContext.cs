using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CsaludApp.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CsaludApp.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Consent> Consents { get; set; }

        public DbSet<Dentist> Dentists { get; set; }

        public DbSet<Diagnosis> Diagnoses { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Process> Processes { get; set; }
    }
}
