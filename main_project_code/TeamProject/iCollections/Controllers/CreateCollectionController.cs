﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using iCollections.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using iCollections.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace iCollections.Controllers
{
    public class CreateCollectionController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ICollectionsDbContext _collectionsDbContext;

        public CreateCollectionController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, ICollectionsDbContext collectionsDbContext)
        {
            _logger = logger;
            _userManager = userManager;
            _collectionsDbContext = collectionsDbContext;
        }

        [HttpGet]
        public IActionResult EnvironmentSelection()
        {
            //TempData["name"] = "My New iCollection";
            //TempData["route"] = "gallery_environment";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EnvironmentSelection([Bind("Route")] CreateCollectionModel2 collection)
        {
            Debug.WriteLine(collection);
            //TempData.Keep();
            string id = _userManager.GetUserId(User);
            IcollectionUser appUser = _collectionsDbContext.IcollectionUsers.Where(u => u.AspnetIdentityId == id).FirstOrDefault();

            if (ModelState.IsValid)
            {
                ViewData["routeName"] = collection.Route;
                if (collection.Route != "false")
                {
                    TempData["route"] = collection.Route;
                    

                    return RedirectToAction("PhotoSelection");
                }
            }
            return View("EnvironmentSelection", collection);
        }



        [HttpGet]
        public IActionResult PhotoSelection()
        {
            TempData.Keep();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PhotoSelection(/*CreateCollectionPhotos collection*/ string[] selectedPhotos)
        {
            Debug.WriteLine(selectedPhotos);
            if (ModelState.IsValid)
            {
                TempData["photoids"] = selectedPhotos;
                /*foreach (var photo in collection.PhotosSelected)
                {

                }*/
                return RedirectToAction("PublishingOptionsSelection");
            }

            TempData.Keep();
            return View("PhotoSelection", selectedPhotos);
        }



        [HttpGet]
        public IActionResult PublishingOptionsSelection()
        {

            TempData.Keep();

            string[] dropDownList = new string[] { "private", "friends", "public" };
            ViewData["Visibility"] = new SelectList(dropDownList);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PublishingOptionsSelection([Bind("CollectionName", "Visibility", "Description")]CreateCollectionPublishing collection)
        {
            string id = _userManager.GetUserId(User);
            IcollectionUser appUser = _collectionsDbContext.IcollectionUsers.Where(u => u.AspnetIdentityId == id).FirstOrDefault();

            // Get route selection from tempdata cookie
            string route = "nothing";
            if (TempData.ContainsKey("route"))
            {
                route = TempData["route"].ToString();
            }

            
            //var checking = TempData["photoids"];
            
            //object[] photoids = new object[] { };
            if (TempData.ContainsKey("photoids"))
            {
                //var userPhotos = _collectionsDbContext.Photos.Where(u => u.UserId == appUser.Id).Select();
                //var userPhotos = _collectionsDbContext.Include()
                //var userPhotos = _collectionsDbContext.IcollectionUsers.Include("Photos").FirstOrDefault(m => m.Photos. == name).Photos;

                var objectArray = (string[])TempData["photoids"];
                //var objectArray = (object[])TempData["photoids"];
                for (var i = 0; i < objectArray.Length; i++)
                {
                    //foreach (var photo in userPhotos)
                    foreach (var photo in _collectionsDbContext.Photos.Where(u => u.UserId == appUser.Id).ToList())
                    {
                        if (objectArray[i].ToString() == photo.Id.ToString())
                        {
                            CollectionPhoto newCollectionPhoto = new CollectionPhoto();
                            string idConvert = objectArray[i].ToString();
                            newCollectionPhoto.PhotoId = Int32.Parse(idConvert);
                            newCollectionPhoto.CollectId = 1;
                            newCollectionPhoto.PhotoRank = 1;
                            newCollectionPhoto.DateAdded = DateTime.Now;
                            newCollectionPhoto.Title = "new title";
                            newCollectionPhoto.Description = "new description";
                            _collectionsDbContext.CollectionPhotos.Add(newCollectionPhoto);
                            await _collectionsDbContext.SaveChangesAsync();
                        }
                    }
                }
              
            }
                //photoids = TempData["photoids"]
            TempData.Keep();
            Debug.WriteLine(collection);
            if (ModelState.IsValid)
            {
                Collection newCollection = new Collection();
                newCollection.Route = route;
                newCollection.UserId = appUser.Id;
                newCollection.DateMade = DateTime.Now;
                newCollection.Visibility = 1;
                newCollection.Name = collection.CollectionName;
                //TempData["name"] = collection.CollectionName;

                _collectionsDbContext.Collections.Add(newCollection);
                await _collectionsDbContext.SaveChangesAsync();

                return RedirectToAction("PublishingSuccess");
            }
            string[] dropDownList = new string[] { "private", "friends", "public" };
            //var dropDownList = new []string ("high", "low", "none");
            ViewData["Visibility"] = new SelectList(dropDownList);
            //return View(collection);
            return RedirectToAction("PublishingSuccess");
        }

        [HttpGet]
        public IActionResult PublishingSuccess()
        {

            string id = _userManager.GetUserId(User);
            IcollectionUser appUser = _collectionsDbContext.IcollectionUsers.Where(u => u.AspnetIdentityId == id).FirstOrDefault();
            var collections = _collectionsDbContext.IcollectionUsers.Include("Collections").FirstOrDefault(m => m.UserName == appUser.UserName).Collections;
            //var collections = _collectionsDbContext.IcollectionUsers.FirstOrDefault(m => m.Id == appUser.Id).Collections;
            return View();
        }
    }
}
