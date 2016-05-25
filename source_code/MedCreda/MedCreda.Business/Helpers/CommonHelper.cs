using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCreda.Business.Helpers {
    public enum UserType {
        Doctor = 1,
        Patient
    }

    public enum RegisterStatus {
        Registered = 1,
        EmailUsernameExists,
    }


    class CommonHelper {
    }
}
