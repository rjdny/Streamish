using Microsoft.AspNetCore.Mvc;
using Streamish.Controllers;
using Streamish.Models;
using Streamish.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Streamish.Tests
{
    public class UserProfileControllerTests
    {
        private List<UserProfile> CreateTestUserProfiles(int count)
        {
            List<UserProfile> _temp = new List<UserProfile>(count);
            for (int i = 0; i < count; i++)
            {
                _temp.Add(new UserProfile()
                {
                    Id = i,
                    Name = $"User {i}",
                    Email = $"user{i}@example.com",
                    DateCreated = DateTime.Today.AddDays(i),
                    ImageUrl = $"http://user.url/{i}",
                });
            }
            return _temp;
        }



        [Fact]
        public void Get_Returns_All_UserProfiles()
        {
            // Arrange 
            var userCount = 20;
            var users = CreateTestUserProfiles(userCount);


            var repo = new InMemoryUserProfileRepository(users);
            var controller = new UserProfileController(repo);

            // Act 
            var result = controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualUsers = Assert.IsType<List<UserProfile>>(okResult.Value);

            Assert.Equal(userCount, actualUsers.Count);
            Assert.Equal(users, actualUsers);
        }

        [Fact]
        public void Get_By_Id_Returns_NotFound_When_Given_Unknown_id()
        {
            // Arrange 
            var users = new List<UserProfile>(); //No Users

            var repo = new InMemoryUserProfileRepository(users);
            var controller = new UserProfileController(repo);

            // Act
            var result = controller.Get(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Get_By_Id_Returns_UserProfile_With_Given_Id()
        {
            // Arrange
            var testUserProfileId = 99;
            var UserProfiles = CreateTestUserProfiles(5);
            UserProfiles[0].Id = testUserProfileId; // Make sure we know the Id of one of the UserProfiles

            var repo = new InMemoryUserProfileRepository(UserProfiles);
            var controller = new UserProfileController(repo);

            // Act
            var result = controller.Get(testUserProfileId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualUser = Assert.IsType<UserProfile>(okResult.Value);

            Assert.Equal(testUserProfileId, actualUser.Id);
        }

        [Fact]
        public void Post_Method_Adds_A_New_UserProfile()
        {
            // Arrange 
            var userCount = 20;
            var users = CreateTestUserProfiles(userCount);

            var repo = new InMemoryUserProfileRepository(users);
            var controller = new UserProfileController(repo);

            // Act
            var newUserProfile = new UserProfile()
            {
                Name = "User",
                Email = "user@example.com",
                DateCreated = DateTime.Today.AddDays(0),
                ImageUrl = "http://user.url/"
            };

            controller.Post(newUserProfile);

            // Assert
            Assert.Equal(userCount + 1, repo.InternalData.Count);
        }
    }
}
