using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCreda.Business.Models.ViewModels {
    public class RegisterPatientViewModel {
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int UserType {
            get {
                return (int)Helpers.UserType.Patient;
            }
        }
    }
}
