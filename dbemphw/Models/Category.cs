using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace dbemphw.Models
{
    public class Category
    {
        [Display(Name = "類型編號")]
        public string cId { get; set; }
        [Display(Name = "類型名稱")]
        public string cName { get; set; }
        [Display(Name = "類型敘述")]
        public string cDesc { get; set; }
    }
}