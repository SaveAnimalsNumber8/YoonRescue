using PracticeFive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PracticeFive.Controllers
{
    public class HomeController : Controller
    {
        SaveAnimalsEntities sadb = new SaveAnimalsEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View("Index", "_IndexVer2"); // 套用 _IndexVer2.cshtml
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string MemberAccount, string MemberPassword)
        {
            // 依帳密取得會員並指定給member
            var member = sadb.tMember
                .Where(m => m.MemberAccount == MemberAccount && m.MemberPassword == MemberPassword)
                .FirstOrDefault();
            //若member為null，表示會員未註冊
            if (member == null)
            {
                ViewBag.Message = "輸入的帳密有誤";
                return View();
            }
            //使用Session變數記錄歡迎詞
            Session["UserID"] = member.MemberID;
            FormsAuthentication.RedirectFromLoginPage(MemberAccount, true);
            return RedirectToAction("Index", "Member");
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}