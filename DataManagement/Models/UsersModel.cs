using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataManagement.Models
{
    public class UsersModel
    {
        public int Id { get; set; }

        [Display(Name = "User ID")]
        [Required(ErrorMessage = "You need to input your a user id")]
        public int User_ID { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "You need to input your first name.")]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You need to input your first name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to input your last name.")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You need to input your email address.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("EmailAddress", ErrorMessage = "The Email and Confirm Email must match.")]
        [Required(ErrorMessage = "You need to re-type your email address.")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Old Password")]
        [Required(ErrorMessage = "You must put a new password.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must have a password.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "You need to provide a long enough password.")]
        public string UserPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "You must re-type your password.")]
        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "Your password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}