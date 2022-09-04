using BlogSite.BLL.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Services.AppUserService
{
    public interface IAppUserService
    {
        Task<IdentityResult> SignUp(SignUpDTO model);
        Task<SignInResult> SignIn(SignInDTO model);
        Task SignOut();
        Task<SettingsDTO> GetById(string id);
        Task UpdateUser(SettingsDTO model);
        Task DeleteUser(string id);
    }
}
