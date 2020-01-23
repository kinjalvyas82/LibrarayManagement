using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace LibraryManagement.Models.Extended
{
    [MetadataType(typeof(LibraryUsersrMetData))]
    public partial class LibraryUser
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string AccessLevel { get; set; }

    }


    public class LibraryUsersrMetData
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please Enter First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Please Enter Email Address")]
        //[Display(Name = "Email")]
        //[RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        //ErrorMessage = "Please Enter Correct Email Address")]
        //public string EmailID { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
         public string Password { get; set; }

       

        public DateTime CreateDate { get; set; }

        //public virtual Login Login { get; set; }


    }
}