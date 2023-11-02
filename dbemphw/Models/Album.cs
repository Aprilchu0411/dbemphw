using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dbemphw.Models
{
    public class Album
    {
        [Display(Name = "專輯編號")]
        public string aId { get; set; }
        [Display(Name = "專輯名稱")]
        public string aName { get; set; }
        [Display(Name = "專輯銷售量")]
        public string aTurnoner { get; set; }
        [Display(Name = "專輯發佈日期")]
        public DateTime aDate { get; set; }
        [Display(Name = "歌手編號")]
        public string zId { get; set; }
    }
}