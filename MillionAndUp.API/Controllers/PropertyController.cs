using Microsoft.AspNetCore.Mvc;
using MillionAndUp.BL.V1.Properties.Property;
using MillionAndUp.Dtos.V1;

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
        public IActionResult Get(int page = 1, int rowsCount = 10)
        {

            try
            {

                
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                foreach (var item in HttpContext.Request.Query)
                {
                    parameters.Add("@" + item.Key, item.Value.ToString());
                }

                //parametersDTO.parameters.Add("@IdProperty",HttpContext.Request.Query["IdProperty"]);
                //parametersDTO.parameters.Add("@Name", HttpContext.Request.Query["Name"]);
                //parametersDTO.parameters.Add("@Address", HttpContext.Request.Query["Address"]);
                //parametersDTO.parameters.Add("@Price", HttpContext.Request.Query["Price"]);
                //parametersDTO.parameters.Add("@CodeInternal", HttpContext.Request.Query["CodeInternal"]);
                //parametersDTO.parameters.Add("@Year", HttpContext.Request.Query["Year"]);

                //parametersDTO.parameters.Add("@page", HttpContext.Request.Query["page"].ToString());
                //parametersDTO.parameters.Add("@RowsCount", HttpContext.Request.Query["RowsCount"].ToString());

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
        public void Post([FromBody] string value)
        {
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
