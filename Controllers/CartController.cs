using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using TruYum.Models;
using TruYum.ViewModel;

namespace TruYum.Controllers
{
    public class CartController : Controller
    {
        private TruYumContext _context;
        public CartController()
        {
            _context = new TruYumContext();
        }
        public IActionResult Index()
        {


            return RedirectToAction("ShowItems","Cart", new { userId = 1 });
        }

        public IActionResult ShowItems()
        {
            try
            {
                //var cart = _context.Carts.Include(c => c.MenuItem).ToList();
                var data = (from item in _context.MenuItems
                            join cartt in _context.Carts
                            on item.MenuItemId equals cartt.MenuItemId
                            select new CartMenu
                            {
                                MenuItem = item,
                                Cart = cartt
                            }).ToList();

                return View("MenuItemdetail", data);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                ViewBag.Controller = ControllerContext.ActionDescriptor.ControllerName;
                ViewBag.Action = ControllerContext.ActionDescriptor.ActionName;

                return View("Error");
            }
        }
        public IActionResult Remove(int id)
        {
            try
            {
                var data = _context.Carts.FirstOrDefault(x => x.Id == id);
                _context.Carts.Remove(data);
                _context.SaveChanges();
                return RedirectToAction("Index", "Cart");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                ViewBag.Controller = ControllerContext.ActionDescriptor.ControllerName;
                ViewBag.Action = ControllerContext.ActionDescriptor.ActionName;

                return View("Error");
            }
        }
        public IActionResult AddToCart(int menuItemid)
        {
            try
            {
                
                if (menuItemid == null)
                    return View("Error");
                //var cart = _context.Carts.Include(c => c.MenuItem).ToList();
                var c = new Cart();
                var items = _context.MenuItems.SingleOrDefault(i => i.MenuItemId == menuItemid);
                c.Name = items.Name;
                c.IsFreeDelivered = items.IsFreeDelivered;
                c.Price = items.Price;
                c.TypeOfItem = items.TypeOfItem;
                c.MenuItemId = items.MenuItemId;
                _context.Carts.Add(c);
                _context.SaveChanges();


                //var cart = new Cart();
                // cart.MenuItemId = menuItemid;

                return RedirectToAction("Index", "Cart");
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
}
