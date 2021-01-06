using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planner.BLL.Interfaces;
using Planner.Shared.Models;

namespace Planner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AreaPropertyDTO>))]
        [ProducesResponseType(400, Type = typeof(IEnumerable<AreaPropertyDTO>))]
        public async Task<IEnumerable<AreaPropertyDTO>> GetAll()
        {
            var response = await _propertyService.GetAll();
            return response;
        }
    }
}
