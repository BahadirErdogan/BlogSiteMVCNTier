using AutoMapper;
using BlogSite.BLL.Models.DTOs;
using BlogSite.Core.Entities;
using BlogSite.Core.IRepositories;
using Microsoft.AspNetCore.Identity;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Services.AppUserService
{
    public class AppUserService : IAppUserService
    {
        //Identity
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        //Mapper
        private readonly IMapper mapper;


        private readonly IAppUserRepository appUserRepository;

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IAppUserRepository appUserRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.appUserRepository = appUserRepository;
        }

        public async Task<SettingsDTO> GetById(string id)
        {
            var user = await appUserRepository.GetFilteredFirstOrDefault(
                selector: x => new SettingsDTO
                {
                    Id = id,
                    FullName = x.FullName,
                    BirthDate = x.BirthDate,
                    Gender = x.Gender,
                    Email = x.Email,
                    UserName = x.UserName,
                    Url = x.Url,
                    ImagePath = x.ImagePath,
                    ShortBio = x.ShortBio,
                    //Passwords?
                },
                expression: x => x.Id == id && x.Status != Core.Enums.Status.Passive
                );
            return user;
        }

        public async Task<SignInResult> SignIn(SignInDTO model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            return result;
        }

        public async Task SignOut()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> SignUp(SignUpDTO model)
        {
            //Create a new AppUser Object and Mapping

            var user = new AppUser();
            user = mapper.Map(model, user);
            var result = await userManager.CreateAsync(user, model.Password);


            var defaultRole = roleManager.FindByNameAsync("Member").Result;
            if (defaultRole == null)
            {
                var role = new IdentityRole();
                role.Name = "Member";
                await roleManager.CreateAsync(role);
                defaultRole = roleManager.FindByNameAsync("Member").Result;
            } 

            //Assign role to new AppUser
            IdentityResult roleResult = await userManager.AddToRoleAsync(user, defaultRole.Name);

            if (result.Succeeded)
                await signInManager.SignInAsync(user, false);

            return result;
        }

        public async Task UpdateUser(SettingsDTO model)
        {
            var user = await appUserRepository.GetWhere(x=> x.Id == model.Id);

            if (user != null)
            {
                if (model.FullName != null)
                {
                    user.FullName = model.FullName;
                    appUserRepository.Update(user);
                }

                if (model.BirthDate != null)
                {
                    user.BirthDate = model.BirthDate;
                    appUserRepository.Update(user);
                }

                if (model.Gender != null)
                {
                    user.Gender = model.Gender;
                    appUserRepository.Update(user);
                }

                if (model.Email != null)
                {
                    await userManager.SetEmailAsync(user, model.Email);
                }

                if (model.UserName != null)
                {
                    await userManager.SetUserNameAsync(user, model.UserName);
                    //Setting url?
                }

                if (model.UploadPath != null)
                {
                    using var image = Image.Load(model.UploadPath.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    var guid = Guid.NewGuid();
                    image.Save($"wwwroot/images/users/{guid}.jpg");
                    user.ImagePath = $"/images/users/{guid}.jpg";
                }

                if (model.ShortBio != null)
                {
                    user.ShortBio = model.ShortBio;
                    appUserRepository.Update(user);
                }

                if (model.Password!= null)
                {
                    user.PasswordHash = userManager.PasswordHasher.HashPassword(user, model.Password);
                    await userManager.UpdateAsync(user);
                }

                //if (model.ConfirmPassword != null)
                //{
                //??
                //}

                //For refresh session
                await signInManager.SignInAsync(user, false);
            }

        }

        public async Task DeleteUser (string id)
        {
            var user = await appUserRepository.GetWhere(x => x.Id == id);
            appUserRepository.Delete(user);
        }
    }
}
