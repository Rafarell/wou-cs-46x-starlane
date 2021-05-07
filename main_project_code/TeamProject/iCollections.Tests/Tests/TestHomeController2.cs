using System.Collections.Generic;
using System;
using GetStarted.Tests;
using NUnit.Framework;
using Moq;
using iCollections.Data.Abstract;
using iCollections.Controllers;
using iCollections.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using iCollections.Data;
using iCollections.Data.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;


//Derek Russell: User Story for Sprint 4

namespace iCollections.Tests.Tests
{
    public class TestHomeController2
    {
        private static HomeController GetHomeControllerWithLoggedInUser()
        {
            // Mock the three repos
            Mock<IcollectionRepository> mockCollectionRepo = new Mock<IcollectionRepository>();
            mockCollectionRepo.Setup(m => m.GetAll()).Returns(new Collection[]
                {
                    new Collection {Id = 10, Name = "First Collection Fish", Visibility = 1, UserId = 8, Route = "Ocean_environment"},
                    new Collection {Id = 13, Name = "Second Collection Dogs", Visibility = 1, UserId = 64, Route = "gallery_environment"},
                    new Collection {Id = 16, Name = "Third Collection Shoes", Visibility = 1, UserId = 3, Route = "gallery_environment"},
                }.AsQueryable<Collection>());

            mockCollectionRepo.Setup(m => m.GetCollectionById(10)).Returns(new Collection { Id = 10, Name = "First Collection Fish", Visibility = 1, UserId = 8, Route = "Ocean_environment" });


            Mock <IPhotoRepository> mockPhotoRepo = new Mock<IPhotoRepository>();
            mockPhotoRepo.Setup(m => m.GetAll()).Returns(new Photo[]
                {
                    new Photo {Id = 40, Name = "First Photo Fish", Data = new byte[] {1,2,3,4,5,6,7,8,10,11,12}, UserId = 8, PhotoGuid = new Guid()},
                    new Photo {Id = 41, Name = "Second Photo Fish", Data = new byte[] {1,2,3,4,5,6,7,8,10,11,12}, UserId = 8, PhotoGuid = new Guid()},
                    new Photo {Id = 45, Name = "Third Photo Shoes", Data = new byte[] {1,2,3,4,5,6,7,8,10,11,12}, UserId = 3, PhotoGuid = new Guid()},
                    new Photo {Id = 48, Name = "Fourth Photo Dogs", Data = new byte[] {1,2,3,4,5,6,7,8,10,11,12}, UserId = 64, PhotoGuid = new Guid()},
                }.AsQueryable<Photo>());

            mockPhotoRepo.Setup(m => m.GetAllUserPhotos(8)).Returns(new List<Photo>
                {
                    new Photo {Id = 40, Name = "First Photo Fish", Data = new byte[] {1,2,3,4,5,6,7,8,10,11,12}, UserId = 8, PhotoGuid = new Guid()},
                    new Photo {Id = 41, Name = "Second Photo Fish", Data = new byte[] {1,2,3,4,5,6,7,8,10,11,12}, UserId = 8, PhotoGuid = new Guid()},
                });


            Mock<ICollectionPhotoRepository> mockCollectionPhotoRepo = new Mock<ICollectionPhotoRepository>();
            mockCollectionPhotoRepo.Setup(m => m.GetAll()).Returns(new CollectionPhoto[]
                {
                    new CollectionPhoto {Id = 80, CollectId = 10, PhotoId = 40, PhotoRank = 1, Title = "First Photo FIsh", Description = "First Description"},
                    new CollectionPhoto {Id = 81, CollectId = 10, PhotoId = 41, PhotoRank = 2, Title = "Second Photo FIsh", Description = "Second Description"},
                    new CollectionPhoto {Id = 82, CollectId = 13, PhotoId = 45, PhotoRank = 1, Title = "Third Photo Shoes", Description = "Third Description"},
                    new CollectionPhoto {Id = 83, CollectId = 16, PhotoId = 48, PhotoRank = 1, Title = "Fourth Photo Dogs", Description = "Fourth Description"},
                }.AsQueryable<CollectionPhoto>());

            mockCollectionPhotoRepo.Setup(m => m.GetAllCollectionPhotosbyCollectionId(10)).Returns(new List<CollectionPhoto>
                {
                    new CollectionPhoto {Id = 80, CollectId = 10, PhotoId = 40, PhotoRank = 1, Title = "First Photo FIsh", Description = "First Description"},
                    new CollectionPhoto {Id = 81, CollectId = 10, PhotoId = 41, PhotoRank = 2, Title = "Second Photo FIsh", Description = "Second Description"},

                });

            // Mock a user store, which the user manager needs to access the data layer, "contains methods for adding, removing and retrieving user claims."
            var mockStore = new Mock<IUserStore<IdentityUser>>();
            mockStore.Setup(x => x.FindByIdAsync("aabbcc", CancellationToken.None))
                .ReturnsAsync(new IdentityUser()
                {
                    UserName = "test@email.com",
                    Id = "aabbcc"
                });

            // Mock the user manager, only so far as it returns one valid user (can change this to return user not found for other tests)
            Mock<UserManager<IdentityUser>> mockUserManager = new Mock<UserManager<IdentityUser>>(mockStore.Object, null, null, null, null, null, null, null, null);

            /*    var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "1"),
                }));
            */
            // Set it up enough so it doesn't return null, i.e. just some user
            mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(
                new IdentityUser
                {
                    Id = "aabbcc",
                    Email = "test@email.com"
                });

            // Mock the HttpContext since quite a bit of functionality comes from it
            Mock<HttpContext> mockContext = new Mock<HttpContext>();
            mockContext.SetupGet(ctx => ctx.User.Identity.Name).Returns("test@email.com");

            HomeController controller = new HomeController(null, mockUserManager.Object, null, mockPhotoRepo.Object, mockCollectionRepo.Object, mockCollectionPhotoRepo.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = mockContext.Object
                }
            };

            return controller;
        }




        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void HomeController_LoggedInUserIsSetInVM()
        {
            HomeController controller = GetHomeControllerWithLoggedInUser();

            IActionResult result = controller.Ocean_environment(10);
            
            string username = controller.User.Identity.Name;        // <-- this one works because we set it up with: mockContext.SetupGet(ctx => ctx.User.Identity.Name).Returns()
  
            Assert.That(username, Is.EqualTo("test@email.com"));
            
        }


        [Test]
        public void HomeController_HasOceanEnvironmentEndpoint()
        {
            HomeController controller = GetHomeControllerWithLoggedInUser();

            var result = controller.Ocean_environment(10);

            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void HomeController_HasGalleryEnvironmentEndpoint()
        {
            HomeController controller = GetHomeControllerWithLoggedInUser();

            var result = controller.gallery_environment(10);

            Assert.That(result, Is.TypeOf<ViewResult>());
        }


        [Test]
        public void HomeController_OceanEnvironmentCollectionHas2Photos()
        {
            HomeController controller = GetHomeControllerWithLoggedInUser();

            IActionResult result = controller.Ocean_environment(10);

            List<RenderingPhoto> vm = (result as ViewResult).Model as List<RenderingPhoto>;

            Assert.That(vm.Count, Is.EqualTo(2));
        }





        /*[Test]
        [Ignore("Ignore a test")]
        public void HomeController_JustGetADamnCollection()
        {
            List<Collection> collections = new List<Collection>
                {
                    new Collection {Id = 10, Name = "First Collection Fish", Visibility = 1, UserId = 8, Route = "Ocean_environment"},
                    new Collection {Id = 13, Name = "Second Collection Dogs", Visibility = 1, UserId = 64, Route = "gallery_environment"},
                    new Collection {Id = 16, Name = "Third Collection Shoes", Visibility = 1, UserId = 3, Route = "gallery_environment"},
                };


            //Mock<DbSet<Collection>> mockCollectionDbSet = GetMockDbSet(collections.AsQueryable());

            Mock<ICollectionsDbContext> mockContext = new Mock<ICollectionsDbContext>();
            mockContext.Setup(ctx => ctx.Collections).Returns(mockCollectionDbSet.Object);

            // Arrange 
            IcollectionRepository collectionRepo = new CollectionRepository(mockContext.Object);

            // Act
            Collection selectedCollection = collectionRepo.GetCollectionById(10);

            // Assert
            Assert.That(selectedCollection.Name, Is.EqualTo("First Collection Fish"));
        }*/





    }
}