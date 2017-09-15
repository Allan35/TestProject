using SampleWebApplication.Models.DB;
using SampleWebApplication.Models.DebugError;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SampleWebApplication
{
    //public class DatabaseInitializer : CreateDatabaseIfNotExists<ceit_gwa_databaseEntities1>
    //{
    //    protected override void Seed(ceit_gwa_databaseEntities1 context)
    //    {
    //        // Seed code here
    //        base.Seed(context);
    //    }
    //}
    public class DatabaseInitializer : IDatabaseInitializer<ceit_gwa_databaseEntities1>
    {

        public void InitializeDatabase(ceit_gwa_databaseEntities1 context)
        {
            //// Seed code here
            //string newid = Convert.ToString(Guid.NewGuid());
            //var admin = new CeitAdministrator { AdminId = newid, AdminName = "admin" };
            //var user = new CeitUser { AdminAccount = newid, Roles = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Password = "12345" };
            ////var user = new CeitUser { AdminAccount = newid, Roles = 2, Password = "12345" };

            //context.CeitAdministrators.Add(admin);
            //context.CeitUsers.Add(user);
            //context.SaveChanges();
            //try
            //{
            //    //context.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    DebugErrorMessage.CatchError(ex);
            //    //System.Diagnostics.Debug.WriteLine("This will be displayed in output window");
            //    //MessageBox.Show(ex.InnerException.ToString());
            //    //string script = "<script>alert('" + ex.InnerException.ToString() + "');</script>";
            //    //if (!Page.ClientScript.IsStartupScriptRegistered("myErrorScript"))
            //    //{
            //    //    Page.ClientScript.RegisterStartupScript("myErrorScript", script);
            //    //}
            //}
            if (!context.Database.Exists())
            {
                context.Database.Delete();
                context.Database.Create();
                Seed(context);
            }

            //Calling the Seed method
            //Seed(context);


        }
        protected virtual void Seed(ceit_gwa_databaseEntities1 context)
        {
            /// Our seed code
            string newid = Convert.ToString(Guid.NewGuid());
            //var admin = new CeitAdministrator { AdminId = newid, AdminName = "admin" };
            //var user = new CeitUser { AdminAccount = newid, Roles = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Password = "12345" };

            context.CeitAdministrators.Add(new CeitAdministrator { AdminId = newid, AdminName = "admin" });
            context.CeitUsers.Add(new CeitUser { AdminAccount = newid, Roles = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Password = "12345" });
            context.CeitCourses.Add(new CeitCourse { Name = "CPE", Text = "CPE", Value = "BS in Computer Engineering", Status = "Active" });
            context.CeitCourses.Add(new CeitCourse { Name = "ICT", Text = "ICT", Value = "Information Communication Technology", Status = "Active" });
            context.CeitCourses.Add(new CeitCourse { Name = "CPET", Text = "CPET", Value = "Computer Engineering Technology", Status = "Active" });
            context.CeitSecurityQuestions.Add(new CeitSecurityQuestion { SecurityQuestions = "What is your favorite color?"});
            context.CeitUserRoles.Add(new CeitUserRole { Roles = "Student", RolesFor = "Students" });
            context.CeitUserRoles.Add(new CeitUserRole { Roles = "Admin", RolesFor = "Administrators" });
            context.CeitUserRoles.Add(new CeitUserRole { Roles = "SuperUser", RolesFor = "SuperUsers" });
            context.CeitYearLevels.Add(new CeitYearLevel { YearLevel = "1st Year" });
            context.CeitYearLevels.Add(new CeitYearLevel { YearLevel = "2nd Year" });
            context.CeitYearLevels.Add(new CeitYearLevel { YearLevel = "3rd Year" });
            context.CeitYearLevels.Add(new CeitYearLevel { YearLevel = "4th Year" });
            context.CeitYearLevels.Add(new CeitYearLevel { YearLevel = "5th Year" });


            //context.SaveChanges();
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                DebugErrorMessage.CatchError(ex);
            }

        }

        //private static void CatchError(Exception ex)
        //{
        //    HttpContext.Current.Response.Write(ex.InnerException.ToString());
        //}
    }
    //protected override void Seed(ceit_gwa_databaseEntities1 context)
    //{
    //    string newid = Convert.ToString(Guid.NewGuid());
    //    var admin = new CeitAdministrator { AdminId = newid, AdminName = "admin" };
    //    var user = new CeitUser { AdminAccount = newid, Roles = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Password = "12345" };
    //    context.CeitAdministrators.Add(admin);
    //    context.CeitUsers.Add(user);
    //    context.SaveChangesAsync();
    //}
    //public class DatabaseInitializer : IDatabaseInitializer<ceit_gwa_databaseEntities1>
    //{
    //    protected override void Seed(ceit_gwa_databaseEntities1 context)
    //    {
    //        // Seed code here
    //        string newid = Convert.ToString(Guid.NewGuid());
    //        var admin = new CeitAdministrator { AdminId = newid, AdminName = "admin" };
    //        var user = new CeitUser { AdminAccount = newid, Roles = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Password = "12345" };
    //        context.CeitAdministrators.Add(admin);
    //        context.CeitUsers.Add(user);
    //        context.SaveChanges();
    //    }
    //}
}