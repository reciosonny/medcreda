using MedCreda.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCreda.Business.Models.ViewModels {

    public class AccountViewModel {

        public string EmailAddress { get; set; }
        public UserType UserType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// For patient
        /// </summary>
        public int PointsEarned { get; set; }
        /// <summary>
        /// For doctor
        /// </summary>
        public int DoctorPoints { get; set; }

        public string Address { get; set; }

    }
}
