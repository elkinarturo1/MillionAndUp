﻿using Autofac;
using AutoMapper;
using MillionAndUp.BL.V1.Services.Owner;
using MillionAndUp.BL.V1.Services.Property;
using MillionAndUp.DL.V1.Repositories.Owner;
using MillionAndUp.Dtos.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Test.BL
{   

    public class PropertyServiceTest
    {

        private IPropertyService service;
        PropertyDto dto;

        [SetUp]
        public void InitializeObjets()
        {
            dto = new PropertyDto();

            var container = new TestInyectionContainer().Container;
            service = container.Resolve<IPropertyService>();
        }


        [Test]
        public void Read_OK()
        {

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdProperty", -1);
            parameters.Add("Name", "-1");
            parameters.Add("Address", "-1");
            parameters.Add("Price", -1);
            parameters.Add("CodeInternal", "-1");
            parameters.Add("Year", -1);

            var result = (IEnumerable<PropertyDto>)service.Read(parameters);
            Assert.IsInstanceOf<IEnumerable<PropertyDto>>(result);
            Assert.IsNotNull(result);

        }


        [Test]
        public void Read_Quantity()
        {

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdProperty", -1);
            parameters.Add("Name", "-1");
            parameters.Add("Address", "-1");
            parameters.Add("Price", -1);
            parameters.Add("CodeInternal", "-1");
            parameters.Add("Year", -1);

            var result = (IEnumerable<PropertyDto>)service.Read(parameters);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<PropertyDto>>(result);
            Assert.Greater(result.Count(), 0);
        }


        [Test]
        public void Create_OK()
        {

            int id = DateTime.Now.Millisecond + 1;
            service.Delete(id);

            dto.IdProperty = id;
            dto.Name = "Corner House";
            dto.Address = "Gret Street";
            dto.Price = "1536522";
            dto.CodeInternal = "01005";
            dto.Year = "2016";
            dto.IdOwner = 1;

            service.Create(dto);

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdProperty", id);
            parameters.Add("Name", "-1");
            parameters.Add("Address", "-1");

            var result = (IEnumerable<PropertyDto>)service.Read(parameters);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstOrDefault().IdProperty, id);
            Assert.True(result.Any());

        }



        [Test]
        public void Create_Error()
        {

            int id = DateTime.Now.Millisecond + 1;

            dto.IdProperty = id;
            dto.Name = "Corner House";
            dto.Address = "Gret Street";
            dto.Price = "1536522";
            dto.CodeInternal = "01005";
            dto.Year = "2016";
            dto.IdOwner = 99999999;

            Exception exception = null;

            try
            {
                service.Create(dto);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception, "Se esperaba una excepción");
            Assert.IsTrue(exception.Message.Contains("Error al ejecutar el comando en SQL"));

        }



        [Test]
        public void Update_OK()
        {

            dto.IdProperty = 2;
            dto.Name = "Corner House";
            dto.Address = "Gret Street";
            dto.Price = "1536522";
            dto.CodeInternal = "01005";
            dto.Year = "2000";
            dto.IdOwner = 1;

            service.Update(dto);

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdProperty", dto.IdProperty);
            parameters.Add("Name", "-1");
            parameters.Add("Address", "-1");
            parameters.Add("Price", -1);
            parameters.Add("CodeInternal", "-1");
            parameters.Add("Year", -1);

            var result = (IEnumerable<PropertyDto>)service.Read(parameters);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstOrDefault().IdProperty, dto.IdProperty);
            Assert.True(result.Any());

        }


        [Test]
        public void Delete_OK()
        {

            dto.IdProperty = 2;
            dto.Name = "Corner House";
            dto.Address = "Gret Street";
            dto.Price = "1536522";
            dto.CodeInternal = "01005";
            dto.Year = "2016";
            dto.IdOwner = 1;

            service.Delete(dto.IdProperty);

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdProperty", dto.IdProperty);
            parameters.Add("Name", "-1");
            parameters.Add("Address", "-1");
            parameters.Add("Price", -1);
            parameters.Add("CodeInternal", "-1");
            parameters.Add("Year", -1);

            var result = (IEnumerable<PropertyDto>)service.Read(parameters);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 0);

            service.Create(dto);

        }

    }
}
