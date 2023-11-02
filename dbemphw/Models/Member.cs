using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbemphw.Models
{
    public class Member
    {
        public string mId { get; set; }
        public string mName { get; set; }
        public DateTime mBirthday { get; set; }
        public string mGender { get; set; }
        public string mEmail { get; set; }
    }
}