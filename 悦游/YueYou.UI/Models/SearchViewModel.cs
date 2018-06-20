using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YueYou.Model;

namespace YueYou.UI.Models
{
    public class SearchViewModel
    {
        public IEnumerable<view_guide> viewguide { get; set; }
        public IEnumerable<view_area> viewarea { get; set; }
    }
}