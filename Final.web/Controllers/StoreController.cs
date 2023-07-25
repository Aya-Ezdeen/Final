using Final.web.Data;
using Final.web.Models;
using Final.web.ViewModel;
using Forms.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Final.web.Controllers
{
    [Authorize(Roles = "Store")]
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileService _FileService;
        public StoreController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateProfile(string Id)
        {
            var users = _db.Users.Where(x => !x.IsDelete && x.Id == Id).Select(x => new UpdateStoreViewModel()
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                IDNumber = x.IDNumber,
                PhoneNumber = x.PhoneNumber,
                Section = x.Section,
                Governorate = x.Governorate,
            
            }).ToList();
            return View(users);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateStoreViewModel input)
        {
            //code to save database
            if (ModelState.IsValid)
            {
                var User = new User();
                User.UserName = input.UserName;
                User.Email = input.Email;
                User.IDNumber = input.IDNumber;
                User.Section = input.Section;
                User.Governorate = input.Governorate;
                User.UserType = input.userType;
                User.PhoneNumber = input.PhoneNumber;

                //if (input.ImageUrl != null)
                //{
                //    product.ImageUrl = await _FileService.SaveFile(input.ImageUrl, "Images");
                //}



                _db.Users.Add(User);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(input);
        }

        public IActionResult ViewProduct(string Id)
        {
            var Products = _db.Products.Include(x => x.StoreId == Id).Where(x => !x.IsDelete).ToList();
            return View(Products);

        }

      


        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel input)
        {
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
                    product.ImageUrl = await _FileService.SaveFile(input.ImageUrl, "Images");
                }

                product.StoreId = input.WorkerId;

                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Update");
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


    }
}
