using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TruYum.Models;
using TruYum.ViewModel;
using TruYum;

namespace TruYum.Controllers
{
    public class MenuItemsController : Controller
    {
        private TruYumContext _context;
        bool isAdmin = false;
        public MenuItemsController()
        {
            _context = new TruYumContext();
        }

        
        
        public IActionResult Index(bool isAdmin)
        {
            
            if (isAdmin)
            {

                var results = (from items in _context.MenuItems
                               join category in _context.Categories
                                    on items.CategoryId equals category.CategoryId
                               select new NewCreateViewModel
                               {
                                   Categories = category,
                                   MenuItem = items
                               }).ToList();

              //isAdmin = false;
                return View(results);
                
                //ViewBag.items = _context.MenuItems.ToList();
                //ViewBag.categories = _context.Categories.ToList();
                /**var viewModel = new NewCreateViewModel
                {
                    ViewBag.MenuItem = items,
                    Categories = _context.Categories.ToList()
                };**/
            }
            else
            {
                try
                {
                    var cartitems = (from items in _context.MenuItems
                                     join category in _context.Categories
                                          on items.CategoryId equals category.CategoryId
                                     select new NewCreateViewModel
                                     {
                                         Categories = category,
                                         MenuItem = items
                                     }).ToList();

                    return View("CustomerIndex", cartitems);
                }
                catch (Exception ex)
                {
                    ViewBag.Exception = ex.Message;
                    ViewBag.Controller = ControllerContext.ActionDescriptor.ControllerName;
                    ViewBag.Action = ControllerContext.ActionDescriptor.ActionName;

                    return View("Error");
                }

            }
        }

        public IActionResult Create()
        {
            return View();
        }

        // Method for Creating and Adding new Item
        [HttpPost]
        public IActionResult Creat(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();
            return RedirectToAction("Index", "MenuItems", new {isAdmin=true});
        }
        //Method For New
        
        public IActionResult New()
        {
            try
            {
                //var categories =_context.Categories.ToList();
                var list = new SelectList((from c in _context.Categories select c).ToList(), "CategoryId", "Name");
                ViewBag.Category = list;
                /**var viewModel = new NewCreateViewModel
                {
                    Categories = categories,
                };**/
                return View("Create");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                ViewBag.Controller = ControllerContext.ActionDescriptor.ControllerName;
                ViewBag.Action = ControllerContext.ActionDescriptor.ActionName;

                return View("Error");
            }
        }
   
        //Method For Edit
        [HttpPost]
        public IActionResult Editing(NewCreateViewModel createmenuItem)
        {
            try
            {

                var items = _context.MenuItems.SingleOrDefault(i => i.MenuItemId == createmenuItem.MenuItem.MenuItemId);
                items.Name = createmenuItem.MenuItem.Name;
                items.Price = createmenuItem.MenuItem.Price;
                items.IsActive = createmenuItem.MenuItem.IsActive;
                items.IsFreeDelivered = createmenuItem.MenuItem.IsFreeDelivered;
                items.DateOfLaunch = createmenuItem.MenuItem.DateOfLaunch;
                items.CategoryId = createmenuItem.MenuItem.CategoryId;
                //items.Category.Name = createmenuItem.MenuItem.Name;

                _context.SaveChanges();
                return RedirectToAction("Index", "MenuItems", new {isAdmin=true});
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                ViewBag.Controller = ControllerContext.ActionDescriptor.ControllerName;
                ViewBag.Action = ControllerContext.ActionDescriptor.ActionName;
                
                return View("Error");
            }


        }

        
        public IActionResult Edit(int id)
        {
            try
            {
                if (id == null)
                    return View("Error");

                var list = new SelectList((from c in _context.Categories select c).ToList(), "CategoryId", "Name");
                ViewBag.Category = list;
                //var items = _context.MenuItems.SingleOrDefault(i => i.MenuItemId == id;
                //var results = (from c in _context.MenuItems where c.MenuItemId == id select c).First();
                //
                var results = (from items in _context.MenuItems
                               join category in _context.Categories
                                    on items.CategoryId equals category.CategoryId
                               where items.MenuItemId == id
                               select new NewCreateViewModel
                               {
                                   Categories = category,
                                   MenuItem = items
                               }).First();


                return View(results);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                ViewBag.Controller = ControllerContext.ActionDescriptor.ControllerName;
                ViewBag.Action = ControllerContext.ActionDescriptor.ActionName;

                return View("Error");
            }

            /**var viewModel = new NewCreateViewModel
            {
                MenuItem = items,
                Categories = _context.Categories.ToList()
            };
            return View("Edit", viewModel);**/
        }
    }
}
