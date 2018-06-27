using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YueYou.Model;
using IBLL;
using YueYou.UI.Models;

namespace YueYou.UI.Controllers
{
    public class UserInfoController : Controller
    {
        YueYouEntities db = new YueYouEntities();
        private IUserInfoBLL iuserbll = BLLContainer.Container.Resolve<IUserInfoBLL>();
        UserCenterViewModel ucvm = new UserCenterViewModel();
        //UserBLL userbll = new UserBLL();
        public ActionResult Index(int User_id)
        {
            Session["User_id"]=User_id;
            ucvm.user = db.UserInfo.Find(User_id);
            ucvm.userinfo = iuserbll.GetUserByUserId(User_id);
            ucvm.viewcomment = iuserbll.GetCommentByUserId(User_id);
            ucvm.viewcollection = iuserbll.GetCollectionByUserId(User_id);
            ucvm.vieworder = iuserbll.GetOrderByUserId(User_id);
            return View(ucvm);
        }

        // GET: User
        public ActionResult Login()
        {
            return View();
        }


        //登录账号
        [HttpPost]
        public string Login([Bind(Include ="User_name,User_pwd")] string User_name,string User_pwd)
        {
            try
            {
                var users = iuserbll.Denglu(User_name, User_pwd);
                if (users != null)
                {
                    //保存到Session HttpContext.
                    //Session["User_name"] = User_name;
                    //Session["User_image"] = iuserbll.GetUserByUserName(User_name).User_image;
                    Session["User_name"] = users.User_name;
                    Session["User_id"] = users.User_id;
                    Session["User_image"] = users.User_image;
                    string data = "登录成功";
                    return data;
                }
                else
                {
                    string data = "登录失败";
                    return data;
                }
            }
            catch (Exception ex)
            {
                string data = "错误";
                return data;
            }
            
        }

        //注销账号
        public ActionResult LoginOut()
        {
            Session["UserName"] = null;
            Session["User_id"] = null;
            return Content("<script>alert('注销成功！');window.open('" + Url.Content("~/Home/Index") + "','_self');</script>");
        }

        //注册用户 GET
        public ActionResult Register()
        {
            return View();
        }

        //注册用户 POST
        [HttpPost]
        public ActionResult Register( UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                Session["User_name"] = userinfo.User_name;
                Session["User_id"] = userinfo.User_id;
                iuserbll.Add(userinfo);
                return Content("<script>alert('用户注册成功！');window.open('" + Url.Content("~/Home/Index") + "', '_self')</script>");
            }
            else
            {
                return Content("<script>;alert('注册失败！');window.open('" + Url.Content("~/User/Register") + "', '_self')</script>");
            }

        }
        //编辑个人资料
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInfo(UserInfo userinfo)
        {
            userinfo.User_id = Convert.ToInt32(Session["User_id"].ToString());
            userinfo = db.UserInfo.Find(userinfo.User_id);
            HttpPostedFileBase userImage = Request.Files["User_image"];
            try
            {
                if (userImage.FileName != "")
                {
                    string filePath = userImage.FileName;
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") +
                                      filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\images\userphoto\") + filename;
                    string relativepath = @"/images/userphoto/" + filename;
                    userImage.SaveAs(serverpath);
                    userinfo.User_image = relativepath;
                }
                else
                {
                    userinfo.User_image = db.UserInfo.Find(userinfo.User_id).User_image;
                }
                if (ModelState.IsValid)
                {
                    userinfo.User_name = db.UserInfo.Find(userinfo.User_id).User_name;
                    userinfo.User_phone = db.UserInfo.Find(userinfo.User_id).User_phone;
                    userinfo.User_mail = db.UserInfo.Find(userinfo.User_id).User_mail;
                    userinfo.User_sex = db.UserInfo.Find(userinfo.User_id).User_sex;
                    userinfo.Sign = db.UserInfo.Find(userinfo.User_id).Sign;
                    iuserbll.Update(userinfo);
                    //db.Post.Add(post);
                    //db.SaveChanges();
                    //return RedirectToAction("Index");
                    //return "aa";
                    return RedirectToAction("Index", "UserInfo", new { User_id = userinfo.User_id });
                    //return Content("<script>;alert('修改成功！');</script>");
                }
                else
                {
                    //return "bb";
                    return Content("<script>;alert('修改失败！');window.history.go(-1);window.location.reload();</script>");
                }
            }
            catch (Exception ex)
            {
                //return ex.ToString();
                return Content(ex.Message);
            }

        }



    }
}