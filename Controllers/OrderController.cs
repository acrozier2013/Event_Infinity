using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Event_Infinity.Models;
using Event_Infinity.Data;

namespace Event_Infinity.Controllers
{
    public class OrderController : Controller
    {
        private Models.Event_InfinityDB db = new Models.Event_InfinityDB();
        // GET: Order
        public ActionResult Index()
        {
            OrderCart cart = OrderCart.GetCart(this.HttpContext);
            OrderCartViewModel vm = new OrderCartViewModel()
            {
                OrderItems = cart.GetCartItems()
            };
            return View(vm);
        }

        //GET: Order/AddToOrder
        public ActionResult AddToCart(int id)
        {
            //OrderCart cart = new OrderCart();
            OrderCart cart = OrderCart.GetCart(this.HttpContext);
            cart.AddToCart(id);
            return RedirectToAction("Index");
        }

        //POST: Order/RemoveFromCart
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            OrderCart cart = OrderCart.GetCart(this.HttpContext);
            
            Event _event = db.Carts.SingleOrDefault(c => c.RecordId == id).EventSelected;
            int newItemCount = cart.RemoveFromCart(id);
           // cart.RemoveFromCart(id);
            ShoppingCartRemoveViewModel vm = new ShoppingCartRemoveViewModel()
            {
                DeleteId = id,
                ItemCount = newItemCount,
                Message = _event.EventTitle + " has been removed from the cart"
            };

            return Json(vm);
        }
    }
}