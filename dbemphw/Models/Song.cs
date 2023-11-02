using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dbemphw.Models
{
    public class Song
    {
        [Display(Name ="歌曲編號")]
        public string sId { get; set; }
        [Display(Name = "歌曲名稱")]
        public string sName { get; set; }
        [Display(Name = "作曲者")]
        public string sComposer { get; set; }
        [Display(Name = "作詞者")]
        public string sLyricist { get; set; }
        [Display(Name = "歌詞")]
        public string sLyrics { get; set; }
        [Display(Name = "音樂影片")]
        public string sMv { get; set; }

    }
}