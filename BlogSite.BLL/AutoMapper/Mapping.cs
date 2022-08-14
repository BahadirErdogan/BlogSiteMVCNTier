using AutoMapper;
using BlogSite.BLL.Models.DTOs;
using BlogSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AppUser,SignUpDTO>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
        }
    }
}
