using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SampleWebApplication.Models.EntityManager;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWebApplication.Models.ViewModel
{
    public class StudentSignUpView
    {
        //[AccountValidation]
        [Remote("IsStudentExists", "Authentication", ErrorMessage = "Student number already exists!")]
        [Required(ErrorMessage = "Required")]
        [Display(Name = "User Account")]
        public string LoginAccount { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public UserStatus StudentStatus { get; set; }

    }

    public class StudentLogin
    {
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    public class StudentWelcomeInfo
    {
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [Display(Name = "Year Level")]
        public int YearLevelId { get; set; }

        [Display(Name = "Security Question")]
        public int QuestionId { get; set; }
        public string Answer { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> CourseList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> YearLevelList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> SecurityQuestionList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> GenderList { get; set; }

    }
    public enum Gender
    {
        Male,
        Female
    }
    public class StudentProfileInfo
    {
        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [Display(Name = "Year Level")]
        public int YearLevelId { get; set; }

        [Display(Name = "Security Question")]
        public int QuestionId { get; set; }
        public string Answer { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> CourseList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> YearLevelList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> SecurityQuestionList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> GenderList { get; set; }

    }
    public class AdminLogin
    {
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Admin Login")]
        public string AdminAccount { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }

    //public class AccountValidation : ValidationAttribute
    //{
    //    UserManager user = new UserManager();
    //    StudentSignUpView student = new StudentSignUpView();
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        if (user.IsStudentExist(student.LoginAccount)) // Checking for Empty Value
    //        {
    //            return new ValidationResult("Student number already taken.");
    //        }
    //        //else
    //        //{
    //        //    return new ValidationResult("First Name should Not contain @");
    //        //}
    //        return ValidationResult.Success;
    //    }
    //}
}