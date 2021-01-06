using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planner.BLL.Interfaces;
using Planner.Shared.Models;

namespace Planner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CurrencyDTO>))]
        [ProducesResponseType(400, Type = typeof(IEnumerable<CurrencyDTO>))]
        public async Task<IEnumerable<CurrencyDTO>> GetAll()
        {
            var response = await _currencyService.GetAll();
            return response;
        }
    }
}
