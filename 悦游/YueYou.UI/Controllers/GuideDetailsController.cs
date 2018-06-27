using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using YueYou.UI.Models;
using YueYou.Model;
using YueYou.Attributes;

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

        //导游详情页
        public ActionResult GuideDetails(int id)
        {
            ViewBag.Guide_id = id;
            Session["Guide_id"] = ViewBag.Guide_id;
            //var user = iuserbll.GetAll();
            var guide = iguidebll.GetAll();
            var comment = icommentbll.GetGuideCommentByGuideId(id);//展示评论
            var reply = ireplybll.GetReplyByCommentId(id);//展示回复
            var guidedetails = iguidedetailsbll.GetAll();
            var guidedetails1 = iguidebll.GetById(id);//展示导游信息
            GuideDetailsViewModel guidedetailsvm = new GuideDetailsViewModel();
            //guidedetailsvm.user = user;
            guidedetailsvm.guide = guide;
            guidedetailsvm.comment = comment;
            guidedetailsvm.reply = reply;
            guidedetailsvm.guidedetails = guidedetails;
            guidedetailsvm.guidedetails1 = guidedetails1;
            return View(guidedetailsvm);
        }

        //展示导游已有评论
         public ActionResult GuideComment(int id)
        {
            id = Convert.ToInt32(Session["Guide_id"]);
            Session["Guide_id"] = id;

            var comment = icommentbll.GetGuideCommentByGuideId(id);
            return View(comment);
        }


        //添加评论
        [HttpPost]
        [ValidateInput(false)]
        [Login]
        public ActionResult GuideComment(string comment_contents)
        {
            var comment = new Comment();
            int id = Convert.ToInt32(Session["Guide_id"]);
            int userid = Convert.ToInt32(Session["User_id"]);
            if (ModelState.IsValid)
            {
                if (comment_contents != "")
                {
                    comment.User_id = userid;
                    comment.Guide_id = id;
                    comment.Comment_time = System.DateTime.Now;
                    comment.Comment_contents = comment_contents;
                    icommentbll.Add(comment);
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        msg = "评论不能为空!"
                    });
                }
            }
            return Json(new
            {
                success = true,
                User_id = comment.User_id,
                Guide_id = comment.Guide_id,
                Comment_time = comment.Comment_time,
                Comment_contents = comment.Comment_contents
            });
        }

        //展示回复
        public ActionResult ReplyComments(int id)
        {
            id = Convert.ToInt32(Session["Comment_id"]);
            Session["Comment_id"] = id;
            var reply = ireplybll.GetReplyByCommentId(id);
            return View(reply);
        }

        //添加回复
        [HttpPost]
        [ValidateInput(false)]
        [Login]
        public ActionResult ReplyComments(string reply_contents,int comment_id)
        {
            var reply = new Reply();
            int id = Convert.ToInt32(Session["Guide_id"]);
            int userid = Convert.ToInt32(Session["User_id"]);
            if (ModelState.IsValid)
            {
                if (reply_contents != "")
                {
                    reply.User_id = userid;
                    reply.Guide_id = id;
                    reply.Comment_id =comment_id;
                    reply.Reply_time = System.DateTime.Now;
                    reply.Reply_contents = reply_contents;
                    ireplybll.Add(reply);
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        msg = "回复不能为空!"
                    });
                }
            }
            return Json(new
            {
                success = true,
                User_id = reply.User_id,
                Guide_id = reply.Guide_id,
                Comment_id=reply.Comment_id,
                Reply_time = reply.Reply_time,
                Reply_contents = reply.Reply_contents
            });
        }

    }
}