using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillionAndUp.BL.V1.Services.Property;
using MillionAndUp.Dtos.V1;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MillionAndUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PropertyController : ControllerBase
    {

        IPropertyService service;

        public PropertyController(IPropertyService p_service)
        {
            service = p_service;
        }

        // GET: api/<PropertyController>
        [HttpGet]
        public IActionResult Get(int page = 1,
                                int rowsCount = 10,
                                int IdProperty = -1,
                                string Name = "-1",
                                string Address = "-1",
                                int Price = -1,
                                string CodeInternal = "-1",
                                int Year = -1
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
        

        // POST api/<PropertyController>
        [HttpPost]
        public IActionResult Post([FromBody] PropertyDto dto)
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

        // PUT api/<PropertyController>/5
        [HttpPut]
        public IActionResult Put([FromBody] PropertyDto dto)
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

        // DELETE api/<PropertyController>/5
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
