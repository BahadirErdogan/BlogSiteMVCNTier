using BlogSite.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Models.DTOs
{
    public class CreateLikeDTO
    {
        public DateTime CreationDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}
