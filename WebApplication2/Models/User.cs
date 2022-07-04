using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Emailid { get; set; }
        public string password { get; set; }
        public int RoleId { get; set; }

    }
}
