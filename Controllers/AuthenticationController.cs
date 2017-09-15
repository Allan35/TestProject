using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleWebApplication.Models.EntityManager;
using SampleWebApplication.Models.ViewModel;
using SampleWebApplication.Models.DB;
using SampleWebApplication.Models.DebugError;
using System.Web.Security;


namespace SampleWebApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View("Login");
        }
        [HttpGet]
        public JsonResult IsStudentExists(string LoginAccount)
        {
            UserManager userManager = new UserManager();
            return Json(!userManager.IsStudentAvailable(LoginAccount), JsonRequestBehavior.AllowGet);
        }
        public bool StudentExist(string studentNumber, string password)
        {
            using (var userContext = new ceit_gwa_databaseEntities1())
            {
                //var user = userContext.CeitUsers.Where(u => u.LoginAccount == studentNumber && u.Password == password).FirstOrDefault();
                try
                {
                    var test = userContext.CeitUsers.Where(u => u.LoginAccount == studentNumber && u.Password == password).FirstOrDefault();
                }
                catch(Exception ex)
                {
                    DebugErrorMessage.CatchError(ex);
                }
                string user = null;
                //user = Convert.ToString(userContext.CeitUsers.Where(u => u.LoginAccount == studentNumber && u.Password == password).FirstOrDefault());

                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public string GetAdmnId(string adminName)
        {
            using (var userContext = new ceit_gwa_databaseEntities1())
            {
                var adminId = userContext.CeitAdministrators.FirstOrDefault(p => p.AdminName == adminName);
                return adminId.AdminId.ToString();
            }
        }
        public bool AdminExist(string adminId, string password)
        {
            using (var userContext = new ceit_gwa_databaseEntities1())
            {
                var admin = userContext.CeitUsers.Where(p => p.AdminAccount == adminId && p.Password == password).FirstOrDefault();
                if(admin != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public ActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(StudentSignUpView studentSignUp)
        {
            if (ModelState.IsValid)
            {
                UserManager userManager = new UserManager();
                userManager.AddStudent(studentSignUp);
                FormsAuthentication.SetAuthCookie(studentSignUp.LoginAccount, false);
                TempData["StudentStatus"] = UserStatus.NowAuthenticated;
                return RedirectToAction("Welcome", "Student", studentSignUp);
            }
            return View("Register", studentSignUp);
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(StudentLogin studentLogin)
        {
            if (ModelState.IsValid && StudentExist(studentLogin.StudentNumber, studentLogin.Password))
            {
                FormsAuthentication.SetAuthCookie(studentLogin.StudentNumber, false);
                return RedirectToAction("Index", "Student", studentLogin);
            }
            else
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return View("Login", studentLogin);
            }
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
        public ActionResult AdminLoginView()
        {
            return View("AdminLoginHere");
        }
        public ActionResult LoginAsAdmin(AdminLogin adminLogin)
        {
            if (ModelState.IsValid && AdminExist(GetAdmnId(adminLogin.AdminAccount), adminLogin.Password))
            {
                FormsAuthentication.SetAuthCookie(adminLogin.AdminAccount, false);
                return RedirectToAction("Index", "Admin", adminLogin);
            }
            else
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return View("AdminLoginHere", adminLogin);
            }

        }
    }
}