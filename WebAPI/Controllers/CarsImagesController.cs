using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsImagesController : ControllerBase
    {

        ICarImagesService _carImagesService;

        public CarsImagesController(ICarImagesService carImagesService)
        {
            _carImagesService = carImagesService;
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImages carImages)
        {
            var result = _carImagesService.Add(file, carImages);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
        {

            var carImages = _carImagesService.Get(Id).Data;

            var result = _carImagesService.Delete(carImages);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int Id)
        {
            var carImages = _carImagesService.Get(Id).Data;
            var result = _carImagesService.Update(file, carImages);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
