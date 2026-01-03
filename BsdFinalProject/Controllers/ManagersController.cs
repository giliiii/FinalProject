using BsdFinalProject.DTOs;
using BsdFinalProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BsdFinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagersController : ControllerBase
    {
        private readonly ManagerService _service;

        public ManagersController(ManagerService service)
        {
            _service = service;
        }

       
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ManegerDto>> GetById(int id)
        {
            var m = await _service.GetManagerById(id);
            if (m == null) return NotFound();
            return Ok(m);
        }

       
    }
}