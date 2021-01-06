using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Planner.BLL.Interfaces;
using Planner.DAL.Tables;
using Planner.Shared.Models;

namespace Planner.API.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin, Chief, Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IHistoryService<TaskHistory> _historyService;

        public TaskController(ITaskService taskService,
            IHistoryService<TaskHistory> historyService)
        {
            _taskService = taskService;
            _historyService = historyService;
        }

        [HttpGet("GetTask")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _taskService.GetCardById(id);
            return Ok(task);
        }

        [HttpGet("GetTaskList")]
        public async Task<IActionResult> GetTaskList(int objectId)
        {
            var taskList = await _taskService.GetTaskList(objectId);
            return Ok(taskList);
        }

        [HttpGet("GetTaskStatusList")]
        public async Task<IActionResult> GetTaskStatusList()
        {
            var statusList = await _taskService.GetTaskStatusList();
            return Ok(statusList);
        }

        [HttpGet("GetColors")]
        public async Task<IActionResult> GetColors()
        {
            var colors = await _taskService.GetColors();
            return Ok(colors);
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask(CreateCardDTO card)
        {
            var newCard = await _taskService.Create(card);
            await _historyService.Create(nameof(TaskController), nameof(CreateTask), JsonConvert.SerializeObject(card), HttpContext.User.Claims.ToArray()[1].Value, "Создание новой задачи");
            return Ok(newCard);
        }

        [HttpPut("UpdateStatus")]
        public async Task UpdateStatus(CardDTO card)
        {
            var user = HttpContext.User.Claims.ToArray()[1].Value;
            await _taskService.UpdateTaskStatus(card, user);
            await _historyService.Create(nameof(TaskController), nameof(UpdateStatus), JsonConvert.SerializeObject(card), user, "Изменение статуса задачи");
        }

        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(CardDTO card)
        {
            var user = HttpContext.User.Claims.ToArray()[1].Value;
            var newCard = await _taskService.Update(card, user);
            await _historyService.Create(nameof(TaskController), nameof(UpdateTask), JsonConvert.SerializeObject(card), user, "Обновление информации задачи");
            return Ok(newCard);
        }

        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var user = HttpContext.User.Claims.ToArray()[1].Value;
            var result = await _taskService.Delete(taskId, user);
            await _historyService.Create(nameof(TaskController), nameof(DeleteTask), taskId.ToString(), user, "Удаление задачи");
            return Ok(result);
        }
    }
}
