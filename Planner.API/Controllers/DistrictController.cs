using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planner.BLL.Interfaces;

namespace Planner.API.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin, Employee, Chief, Partner")]
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _districtService.GetAll();
            return Ok(response);
        }

        [HttpGet("GetTree")]
        public async Task<IActionResult> GetTree()
        {
            var tree = await _districtService.GetTree();
            return Ok(tree);
        }
    }
}
