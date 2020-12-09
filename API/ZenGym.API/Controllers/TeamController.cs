using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZenGym.Domain.Entities;
using ZenGym.Domain.Services;

namespace ZenGym.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamDataService _dataService;

        public TeamController(ITeamDataService dataService)
        {
            _dataService = dataService;
        }

        
        //GET /api/team
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var teams =  await _dataService.GetAllAsync();
            return Ok(teams);
        }

        //GET /api/team/1
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var team = await _dataService.GetAsync(id);
            return Ok(team);
        }
    }
}
