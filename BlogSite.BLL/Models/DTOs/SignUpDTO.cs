using BlogSite.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Models.DTOs
{
    public class SignUpDTO
    {
        //Properties that will correspond to the data that will transfer from SignUpView
        //Some of the properties managed by Identity below (Email, password etc.)

        //Note : Validation may be manage with MetaData

        [Required(ErrorMessage = "Enter full name")]
        [MinLength(3, ErrorMessage = "Name must have at least 3 characters")]
        public string FullName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public Gender? Gender { get; set; }


        [Required(ErrorMessage = "Enter username")]
        [MinLength(3, ErrorMessage = "Username must have at least 3 characters")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Enter password")]
        [MinLength(6, ErrorMessage = "Password must have at least 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [MinLength(6, ErrorMessage = "Password must have at least 6 characters")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [EmailAddress]
        public string Email { get; set; }



        public DateTime CreationDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}
