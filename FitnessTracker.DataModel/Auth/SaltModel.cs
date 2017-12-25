using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.DataModel.Auth
{
    public class SaltModel
    {
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
