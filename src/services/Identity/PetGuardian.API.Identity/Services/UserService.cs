﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetGuardian.API.Identity.Models;
using PetGuardian.API.Identity.Services.Interfaces;

namespace PetGuardian.API.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<IdentityResult> SingUp(CreateUser newUser)
        {
            var user = new IdentityUser()
            {
                UserName = newUser.Email,
                Email = newUser.Email,
                EmailConfirmed = true,
            };
                        
            var result = await _userManager.CreateAsync(user, newUser.Password);

            await _userManager.AddToRoleAsync(user, "Member");


            return result;
        }
        public async Task<string> LogIn(LoginUser user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);

            if (!result.Succeeded)
            {
                throw new ArgumentException($"Failed to log in: {result}");
            }

            var userToken = await _signInManager.UserManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == user.Email.ToUpper());

            

            if (userToken == null)
            {
                userToken = new IdentityUser();
            }
            var roles = await _userManager.GetRolesAsync(userToken);
            var token = await _tokenService.GenerateToken(userToken, roles);

            return token;
        }
    }
}
