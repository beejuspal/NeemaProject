using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.ModelClass.UserManager
{
   public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int IsActive { get; set; }
    }
}
