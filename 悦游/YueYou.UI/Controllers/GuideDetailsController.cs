using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using YueYou.UI.Models;

namespace YueYou.UI.Controllers
{
    public class GuideDetailsController : Controller
    {
        private IUserInfoBLL iuserbll = BLLContainer.Container.Resolve<IUserInfoBLL>();
        private IGuideBLL iguidebll = BLLContainer.Container.Resolve<IGuideBLL>();
        private IGuideDetailsBLL iguidedetailsbll = BLLContainer.Container.Resolve<IGuideDetailsBLL>();
        private IReplyBLL ireplybll = BLLContainer.Container.Resolve<IReplyBLL>();
        private ICommentBLL icommentbll = BLLContainer.Container.Resolve<ICommentBLL>();
        // GET: GuideDetails
       
        public ActionResult GuideDetails(int id)
        {
            ViewBag.Guide_id = id;
            //var user = iuserbll.GetAll();
            var guide = iguidebll.GetAll();
            var comment = icommentbll.GetAll();
            var reply = ireplybll.GetAll();
            var guidedetails = iguidedetailsbll.GetAll();
            var guidedetails1 = iguidebll.GetById(id);
            GuideDetailsViewModel guidedetailsvm = new GuideDetailsViewModel();
            //guidedetailsvm.user = user;
            guidedetailsvm.guide = guide;
            guidedetailsvm.comment = comment;
            guidedetailsvm.reply = reply;
            guidedetailsvm.guidedetails = guidedetails;
            guidedetailsvm.guidedetails1 = guidedetails1;
            return View(guidedetailsvm);
        }
    }
}