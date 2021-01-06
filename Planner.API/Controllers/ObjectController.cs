using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Planner.BLL.Interfaces;
using Planner.DAL.Tables;
using Planner.Shared.Enums;
using Planner.Shared.Models;

namespace Planner.API.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin, Chief, Employee, Partner")]
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectController : ControllerBase
    {
        private readonly IObjectService _objectService;
        private readonly IHistoryService<ObjectHistory> _historyService;

        public ObjectController(IObjectService objectService,
            IHistoryService<ObjectHistory> historyService)
        {
            _objectService = objectService;
            _historyService = historyService;
        }

        [HttpGet("GetObjectsForDisplay")]
        public async Task<IActionResult> GetObjectsForDisplay()
        {
            var response = await _objectService.GetForDisplayAsync(obj => !obj.Deleted);
            return Ok(response);
        }

        [HttpGet("GetObjectsTree")]
        public async Task<IActionResult> GetObjectsTree()
        {
            var response = await _objectService.GetObjectsTree();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var building = await _objectService.GetForDetail(id);
            return Ok(building);
        }

        [HttpGet("GetForEdit")]
        public async Task<IActionResult> GetForEdit(int id)
        {
            var realtyObject = await _objectService.GetById(id);
            return Ok(realtyObject);
        }

        [HttpGet("GetStatusList")]
        public async Task<IActionResult> GetStatusList()
        {
            var response = await _objectService.GetStatusList();
            return Ok(response);
        }

        [HttpGet("GetTaskList")]
        public async Task<IActionResult> GetTaskList(int objectId)
        {
            var taskList = await _objectService.GetTaskList(objectId);
            return Ok(taskList);
        }

        [HttpGet("GetTaskStatusList")]
        public async Task<IActionResult> GetTaskStatusList()
        {
            var statusList = await _objectService.GetTaskStatusList();
            return Ok(statusList);
        }

        [HttpGet("GetObjectsForSelect")]
        public async Task<IActionResult> GetObjectsForSelect()
        {
            var objects = _objectService.GetObjectsForSelect();
            return Ok(objects);
        }

        [HttpPost("CreateObject")]
        [ProducesResponseType(200, Type = typeof(CreateResponse<ObjectDTO>))]
        [ProducesResponseType(400, Type = typeof(CreateResponse<ObjectDTO>))]
        public async Task<IActionResult> CreateObject(ObjectDTO request)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new CreateResponse<ObjectDTO>
                {
                    Response = null,
                    Result = ResponseResultEnum.Error
                });
            }
            var response = await _objectService.Create(request);
            await _historyService.Create(nameof(ObjectController), nameof(CreateObject), JsonConvert.SerializeObject(request), HttpContext.User.Claims.ToArray()[1].Value, "Создание нового объекта");
            return Ok(response);
        }

        [HttpPut("UpdateObject")]
        public async Task<IActionResult> UpdateObject(ObjectDTO request)
        {
            var response = await _objectService.Update(request);
            await _historyService.Create(nameof(ObjectController), nameof(UpdateObject), JsonConvert.SerializeObject(request), HttpContext.User.Claims.ToArray()[1].Value, "Обновление информации по объекту");
            return Ok(response);
        }

        [HttpDelete("DeleteObject")]
        public async Task<IActionResult> DeleteObject(int id)
        {
            var response = await _objectService.Delete(id);
            await _historyService.Create(nameof(ObjectController), nameof(DeleteObject), id.ToString(), HttpContext.User.Claims.ToArray()[1].Value, "Удаление объекта");
            return Ok(response);
        }
    }
}
