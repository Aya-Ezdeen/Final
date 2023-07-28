
using AutoMapper;
using Final.web.Areas.Identity.Pages.Account;
using Final.web.Data;
using Final.web.Enums;
using Final.web.Models;
using Final.web.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.web.Controllers
{
    public class UserController : Controller
    {

        private ApplicationDbContext _db;
        private UserManager<User> _UserManger;
        private RoleManager<IdentityRole> _UserRoles;
        private readonly SignInManager<User> _signInManager;
      
        public UserController( ApplicationDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManger)
        {
            _db = db;
            _UserManger = userManager;
            _UserRoles = roleManger;
         
        }

     
        public IActionResult Index()
        {
            return View();
        }

      

        [HttpGet]
        public IActionResult signw()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> signw(CreateWorkerViewModel input)
        {

            if (ModelState.IsValid) { 
                var user = new User();
               
                user.UserName = input.UserName;
                user.Email = input.Email;
                user.UserType = UserType.Worker;
                input.userType = user.UserType ;
                user.IDNumber = input.IDNumber;
                user.Section = input.Section;
                user.Governorate = input.Governorate;

            IdentityResult result = await _UserManger.CreateAsync(user, input.Password);

            if (result.Succeeded)
            {
                await _UserManger.AddToRoleAsync(user, "Worker");
                return RedirectToAction("Index");
            }
          }
            return View(input);
        }

       

        [HttpGet]
        public IActionResult signc()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> signc(CreateCustomerViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                user.UserName = input.UserName;
                user.Email = input.Email;
                user.UserType = UserType.Customer;
                input.userType = user.UserType;
                
                IdentityResult result = await _UserManger.CreateAsync(user, input.Password);

                if (result.Succeeded)
                {
                    await _UserManger.AddToRoleAsync(user, "Customer");
                    return RedirectToAction("Index");
                }
            }
            return View(input);
        }



        [HttpGet]
        public IActionResult signs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> signs(CreateStoreViewModel input)
        {

            if (ModelState.IsValid)
            {
                var user = new User();
                user.UserName = input.UserName;
                user.Email = input.Email;
                user.UserType = UserType.Store;
                input.userType = user.UserType;
                user.IDNumber = input.IDNumber;
                user.PhoneNumber = input.PhoneNumber;
                user.Section = input.Section;
                user.Governorate = input.Governorate;

                IdentityResult result = await _UserManger.CreateAsync(user, input.Password);

                if (result.Succeeded)
                {
                    await _UserManger.AddToRoleAsync(user, "Store");
                    return RedirectToAction("Index");
                }
            }
            return View(input);
        }



        public async Task<IActionResult> InitRoles()
        {
            if (!_db.Roles.Any())
            {
                var roles = new List<string>();
                roles.Add("Admin");
                roles.Add("Worker");
                roles.Add("Customer");
                roles.Add("Store");
                foreach (var role in roles)
                {
                    await _UserRoles.CreateAsync(new IdentityRole(role));
                }
            }
            return RedirectToAction("Signw");

        }

            }
}
