using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using YueYou.UI.Models;
using PagedList;

namespace YueYou.UI.Controllers
{
    public class SearchController : Controller
    {
        private IGuideBLL iguidebll = BLLContainer.Container.Resolve<IGuideBLL>();
        private IGuideDetailsBLL iguidedetailsbll = BLLContainer.Container.Resolve<IGuideDetailsBLL>();
        SearchViewModel svm = new SearchViewModel();
        // GET: Search
        public ActionResult Index()
        {
            var guidearea = iguidebll.GetCategoryofGuideArea().ToList();
            var guideinfo = iguidebll.GetGuideInfo();
            svm.viewarea = guidearea;
            svm.viewguide = guideinfo;
            return View(svm);
        }

        public ActionResult GuidePage(string area, string currentFilter, int? page)
         {
             var guides = iguidebll.GetGuideInfo();
 
             if (area != null)
             {
                 page = 1;
             }
             else
             {
                 area = currentFilter;
             }
 
             ViewBag.CurrentFilter = area;
 
             if (!String.IsNullOrEmpty(area))
             {
                 guides = guides.Where(x => x.Guide_area == area);
             }

             int pageSize = 9;
             int pageNumber = (page ?? 1);
             Session["Guide_area"] = area;
             return PartialView(guides.OrderBy(u=>u.Guide_id).ToPagedList(pageNumber, pageSize));
         }
    }
} 

