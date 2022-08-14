using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Models.DTOs
{
    public class SignInDTO
    {
        //Properties that will correspond to the data that will transfer from SignInView
        //Properties managed by Identity below 

        //Note : Validation may be manage with MetaData

        [Required(ErrorMessage = "Enter username")]
        [MinLength(3, ErrorMessage = "Username must have at least 3 characters")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Enter password name")]
        [MinLength(6, ErrorMessage = "Password must have at least 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
