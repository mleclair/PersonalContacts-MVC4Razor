using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models.Enums
{
    public class EntityTypes
    {
        public enum Address
        {
            Home = 1,
            Work = 2,
            Alternate = 3
        }

        public enum Contact
        {
            Unspecified = 0,
            Friend = 1,
            Family = 2,
            Colleague = 3,
            Acquaintance = 4,
            Recruiter = 5,
            Mentor = 6,
            FormerHighSchoolTeacher = 7
        }

        public enum Phone
        {
            Home = 1,
            Mobile = 2,
            Work = 3,
            Other = 20
        }
    }
}