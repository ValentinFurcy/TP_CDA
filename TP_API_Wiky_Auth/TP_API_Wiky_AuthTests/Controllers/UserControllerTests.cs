using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_API_Wiky_Auth.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using Azure;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TP_API_Wiky_Auth.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public async Task  RegisterUserTest()
        {
            //Arrange 
            var controller = new UserController(null,null, null, null);
            var userRegisterDTO = new UserRegisterDTO
            {
                BirthDate = new DateTime(2020, 12, 10),
                UserName = "Ilok",
                Email = "ilok@test.fr",
                Password = "Pa$$word1+"                
            };

            var result = await controller.RegisterUser(userRegisterDTO);


            var test = result as BadRequestObjectResult;
            Assert.AreEqual((int)HttpStatusCode.BadRequest, test.StatusCode);
                     
        }
    }
}