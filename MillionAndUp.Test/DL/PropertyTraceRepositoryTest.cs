﻿using Autofac;
using MillionAndUp.DL.V1.Repositories.PropertyImage;
using MillionAndUp.DL.V1.Repositories.PropertyTrace;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Test.DL
{
    public class PropertyTraceRepositoryTest
    {

        private IPropertyTraceRepository service;
        PropertyTraceEntity dto;

        [SetUp]
        public void InitializeObjets()
        {
            dto = new PropertyTraceEntity();

            var container = new TestInyectionContainer().Container;
            service = container.Resolve<IPropertyTraceRepository>();
        }


        [Test]
        public void Read_OK()
        {

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdPropertyTrace", -1);
            parameters.Add("IdProperty", -1);
            parameters.Add("Name", "-1");

            var result = (IEnumerable<PropertyTraceEntity>)service.Read(parameters);
            Assert.IsInstanceOf<IEnumerable<PropertyTraceEntity>>(result);
            Assert.IsNotNull(result);

        }


        [Test]
        public void Read_Quantity()
        {

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdPropertyTrace", -1);
            parameters.Add("IdProperty", -1);
            parameters.Add("Name", "-1");

            var result = (IEnumerable<PropertyTraceEntity>)service.Read(parameters);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<PropertyTraceEntity>>(result);
            Assert.Greater(result.Count(), 0);
        }


        [Test]
        public void Create_OK()
        {

            int id = DateTime.Now.Millisecond;
            service.Delete(id);

            dto.IdPropertyTrace = id;
            dto.IdProperty = 1;
            dto.Name = "Trace" + DateTime.Now.Millisecond;
            dto.Value = "1025622";
            dto.Tax = "19";
            dto.DateSale = "12/12/2021";

            service.Create(dto);

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdPropertyTrace", id);
            parameters.Add("IdProperty", -1);
            parameters.Add("Name", "-1");

            var result = (IEnumerable<PropertyTraceEntity>)service.Read(parameters);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstOrDefault().IdPropertyTrace, dto.IdPropertyTrace);
            Assert.True(result.Any());

        }



        [Test]
        public void Create_Error()
        {

            int id = DateTime.Now.Millisecond;

            dto.IdPropertyTrace = id;
            dto.IdProperty = 1;
            dto.Name = "Trace" + DateTime.Now.Millisecond;
            dto.Value = "1025622";
            dto.Tax = "19";
            dto.DateSale = "123";

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

            dto.IdPropertyTrace = 2;
            dto.IdProperty = 1;
            dto.Name = "Trace" + DateTime.Now.Millisecond;
            dto.Value = "1025622";
            dto.Tax = "20";
            dto.DateSale = "10/09/2010";

            service.Update(dto);

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdPropertyTrace", dto.IdPropertyTrace);
            parameters.Add("IdProperty", -1);

            var result = (IEnumerable<PropertyTraceEntity>)service.Read(parameters);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstOrDefault().IdPropertyTrace, dto.IdPropertyTrace);
            Assert.True(result.Any());

        }


        [Test]
        public void Delete_OK()
        {

            dto.IdPropertyTrace = 2;
            dto.IdProperty = 1;
            dto.Name = "Trace" + DateTime.Now.Millisecond;
            dto.Value = "1025622";
            dto.Tax = "19";
            dto.DateSale = "04/08/2008";

            service.Delete(dto.IdPropertyTrace);

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdPropertyTrace", dto.IdPropertyTrace);
            parameters.Add("IdProperty", -1);
            parameters.Add("Name", "-1");

            var result = (IEnumerable<PropertyTraceEntity>)service.Read(parameters);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 0);

            service.Create(dto);

        }

    }
}
