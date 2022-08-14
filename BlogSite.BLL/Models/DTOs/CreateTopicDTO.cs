using BlogSite.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Models.DTOs
{
    public class CreateTopicDTO
    {
        [RegularExpression(@"^$[\\p{L]\\s]+$", ErrorMessage = "Only letters are allowed")]
        [Required(ErrorMessage = "Enter name")]
        [MinLength(3, ErrorMessage = "Name must have at least 3 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter description")]
        public string Description { get; set; }
        public DateTime CreationDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}
