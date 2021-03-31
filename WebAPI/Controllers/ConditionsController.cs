using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionsController : Controller
    {
        IConditionService _conditionService;

        public ConditionsController(IConditionService conditionService)
        {
            _conditionService = conditionService;
        }

        [HttpPost("add")]
        public IActionResult Add(Condition condition)
        {
            var result = _conditionService.Add(condition);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Condition condition)
        {
            var result = _conditionService.Delete(condition);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Condition condition)
        {
            var result = _conditionService.Update(condition);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _conditionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
