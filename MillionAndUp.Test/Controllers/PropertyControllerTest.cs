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
        PropertyDto propertyDto;

        [SetUp]
        public void InitializeObjets()
        {
            propertyDto = new PropertyDto();

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

        //public PropertyControllerTest()
        //{

          
        //}
                

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

            propertyDto.IdProperty = id;
            propertyDto.Name = "Corner House";
            propertyDto.Address = "Gret Street";
            propertyDto.Price = "1536522";
            propertyDto.CodeInternal = "01005";
            propertyDto.Year = "2016";
            propertyDto.IdOwner = 2;

            var result = (OkObjectResult)controller.Post(propertyDto);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);

        }


        [Test]
        public void Post_Error()
        {            

            propertyDto.IdProperty = 1;
            propertyDto.Name = "Corner House";
            propertyDto.Address = "Gret Street";
            propertyDto.Price = "1536522";
            propertyDto.CodeInternal = "01005";
            propertyDto.Year = "2016";
            propertyDto.IdOwner = 2;

            var result = (ObjectResult)controller.Post(propertyDto);
            Assert.AreEqual(500, result.StatusCode);            

        }



        [Test]
        public void Put_OK()
        {        
            
            string code = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond;

            propertyDto.IdProperty = 2;
            propertyDto.Name = "Corner House";
            propertyDto.Address = "Gret Street";
            propertyDto.Price = "1536522";
            propertyDto.CodeInternal = code;
            propertyDto.Year = "2016";
            propertyDto.IdOwner = 2;

            var result = (OkObjectResult)controller.Put(propertyDto);
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


            propertyDto.IdProperty = 2;
            propertyDto.Name = "Corner House";
            propertyDto.Address = "Gret Street";
            propertyDto.Price = "1536522";
            propertyDto.CodeInternal = "01005";
            propertyDto.Year = "2016";
            propertyDto.IdOwner = 2;

            controller.Post(propertyDto);          

        }




    }
}
