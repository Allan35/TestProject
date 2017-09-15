using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleWebApplication.Models.EntityManager;
using SampleWebApplication.Models.ViewModel;
using SampleWebApplication.Models.DB;
using System.Web.Security;
using System.Data.Entity.SqlServer;

namespace SampleWebApplication.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Welcome(StudentSignUpView studentSignUp)
        {
            if ((UserStatus)TempData["StudentStatus"] == UserStatus.NowAuthenticated)
            {
                using (var dbContext = new ceit_gwa_databaseEntities1())
                {
                    StudentWelcomeInfo studentWelcomeInfo = new StudentWelcomeInfo();
                    studentWelcomeInfo.CourseList = dbContext.CeitCourses.ToList().Select(p => new SelectListItem
                    {
                        Value = Convert.ToString(p.CourseId),
                        Text = p.Text
                    });
                    studentWelcomeInfo.YearLevelList = dbContext.CeitYearLevels.ToList().Select(p => new SelectListItem
                    {
                        Value = Convert.ToString(p.YearLevelId),
                        Text = p.YearLevel
                    });
                    studentWelcomeInfo.SecurityQuestionList = dbContext.CeitSecurityQuestions.ToList().Select(p => new SelectListItem
                    {
                        Value = Convert.ToString(p.QuestionsId),
                        Text = p.SecurityQuestions
                    });
                    studentWelcomeInfo.GenderList = new SelectList(Enum.GetValues(typeof(Gender)));
                    return View("Welcome", studentWelcomeInfo);
                }
            }
            return View();
        }
        public ActionResult UpdateInfo(StudentWelcomeInfo studentWelcomeInfo)
        {
            if (ModelState.IsValid)
            {
                UserManager usermanager = new UserManager();
                usermanager.UpdateStudentInfo(studentWelcomeInfo);
                ViewBag.Title = studentWelcomeInfo.FirstName;
            }
                return View("Index");
        }
        public ActionResult SkipToAccount()
        {
            UserManager usermanager = new UserManager();
            if(usermanager.test() != null)
            {
                ViewBag.Title = usermanager.test();
            }
            else
            {
                ViewBag.Title = "Test";
            }
            return View("Index");
        }
        public ActionResult ManageProfile()
        {
            return View("Profile");
        }
        public ActionResult UpdateProfile()
        {
            return View();
        }
    }
}