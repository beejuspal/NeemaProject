using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace AcademyApp.ModelClass.UserManager
{
    [Preserve(AllMembers = true)]
    public class User
    {
        public int UserId { get; set; }
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int IsActive { get; set; }
		public string Username { get; set; }
	}
}
