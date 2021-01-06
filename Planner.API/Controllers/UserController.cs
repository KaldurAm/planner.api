using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Planner.BLL.Interfaces;
using Planner.DAL.Tables;
using Planner.Shared.Enums;
using Planner.Shared.Models;

namespace Planner.API.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin, Chief")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IUserInfoService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            IUserInfoService userService,
            ILogger<UserController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersDTO = _mapper.Map<IEnumerable<ApplicationUserDTO>>(users);
            return Ok(users);
        }

        [HttpGet("GetUsersInfo")]
        public async Task<IActionResult> GetUsersInfo()
        {
            var users = await _userService.GetAll();
            var dtoUsers = _mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(dtoUsers);
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userDTO = _mapper.Map<ApplicationUserDTO>(user);
            userDTO.Roles = (await _userManager.GetRolesAsync(user)).ToList();
            return Ok(userDTO);
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var rolesDTO = _mapper.Map<IEnumerable<RoleDTO>>(roles);
            return Ok(rolesDTO);
        }

        [HttpPost("UpdateRoles")]
        public async Task<IActionResult> UpdateRoles(ApplicationUserDTO userDTO)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userDTO.Id);
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = await _roleManager.Roles.ToListAsync();
                // получаем список ролей, которые были добавлены
                var addedRoles = userDTO.Roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(userDTO.Roles);
                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);
                return Ok(ResponseResultEnum.Updated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Ok(ResponseResultEnum.Error);
            }
        }
    }
}
