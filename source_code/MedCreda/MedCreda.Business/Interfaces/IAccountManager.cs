using MedCreda.Business.Helpers;
using MedCreda.Business.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCreda.Business.Interfaces {
    public interface IAccountManager {
        RegisterStatus RegisterAsPatient(RegisterPatientViewModel vm);
        List<AccountViewModel> GetDoctors();
        List<AccountViewModel> GetPatients();
        RegisterStatus RegisterAsDoctor(RegisterDoctorViewModel vm);
        void CreateAccount(AccountViewModel vm);
        List<AccountViewModel> GetAccounts();
    }
}
