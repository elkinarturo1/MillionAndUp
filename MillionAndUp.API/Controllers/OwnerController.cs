using Microsoft.AspNetCore.Mvc;
using MillionAndUp.BL.V1.Services.Owner;
using MillionAndUp.BL.V1.Services.Property;
using MillionAndUp.Dtos.V1;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MillionAndUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        IOwnerService service;

        public OwnerController(IOwnerService p_service)
        {
            service = p_service;
        }

        // GET: api/<OwnerController>
        [HttpGet]
        public IActionResult Get(int page = 1,
                                int rowsCount = 10,
                                int IdOwner = -1,
                                string Name = "-1",
                                string Address = "-1",
                                Byte[] Photo = null,
                                string Birthday = "-1"                               
                                )
        {

            try
            {

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                foreach (var item in HttpContext.Request.Query)
                {
                    parameters.Add("@" + item.Key, item.Value.ToString());
                }

                return Ok(service.Read(parameters));
            }
            catch (Exception ex)
            {
                var message = new { Fail = "Ha ocurrido algo! : " + ex.Message };
                return StatusCode(500, message);
            }

        }


        // POST api/<OwnerController>
        [HttpPost]
        public IActionResult Post([FromBody] OwnerDto dto)
        {
            try
            {
                service.Create(dto);
                return Ok(new { Successfull = "Proceso Terminado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Fail = "Ha ocurrido algo! : " + ex.Message });
            }
        }


        // PUT api/<OwnerController>/5
        [HttpPut]
        public IActionResult Put([FromBody] OwnerDto dto)
        {
            try
            {
                service.Update(dto);
                return Ok(new { Successfull = "Proceso Terminado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Fail = "Ha ocurrido algo! : " + ex.Message });
            }
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
                return Ok(new { Successfull = "Proceso Terminado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Fail = "Ha ocurrido algo ! : " + ex.Message });
            }
        }
    }
}
