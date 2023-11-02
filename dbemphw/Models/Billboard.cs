using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dbemphw.Models
{
    public class Billboard
    {

        [Display(Name = "類型編號")]
        public string cId { get; set; }

        [Display(Name = "入榜歌曲數")]
        public string bNum { get; set; }

        [Display(Name = "排行榜日期")]
        public DateTime bDate { get; set; }

        [Display(Name = "排行榜名稱")]
        public string bName { get; set; }

    }
}