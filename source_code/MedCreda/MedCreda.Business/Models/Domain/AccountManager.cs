using MedCreda.Business.Data;
using MedCreda.Business.Helpers;
using MedCreda.Business.Interfaces;
using MedCreda.Business.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCreda.Business.Models.Domain {
    public class AccountManager : IAccountManager {

        public void CreateAccount(AccountViewModel vm) {

            using (var db = new MedCredaEntities()) {
                Account account = new Account();

                var viewModelParser = new ViewModelParser<Account, AccountViewModel>(account, vm);
                viewModelParser.UpdateModelState();
                db.Accounts.Add(account);
                db.SaveChanges();
            }
            //throw new NotImplementedException();
        }

        public List<AccountViewModel> GetAccounts() {
            var list = new List<AccountViewModel>();

            using (var db = new MedCredaEntities()) {
                Account account = new Account();
                db.Accounts.ToList().ForEach(x => {
                    var viewModelParser = new ViewModelParser<Account, AccountViewModel>(x);
                    var vm = new AccountViewModel();
                    vm = viewModelParser.TransferDataToViewModel();
                    vm.UserType = (UserType)(x.UserType??0);
                    list.Add(vm);

                    //viewModelParser.UpdateModelState();
                });

            }

            return list;
        }

        public List<AccountViewModel> GetDoctors() {
            var list = new List<AccountViewModel>();

            using (var db = new MedCredaEntities()) {
                Account account = new Account();
                db.Accounts.Where(x => x.UserType == (int)UserType.Doctor).ToList().ForEach(x => {
                    var viewModelParser = new ViewModelParser<Account, AccountViewModel>(x);
                    var vm = new AccountViewModel();
                    vm = viewModelParser.TransferDataToViewModel();
                    vm.UserType = (UserType)(x.UserType ?? 0);
                    list.Add(vm);
                });

            }
            return list;
        }

        public List<AccountViewModel> GetPatients() {
            var list = new List<AccountViewModel>();
            using (var db = new MedCredaEntities()) {
                Account account = new Account();
                db.Accounts.Where(x => x.UserType == (int)UserType.Patient).ToList().ForEach(x => {
                    var viewModelParser = new ViewModelParser<Account, AccountViewModel>(x);
                    var vm = new AccountViewModel();
                    vm = viewModelParser.TransferDataToViewModel();
                    vm.UserType = (UserType)(x.UserType ?? 0);
                    list.Add(vm);
                });
            }

            return list;

        }
        
        public bool Login(LoginViewModel vm) {
            var list = new List<AccountViewModel>();
            bool result = false;
            using (var db = new MedCredaEntities()) {
                result = db.Accounts.Any(x => x.Username == vm.Username && x.Password == vm.Password);
            }

            return result;
        }

        public RegisterStatus RegisterAsDoctor(RegisterDoctorViewModel vm) {
            try {
                using (var db = new MedCredaEntities()) {
                    Account account = new Account();
                    var isAccountExists = db.Accounts.Where(x => x.Username == vm.Username || x.EmailAddress == vm.EmailAddress).Any();
                    if (isAccountExists) {
                        return RegisterStatus.EmailUsernameExists;
                    }

                    var viewModelParser = new ViewModelParser<Account, RegisterDoctorViewModel>(account, vm);
                    viewModelParser.UpdateModelState();
                    db.Accounts.Add(account);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) {
                //result = false;
                //throw;
            }

            return RegisterStatus.Registered;
        }
        
        public RegisterStatus RegisterAsPatient(RegisterPatientViewModel vm) {
            try {
                using (var db = new MedCredaEntities()) {
                    Account account = new Account();
                    var isAccountExists = db.Accounts.Where(x => x.Username == vm.Username || x.EmailAddress == vm.EmailAddress).Any();
                    if (isAccountExists) {
                        return RegisterStatus.EmailUsernameExists;
                    }

                    var viewModelParser = new ViewModelParser<Account, RegisterPatientViewModel>(account, vm);
                    viewModelParser.UpdateModelState();
                    db.Accounts.Add(account);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) {
                //result = false;
                //throw;
            }

            return RegisterStatus.Registered;
            //return result;
        }


    }
}
