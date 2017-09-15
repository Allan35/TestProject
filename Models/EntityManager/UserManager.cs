using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleWebApplication.Models.DB;
using SampleWebApplication.Models.ViewModel;
using System.Web.Security;

namespace SampleWebApplication.Models.EntityManager
{
    public class UserManager
    {
        //Adding student
        public void AddStudent(StudentSignUpView user)
        {
            using (var db = new ceit_gwa_databaseEntities1())
            {
                string rolefor = "Students";
                string newid = Convert.ToString(Guid.NewGuid());

                CeitStudent StudentData = new CeitStudent();
                StudentData.StudentNumber = user.LoginAccount;
                StudentData.StudentID = newid;
                db.CeitStudents.Add(StudentData);

                CeitUser UserData = new CeitUser();
                UserData.StudentAccount = StudentData.StudentID;
                UserData.LoginAccount = user.LoginAccount;
                UserData.Password = user.Password;
                UserData.Roles = GetRoleId(rolefor);
                UserData.DateUpdated = DateTime.Now;
                UserData.DateCreated = DateTime.Now;
                db.CeitUsers.Add(UserData);
                db.SaveChanges();
            }
        }
        public void UpdateStudentInfo(StudentWelcomeInfo studentWelcomeInfo)
        {
            using (var db = new ceit_gwa_databaseEntities1())
            {
                string studentid;
                CeitStudent studentData;
                CeitUser userData;

                if (GetStudentId(HttpContext.Current.User.Identity.Name) != null)
                {
                    studentid = GetStudentId(HttpContext.Current.User.Identity.Name);
                    studentData = db.CeitStudents.FirstOrDefault(p => p.StudentID == studentid);
                    userData = db.CeitUsers.FirstOrDefault(p => p.StudentAccount == studentid);

                    if (studentData != null)
                    {
                        studentData.FirstName = studentWelcomeInfo.FirstName;
                        studentData.MiddleName = studentWelcomeInfo.MiddleName;
                        studentData.LastName = studentWelcomeInfo.LastName;
                        studentData.Gender = studentWelcomeInfo.Gender;
                        studentData.CourseId = studentWelcomeInfo.CourseId;
                        studentData.YearLevelId = studentWelcomeInfo.YearLevelId;
                        studentData.QuestionId = studentWelcomeInfo.QuestionId;
                        studentData.Answer = studentWelcomeInfo.Answer;
                    }

                    if(userData != null)
                    {
                        userData.DateUpdated = DateTime.Now;
                    }

                    db.SaveChanges();

                }
            }
        }
        //Check if student exist
        public bool IsStudentAvailable(string loginAccount)
        {
            using (var db = new ceit_gwa_databaseEntities1())
            {
                return db.CeitStudents.Any(o => o.StudentNumber.Equals(loginAccount));
                //|| db.CeitUsers.Any(o => o.LoginAccount.Equals(loginAccount))
            }
        }
        //Get assigned role
        public int GetRoleId(string rolefor)
        {
            using (var db = new ceit_gwa_databaseEntities1())
            {
                var student = db.CeitUserRoles.FirstOrDefault(a => a.RolesFor.Equals(rolefor));
                return student.RoleId;
            }
        }
        public string GetStudentId(string studentNumber)
        {
            using (var db = new ceit_gwa_databaseEntities1())
            {
                var student = db.CeitStudents.FirstOrDefault(p => p.StudentNumber == studentNumber);
                if(student != null)
                {
                    return Convert.ToString(student.StudentID);
                }
                return null;
            } 
        }
        public string test()
        {
            return HttpContext.Current.User.Identity.Name;
        }

    }
}