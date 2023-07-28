using AutoMapper;
using Final.web.Data;
using Final.web.Models;
using Final.web.ViewModel;
using Forms.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.web.Controllers
{
    [Authorize(Roles = "Worker")]
    public class WorkerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileService _FileService;
        private IMapper _mapper;
        private UserManager<User> _UserManger;
        public WorkerController(IMapper mapper ,ApplicationDbContext db, IFileService FileService, UserManager<User> UserManger)
        {
            _db = db;
            _FileService = FileService;
            _mapper = mapper;
            _UserManger = UserManger;
        }
        public IActionResult Index()

        {
            string Email = @User.Identity.Name;
            var user = _db.Users.SingleOrDefault(x => !x.IsDelete && x.UserName == Email);
            return View(user);
        }

      
        [HttpGet]
        public IActionResult UpdateProfile()
        {
            string Email = @User.Identity.Name;
            //var user = _db.Users.SingleOrDefault(x => !x.IsDelete && x.UserName == Email);
            //var usersVm = _mapper.Map<UpdateWorkerViewModel>(user);
            var user = _db.Users.Where(x => !x.IsDelete && x.UserName == Email).Select(x => new UpdateWorkerViewModel()
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                IDNumber = x.IDNumber,
                PhoneNumber=x.PhoneNumber,
                Section = x.Section,
                Governorate = x.Governorate,
                userType = x.UserType,
             
            }).SingleOrDefault();

            return View(user);
           
        }

        [HttpPost]
        public IActionResult UpdateProfile(UpdateWorkerViewModel input)
        {

            //code to save database
            if (ModelState.IsValid)
            {
                var User = _db.Users.SingleOrDefault(x => !x.IsDelete && x.UserName == input. Email);
               
                User.UserName = input.UserName;
              
                User.Email = input.Email;
                User.IDNumber = input.IDNumber;
                User.PhoneNumber = input.PhoneNumber;
                User.Section = input.Section;
                User.Governorate = input.Governorate;
                User.UserType = Enums.UserType.Worker;


                //if (input.ImageUrl != null)
                //{
                //    product.ImageUrl = await _FileService.SaveFile(input.ImageUrl, "Images");
                //}



              _db.Users.Update(User);

               
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(input);
        }

        public IActionResult ViewProduct()
        {
           var Email = @User.Identity.Name;
            var user = _db.Users.SingleOrDefault(x => !x.IsDelete && x.UserName == Email);
            var Products = _db.Products.Where(x => !x.IsDelete && x.StoreId == user.Id ).ToList();
            return View(Products);
          
        }

     


        [HttpGet]

        public IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel input)
        {
           string Email = @User.Identity.Name;
            var user = _db.Users.SingleOrDefault(x => !x.IsDelete && x.UserName == Email);
            //code to save database
            if (ModelState.IsValid)
            {
                var product = new Product();
                product.Name = input.Name;
                product.Price = input.Price;
                product.Description = input.Description;
                product.Section = input.Section;
                product.Governorate = input.Governorate;
                if (input.ImageUrl != null)
                {
                    product.ImageUrl = await _FileService.SaveFile(input.ImageUrl, "ImagesProduct");
                }

                product.StoreId = user.Id;
               
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("ViewProduct");
            }
            return View(input);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var Product = _db.Products.SingleOrDefault(x => x.id == Id && !x.IsDelete);
            if (Product == null)
            {
                return NotFound();
            }
            var Vm = new UpdateProductViewModel();
            Vm.Name = Product.Name;
            Vm.Price = Product.Price;
            Vm.Description = Product.Description;
            Vm.Section = Product.Section;
            Vm.Governorate = Product.Governorate;
            Vm.Id = Product.id;
            Vm.WorkerId = Product.StoreId;

            Product.ImageUrl = await _FileService.SaveFile(Vm.ImageUrl, "Images");
            
            return View(Vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductViewModel update)
        {
            if (ModelState.IsValid)
            {
                var Product = _db.Products.SingleOrDefault(x => x.id == update.Id && !x.IsDelete);
                if (Product == null)
                {
                    return NotFound();
                }
                Product.Name = update.Name;
                Product.Price = update.Price;
                Product.Description = update.Description;
                Product.Section = update.Section;
                Product.Governorate = update.Governorate;
               
                

                Product.ImageUrl = await _FileService.SaveFile(update.ImageUrl, "Images");


              
                _db.Products.Update(Product);
                _db.SaveChanges();
                return RedirectToAction("ViewProduct");
            }

            return View(update);
        }


        public IActionResult Delete(int Id)
        {
            var Product = _db.Products.SingleOrDefault(x => x.id == Id && !x.IsDelete);
            Product.IsDelete = true;
            _db.Products.Update(Product);
            _db.SaveChanges();
            return RedirectToAction("ViewProduct");

        }

    }
}
