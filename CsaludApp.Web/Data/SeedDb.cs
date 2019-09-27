using CsaludApp.Web.Data.Entities;
using CsaludApp.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsaludApp.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(
            DataContext context,
            IUserHelper userHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("98773907", "Yeidson", "Benitez", "coordinacionti@sumidental.co", "316 691 8342", "Cra 66b #34a - 04", "Admin");
            var healthcare = await CheckUserAsync("1017938773", "Yeison", "Taborda", "yeisonenator@gmail.com", "300 853 3956", "Cra 81 #45-31", "Customer");
            await CheckManagerAsync(manager);
            await CheckDentistsAsync(healthcare);
            await CheckDiagnosesAsync();
            await CheckPatientsAsync();
            await CheckProcessesAsync();
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");
        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
            }

            return user;
        }

        private async Task CheckDentistsAsync(User user)
        {
            if (!_dataContext.Dentists.Any())
            {
                _dataContext.Dentists.Add(new Dentist { User = user });
                await _dataContext.SaveChangesAsync();
            }

        }

        private async Task CheckManagerAsync(User user)
        {
            if (!_dataContext.Managers.Any())
            {
                _dataContext.Managers.Add(new Manager { User = user });
                await _dataContext.SaveChangesAsync();
            }
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
            _dataContext.Processes.Add(new Entities.Process
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
