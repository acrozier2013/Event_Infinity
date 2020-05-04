using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Event_Infinity.Data;

namespace Event_Infinity.Models
{
    public class OrderCart
    {
        public string OrderCartId;

        private Models.Event_InfinityDB db = new Models.Event_InfinityDB();
        public static OrderCart GetCart(HttpContextBase context)
        {
            OrderCart cart = new OrderCart();
            cart.OrderCartId = cart.GetCartId(context);
            return cart;
        }

        private string GetCartId(HttpContextBase context)
        {
            string CartSessionId = "CartId";

            string cartId;

            if (context.Session[CartSessionId] == null)
            {
                //create new cart id
                cartId = Guid.NewGuid().ToString();
                // Save to the session date
                context.Session[CartSessionId] = cartId;
            }
            else
            {
                //return the existing cart id
                cartId = context.Session[CartSessionId].ToString();
            }
            return cartId;
        }

        public List<Order> GetCartItems()
        {
            return db.Carts.Where(c => c.CartId == this.OrderCartId).ToList();
        }

        public void AddToCart(int eventId)
        {
            Order orderItem = db.Carts.SingleOrDefault(c => c.CartId == this.OrderCartId && c.EventId == eventId);
            Event eventOnOrder = db.Events.SingleOrDefault(c => c.EventId == eventId);

            if(orderItem == null)
            {
                //Item is not in cart: add new item
                orderItem = new Order()
                {
                    CartId = this.OrderCartId,
                    EventId = eventId,
                    CountofTickets = 1,
                    DateCreated = DateTime.Now
                };
                db.Carts.Add(orderItem);
            }
            else
            {
                //Item is already in cart: increase item count
                orderItem.CountofTickets++;
            }
            eventOnOrder.AvailableTickets--;
            db.SaveChanges();
        }

        public int RemoveFromCart(int recordId)
        {
            Order orderItem = db.Carts.SingleOrDefault(c => c.CartId == this.OrderCartId && c.RecordId == recordId);

            int newCount;

            if (orderItem.CountofTickets > 1)
            {
                // count > 1; decrement the count
                orderItem.CountofTickets--;
                newCount = orderItem.CountofTickets;
            }
            else
            {
                // count = 0; remove cart item
                db.Carts.Remove(orderItem);
                newCount = 0;
            }
            db.SaveChanges();
            return newCount;
        }
    }
}