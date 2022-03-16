using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Identity;
using TusbifoodMicroservice.Context;

namespace TusbifoodMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly TusbiFoodContext _context;
        private readonly UserManager<AspNetUser> _userManager;

        public ShoppingCartsController(TusbiFoodContext context, UserManager<AspNetUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Кнотроллер для админа
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductShoppingCart>>> GetProductShoppingCarts()
        {
            return await _context.ProductShoppingCarts.ToListAsync();
        }

        /// <summary>
        /// Controller for Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductShoppingCart>> GetProductShoppingCart(int id)
        {
            var productShoppingCart = await _context.ProductShoppingCarts.FindAsync(id);

            if (productShoppingCart == null)
            {
                return NotFound();
            }

            return productShoppingCart;
        }

        // POST: api/ProductShoppingCarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult<ProductShoppingCart>> PostProductShoppingCart(int CartId, int productId)
        {
            var productShoppingCart = new ProductShoppingCart()
            {
                ShoppingCartsId = CartId,
                ProductsId = productId
            };
            _context.ProductShoppingCarts.Add(new ProductShoppingCart() {ShoppingCartsId = CartId, ProductsId = productId});
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductShoppingCartExists(productShoppingCart.ProductsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductShoppingCart", new { id = productShoppingCart.ProductsId }, productShoppingCart);
        }

        // DELETE: api/ProductShoppingCarts/5
        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProductShoppingCart(int CartId, int ProductId)
        {
            var productShoppingCart = await _context.ProductShoppingCarts.FindAsync(CartId, ProductId);
            if (productShoppingCart == null)
            {
                return NotFound();
            }

            _context.ProductShoppingCarts.Remove(productShoppingCart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("GetProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsFromCart(int cartId)
        {
            var productShoppingCart = await _context.ProductShoppingCarts.Where(e => e.ShoppingCartsId == cartId).Select(p => p.ProductsId).ToListAsync();
            return await _context.Products.Where(e => productShoppingCart.Contains(e.Id)).ToListAsync();
        }

        [HttpPut]
        [Route("CartToOrder")]
        public async Task CartToOrder()
        {
            ClaimsPrincipal claimsPrincipal = HttpContext.User as ClaimsPrincipal;
            string UserId = _userManager.GetUserId(claimsPrincipal);
            Order order = new Order();
            UserProfile userProfile = _context.UserProfiles.Include(a => a.ShoppingCart).FirstOrDefault<UserProfile>(e => e.AspNetUserId == UserId);
            try
            {
                _context.Orders.Add(new Order() { UserProfileId = userProfile.Id, Status = OrderStatus.Неоплачен });
                await _context.SaveChangesAsync();
                order = _context.Orders.FirstOrDefault(a => a.UserProfileId == userProfile.Id || a.Status == OrderStatus.Неоплачен);
                foreach (var a in _context.ProductShoppingCarts.Where(f => f.ShoppingCartsId == userProfile.ShoppingCart.Id).ToList())
                {
                    _context.OrderProducts.Add(new OrderProduct() { OrdersId = order.Id, ProductsId = a.ProductsId });
                }
                Seat seat = _context.Seats.FirstOrDefault(a => a.ShoppingCartId == userProfile.ShoppingCart.Id);
                if(seat != null)
                    order.Seats.Add(seat);


                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (order.Seats.Count < 1)
                    Conflict("Выбереите место");
                throw;
            }
        }
        private bool ProductShoppingCartExists(int id)
        {
            return _context.ProductShoppingCarts.Any(e => e.ProductsId == id);
        }
    }
}
