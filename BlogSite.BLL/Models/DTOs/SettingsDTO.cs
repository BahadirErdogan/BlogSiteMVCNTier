using BlogSite.BLL.Extensions;
using BlogSite.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Models.DTOs
{
    public class SettingsDTO
    {
        //Properties that will correspond to the data that will transfer from SignUpView
        //Some of the properties managed by Identity below (Email, password etc.)

        //Note : Validation may be manage with MetaData

        public string Id { get; set; } // Update için id lazım

        [Required(ErrorMessage = "Enter full name")]
        [MinLength(3, ErrorMessage = "Name must have at least 3 characters")]
        public string FullName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public Gender? Gender { get; set; }


        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter user name")]
        [MinLength(3, ErrorMessage = "Name must have at least 3 characters")]
        public string UserName { get; set; }

        public string Url { get; set; }

        public string ImagePath { get; set; }

        [FileExt]
        public IFormFile UploadPath { get; set; }

        public string ShortBio { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [MinLength(3, ErrorMessage = "Name must have at least 3 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [MinLength(3, ErrorMessage = "Name must have at least 3 characters")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;
    }
}
