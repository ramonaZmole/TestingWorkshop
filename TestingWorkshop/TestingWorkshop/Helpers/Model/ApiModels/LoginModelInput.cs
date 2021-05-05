using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWorkshop.Helpers.Model.ApiModels
{
    public class LoginModelInput
    {
        public string username { get; set; } = "admin";
        public string password { get; set; } = "password";
    }
}
