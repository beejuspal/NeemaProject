using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace AcademyApp.ModelClass.UserManager
{
    [Preserve(AllMembers = true)]
    [Serializable]
    public class UserRole
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public int IsActive { get; set; }
    }
}
