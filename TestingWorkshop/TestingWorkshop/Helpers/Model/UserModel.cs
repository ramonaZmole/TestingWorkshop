using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWorkshop.Helpers.Model
{
    public class UserModel
    {
        public string FirstName { get; set; } = Faker.Name.FullName();
        public string LastName { get; set; } = Faker.Name.FullName();
        public string Email { get; set; } = Faker.Internet.Email();
        public string ContactPhone { get; set; } = Faker.RandomNumber.Next().ToString();
    }
}
