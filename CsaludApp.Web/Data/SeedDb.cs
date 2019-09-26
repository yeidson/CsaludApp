using CsaludApp.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsaludApp.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;

        public SeedDb(DataContext context)
        {
            _dataContext = context;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckDentistsAsync();
            await CheckDiagnosesAsync();
            await CheckPatientsAsync();
            await CheckProcessesAsync();
        }

        private async Task CheckDentistsAsync()
        {
            if (!_dataContext.Dentists.Any())
            {
                AddDentist("98773907", "Yeidson", "Benitez", "413 6624", "300 853 3956", "Cra 81 #45 - 31");
                AddDentist("71312297", "Alejandro", "Diaz", "343 3226", "300 322 3221", "Calle 77 #22 21");
                AddDentist("1017213949", "Lina", "Arango", "450 4332", "350 322 3221", "Carrera 56 #22 21");
                await _dataContext.SaveChangesAsync();
            }

        }

        private void AddDentist(string document, string firstName, string lastName, string fixedPhone, string cellPhone, string address)
        {
            _dataContext.Dentists.Add(new Dentist
            {
                Address = address,
                CellPhone = cellPhone,
                Document = document,
                FirstName = firstName,
                FixedPhone = fixedPhone,
                LastName = lastName
            });
        }

        private async Task CheckProcessesAsync()
        {
            if (!_dataContext.Processes.Any())
            {
                AddProcess("890203", "CONSULTA DE PRIMERA VEZ POR ODONTOLOGIA GENERAL");
                AddProcess("890303", "CONSULTA DE CONTROL O DE SEGUIMIENTO POR ODONTOLOGIA GENERAL");
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddProcess(string CodePx, string NamePx)
        {
            _dataContext.Processes.Add(new Process
            {
                CodePx = CodePx,
                NamePx = NamePx
            });
        }

        private async Task CheckPatientsAsync()
        {
            if (!_dataContext.Patients.Any())
            {
                AddPatient("1017938773", "Maximiliano", "Benitez", "300 853 3956", "Menor de edad");
                AddPatient("43220517", "Caterine", "Dimitrova", "301 638 2682", "Cotizante");
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddPatient(string Document, string FirstName, string LastName, string CellPhone, string Remarks)
        {
            _dataContext.Patients.Add(new Patient
            {
                Document = Document,
                FirstName = FirstName,
                LastName = LastName,
                CellPhone = CellPhone,
                Born = DateTime.Now.AddYears(-2),
                Remarks = Remarks
            });
        }

        private async Task CheckDiagnosesAsync()
        {
            if (!_dataContext.Diagnoses.Any())
            {
                AddDiagnosis("K021", "CARIES DE LA DENTINA");
                AddDiagnosis("K030", "ATRICION EXCESIVA DE LOS DIENTES");
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddDiagnosis(string CodeDx, string NameDx)
        {
            _dataContext.Diagnoses.Add(new Diagnosis
            {
                CodeDx = CodeDx,
                NameDx = NameDx
            });
        }
    }
}
