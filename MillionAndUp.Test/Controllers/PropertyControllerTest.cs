using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MillionAndUp.API.Controllers;
using MillionAndUp.BL.V1.Services.Property;
using MillionAndUp.DL.V1.Repositories.Property;
using MillionAndUp.Dtos.V1;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Test.Controllers
{
    public class PropertyControllerTest
    {

        private IPropertyService service;
        private PropertyController controller;
        private HttpContext httpContext;
        PropertyDto dto;

        [SetUp]
        public void InitializeObjets()
        {
            dto = new PropertyDto();

            // Configura un contexto HTTP falso utilizando Moq
            var httpContextMock = new Mock<HttpContext>();
            var requestMock = new Mock<HttpRequest>();
            var queryCollection = new QueryCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>());
            requestMock.Setup(r => r.Query).Returns(queryCollection);
            httpContextMock.Setup(c => c.Request).Returns(requestMock.Object);



            // Crea una instancia de tu contenedor de inyección de dependencias
            var container = new TestInyectionContainer().Container;

            // Utiliza el contenedor configurado para resolver las dependencias
            service = container.Resolve<IPropertyService>();

            // Crea el controlador y pasa la implementación de IPropertyService
            controller = new PropertyController(service)
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
            Assert.IsInstanceOf<List<PropertyDto>>(result.Value);
            var properies = (List<PropertyDto>)result.Value;
            Assert.Greater(properies.Count,0);
        }



        [Test]
        public void Post_OK()
        {            

            int id = DateTime.Now.Millisecond;            
            controller.Delete(id);

            dto.IdProperty = id;
            dto.Name = "Corner House";
            dto.Address = "Gret Street";
            dto.Price = "1536522";
            dto.CodeInternal = "01005";
            dto.Year = "2016";
            dto.IdOwner = 1;

            var result = (OkObjectResult)controller.Post(dto);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);

        }


        [Test]
        public void Post_Error()
        {            

            dto.IdProperty = 2;
            dto.Name = "Corner House";
            dto.Address = "Gret Street";
            dto.Price = "1536522";
            dto.CodeInternal = "01005";
            dto.Year = "2016";
            dto.IdOwner = 2;

            var result = (ObjectResult)controller.Post(dto);
            Assert.AreEqual(500, result.StatusCode);            

        }



        [Test]
        public void Put_OK()
        {        
            
            string code = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond;

            dto.IdProperty = 2;
            dto.Name = "Corner House";
            dto.Address = "Gret Street";
            dto.Price = "1536522";
            dto.CodeInternal = code;
            dto.Year = "2016";
            dto.IdOwner = 2;

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


            dto.IdProperty = 2;
            dto.Name = "Corner House";
            dto.Address = "Gret Street";
            dto.Price = "1536522";
            dto.CodeInternal = "01005";
            dto.Year = "2016";
            dto.IdOwner = 2;

            controller.Post(dto);          

        }

    }
}
