using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCreda.Business.Interfaces {
    public interface IPatientManager {
        /// <summary>
        /// Adds credits to patient
        /// </summary>
        /// <returns></returns>
        bool AddCredits();
        /// <summary>
        /// Patient uses credits and adds corresponding deduction
        /// </summary>
        /// <returns></returns>
        bool UseCredits();
        /// <summary>
        /// Creates a session for video conferencing.
        /// </summary>
        /// <returns></returns>
        string CreateSession();
    }
}
