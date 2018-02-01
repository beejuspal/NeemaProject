using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.ModelClass.UserManager
{
   public class BaseAddress
    {
        //public static string strBaseAddress = "http://172.18.11.159:9091/";

        

        public string strBaseAddress
        {
            get
            {
                return strBaseAddress;
            }
            set
            {
                strBaseAddress = "http://172.18.11.159:9091/";
            }
        }
    }
}
