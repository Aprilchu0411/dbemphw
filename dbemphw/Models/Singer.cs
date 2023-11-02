using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace dbemphw.Models
{
    public class Singer
    {
        [Display(Name = "歌手編號")]
        public string zId { get; set; }

        [Display(Name = "歌手年紀")]
        public string zAge { get; set; }
        [Display(Name = "歌手出道年")]
        public DateTime zDate { get; set; }
        [Display(Name = "歌手所屬公司")]
        public string zCompany { get; set; }
        [Display(Name = "歌手名字")]
        public string zName { get; set; }
        [Display(Name = "歌手簡介")]
        public string zDesc { get; set; }
    }
}