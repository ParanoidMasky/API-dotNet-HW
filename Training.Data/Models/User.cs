using System;
using System.Collections.Generic;
using System.Text;

namespace Training.Data.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        List<Order> Orders { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string RefreshToken { get; set; }

        public string Role { get; set; }
    }
}
