using Microsoft.EntityFrameworkCore;
using System;
using User.API.Data;
using User.API;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using User.API.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;

namespace User.API.UnitTest
{
    public class UserControllerUnitTest
    {
        private UserContext GetUserContext()
        {
            var options = new DbContextOptionsBuilder<Data.UserContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new Data.UserContext(options);
            context.AppUser.Add(new Models.AppUser
            {
                Id = 1,
                Name = "lic"
            });
            context.SaveChanges();
            return context;
        }
        [Fact]
        public async Task Get_ReturnRightUser_WithExpectedParameter()
        {
            (UserController controller, UserContext userContext) = GetUserController();
            //Assert.IsType<JsonResult>(response);
            var result = controller.Should().BeOfType<JsonResult>().Subject;
            var appUser = result.Value.Should().BeAssignableTo<Models.AppUser>().Subject;
            appUser.Id.Should().Be(1);
            appUser.Name.Should().Be("lic");

        }
        private (UserController,UserContext) GetUserController(){
            var ctx = GetUserContext();
            var loggerMoq = new Mock<ILogger<UserController>>();
            var logger = loggerMoq.Object;

            var controller = new UserController(ctx, logger);
            return (controller, ctx) ;

        }
        [Fact]
        public async Task Patch_ReturnNewName_WithExpectedNewNameParameter()
        {
            //Ôª×æ
            (UserController controller,UserContext userContext)= GetUserController();
            
            var document = new JsonPatchDocument<Models.AppUser>();
            document.Replace(u => u.Name, "lei");
            var response= await controller.Patch(document);
           var result= response.Should().BeOfType<JsonResult>().Subject;
            var appUser = result.Value.Should().BeAssignableTo<Models.AppUser>().Subject;
            appUser.Name.Should().Be("lei");
            

             
        }
    }
}
