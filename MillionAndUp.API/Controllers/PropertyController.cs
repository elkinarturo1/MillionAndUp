using Microsoft.AspNetCore.Mvc;
using MillionAndUp.BL.V1.Properties.Property;
using MillionAndUp.Dtos.V1;
using MillionAndUp.Dtos.V1.PropertiesDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MillionAndUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {

        IPropertyBL propertyBL;

        public PropertyController(IPropertyBL p_propertyBL)
        {
            propertyBL = p_propertyBL;
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

                return Ok(propertyBL.accessData(parameters));
            }
            catch (Exception ex)
            {
                var message = new { Fail = "Ha ocurrido un error " + ex.Message };
                return StatusCode(500, message);
            }
           
        }
        

        // POST api/<PropertyController>
        [HttpPost]
        public IActionResult Post([FromBody] PropertyDto dto)
        {
            try
            {
                propertyBL.Create(dto);               
                return Ok(new { Successfull = "Proceso Terminado" });
            }
            catch (Exception ex)
            {              
                return StatusCode(500, new { Fail = "Ha ocurrido un error " + ex.Message });
            }
        }

        // PUT api/<PropertyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PropertyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
