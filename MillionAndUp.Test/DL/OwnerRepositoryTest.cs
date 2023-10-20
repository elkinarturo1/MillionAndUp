using Autofac;
using MillionAndUp.BL.V1.Services.Owner;
using MillionAndUp.DL.V1.Repositories.Owner;
using MillionAndUp.Dtos.V1;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Test.DL
{
    public class OwnerRepositoryTest
    {

        private IOwnerRepository service;
        OwnerEntity dto;

        [SetUp]
        public void InitializeObjets()
        {
            dto = new OwnerEntity();

            var container = new TestInyectionContainer().Container;
            service = container.Resolve<IOwnerRepository>();
        }


        [Test]
        public void Read_OK()
        {

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdOwner", -1);
            parameters.Add("Name", "-1");
            parameters.Add("Address", "-1");

            var result = (IEnumerable<OwnerEntity>)service.Read(parameters);
            Assert.IsInstanceOf<IEnumerable<OwnerEntity>>(result);
            Assert.IsNotNull(result);

        }


        [Test]
        public void Read_Quantity()
        {

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdOwner", -1);
            parameters.Add("Name", "-1");
            parameters.Add("Address", "-1");

            var result = (IEnumerable<OwnerEntity>)service.Read(parameters);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<OwnerEntity>>(result);
            Assert.Greater(result.Count(), 0);
        }


        [Test]
        public void Create_OK()
        {

            int id = DateTime.Now.Millisecond;
            service.Delete(id);

            dto.IdOwner = id;
            dto.Name = "Gerard";
            dto.Address = "Great Street";
            dto.Photo = "data:image/jpeg;base64,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";
            dto.Birthday = "21/12/2000";

            service.Create(dto);

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdOwner", id);
            parameters.Add("Name", "-1");
            parameters.Add("Address", "-1");

            var result = (IEnumerable<OwnerEntity>)service.Read(parameters);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstOrDefault().IdOwner, dto.IdOwner);
            Assert.True(result.Any());

        }



        [Test]
        public void Create_Error()
        {

            int id = DateTime.Now.Millisecond;

            dto.IdOwner = id;
            dto.Name = "Gerard";
            dto.Address = "Great Street";
            dto.Photo = "data:image/jpeg;base64,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";
            dto.Birthday = "123";

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

            dto.IdOwner = 2;
            dto.Name = "Gerard";
            dto.Address = "Great Street";
            dto.Photo = "data:image/jpeg;base64,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";
            dto.Birthday = "20/11/1999";

            service.Update(dto);

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdOwner", dto.IdOwner);
            parameters.Add("Name", "-1");
            parameters.Add("Address", "-1");

            var result = (IEnumerable<OwnerEntity>)service.Read(parameters);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstOrDefault().IdOwner, dto.IdOwner);
            Assert.True(result.Any());

        }


        [Test]
        public void Delete_OK()
        {

            dto.IdOwner = 2;
            dto.Name = "Gerard";
            dto.Address = "Great Street";
            dto.Photo = "data:image/jpeg;base64,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";
            dto.Birthday = "20/11/1999";

            service.Delete(dto.IdOwner);

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("page", 1);
            parameters.Add("rowsCount", 10);
            parameters.Add("IdOwner", dto.IdOwner);
            parameters.Add("Name", "-1");
            parameters.Add("Address", "-1");

            var result = (IEnumerable<OwnerEntity>)service.Read(parameters);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 0);

            service.Create(dto);

        }


    }
}
