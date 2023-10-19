using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MillionAndUp.API.Controllers;
using MillionAndUp.BL.V1.Services.PropertyTrace;
using MillionAndUp.Dtos.V1;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Test.Controllers
{
    public class PropertyTraceControllerTest
    {

        private IPropertyTraceService service;
        private PropertyTraceController controller;
        private HttpContext httpContext;
        PropertyTraceDto dto;

        [SetUp]
        public void InitializeObjets()
        {
            dto = new PropertyTraceDto();

            // Configura un contexto HTTP falso utilizando Moq
            var httpContextMock = new Mock<HttpContext>();
            var requestMock = new Mock<HttpRequest>();
            var queryCollection = new QueryCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>());
            requestMock.Setup(r => r.Query).Returns(queryCollection);
            httpContextMock.Setup(c => c.Request).Returns(requestMock.Object);



            // Crea una instancia de tu contenedor de inyección de dependencias
            var container = new TestInyectionContainer().Container;

            // Utiliza el contenedor configurado para resolver las dependencias
            service = container.Resolve<IPropertyTraceService>();

            // Crea el controlador y pasa la implementación de IPropertyService
            controller = new PropertyTraceController(service)
            {
                ControllerContext = new ControllerContext { HttpContext = httpContextMock.Object }
            };
        }


        [Test]
        public void Get_OK()
        {
            var result = controller.Get();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }


        [Test]
        public void Get_Quantity()
        {
            var result = (OkObjectResult)controller.Get();
            Assert.IsInstanceOf<List<PropertyTraceDto>>(result.Value);
            var properies = (List<PropertyTraceDto>)result.Value;
            Assert.Greater(properies.Count, 0);
        }



        [Test]
        public void Post_OK()
        {

            int id = DateTime.Now.Millisecond;
            controller.Delete(id);

            dto.IdPropertyTrace = id;
            dto.IdProperty = 1;
            dto.Name = "Trace" + DateTime.Now.Millisecond;
            dto.Value = "1025622";
            dto.Tax = "19";
            dto.DateSale = "12/12/2021";

            var result = (OkObjectResult)controller.Post(dto);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);

        }


        [Test]
        public void Post_Error()
        {

            int id = DateTime.Now.Millisecond;
            controller.Delete(id);

            dto.IdPropertyTrace = id;
            dto.IdProperty = 1;
            dto.Name = "Trace" + DateTime.Now.Millisecond;
            dto.Value = "1025622";
            dto.Tax = "19";
            dto.DateSale = "123";

            var result = (ObjectResult)controller.Post(dto);
            Assert.AreEqual(500, result.StatusCode);

        }



        [Test]
        public void Put_OK()
        {

            dto.IdPropertyTrace = 2;
            dto.IdProperty = 1;
            dto.Name = "Trace" + DateTime.Now.Millisecond;
            dto.Value = "1025622";
            dto.Tax = "20";
            dto.DateSale = "10/09/2010";

            var result = (OkObjectResult)controller.Put(dto);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);

        }


        [Test]
        public void Delete_OK()
        {

            int id = 2;
            var result = (OkObjectResult)controller.Delete(id);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);

            dto.IdPropertyTrace = id;
            dto.IdProperty = 1;
            dto.Name = "Trace" + DateTime.Now.Millisecond;
            dto.Value = "1025622";
            dto.Tax = "19";
            dto.DateSale = "04/08/2008";

            controller.Post(dto);

        }


    }
}
