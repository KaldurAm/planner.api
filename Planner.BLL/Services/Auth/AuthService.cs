using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Planner.BLL.Interfaces;
using Planner.DAL.Context;
using Planner.DAL.Tables;
using Planner.Shared.Enums;
using Planner.Shared.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.BLL.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly ILogger<AuthService> _logger;
        private readonly IClaimService _claimService;

        public AuthService(UserManager<ApplicationUser> userManager,
            ApplicationDbContext db,
            ILogger<AuthService> logger,
            IClaimService claimService)
        {
            _userManager = userManager;
            _db = db;
            _logger = logger;
            _claimService = claimService;
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                return new UserManagerResponse("Пользователь с таким электронным адресом не найден", false);
            }

            var passPasswordValidation = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!passPasswordValidation)
            {
                return new UserManagerResponse("Логин или пароль введены неверно", false);
            }

            var roles = await _userManager.GetRolesAsync(user);

            return await _claimService.GetClaims(user, roles.ToArray());
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterRequest request)
        {
            _logger.LogInformation(nameof(RegisterUserAsync) + " start");

            if (request == null)
            {
                _logger.LogInformation("LoginRequest model is null", request);
                throw new NullReferenceException("LoginRequest is null");
            }

            if (request.Password != request.ConfirmPassword)
            {
                return new UserManagerResponse("Пароли не совпадают", false);
            }

            var identityUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email
            };

            var result = await _userManager.CreateAsync(identityUser, request.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("User registered", identityUser.UserName);

                await _userManager.AddToRoleAsync(identityUser, UserRoleEnum.Guest.ToString());

                _logger.LogInformation("Added role viewer for user", identityUser.UserName);

                #region Create new UserInfo
                var userInfo = new UserInfo
                {
                    UserId = identityUser.Id,
                    Name = request.Name,
                    Surname = request.Surname
                };
                await _db.UserList.AddAsync(userInfo);
                await _db.SaveChangesAsync();
                #endregion

                return await _claimService.GetClaims(identityUser, UserRoleEnum.Guest.ToString());
            }

            StringBuilder sb = new StringBuilder();

            if (result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    sb.Append(error.Description);
                }
            }

            _logger.LogInformation(nameof(RegisterUserAsync) + " end");

            return new UserManagerResponse(sb.ToString(), false);
        }
    }
}
