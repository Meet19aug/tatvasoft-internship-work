using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class CartRepository : BaseRepository
    {
        public ListResponse<Cart> GetCarts(int pageIndex, int pageSize, string keyword)
        {
            keyword = keyword?.ToLower()?.Trim();
            var query = _context.Carts.Include(c => c.Book).Where(c => keyword == null || c.Book.Name.ToLower().Contains(keyword)).AsQueryable();
            int totalRecords = query.Count();
            List<Cart> categories = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new ListResponse<Cart>
            {
                Results = categories,
                TotalRecords = totalRecords,
            };
        }
        public Cart GetCart(int id)
        {
            return _context.Carts.FirstOrDefault(c => c.Id == id);
        }
        public Cart AddCart(Cart cart)
        {
            var entry = _context.Carts.Add(cart);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Cart UpdateCart(Cart cart)
        {
            var entry = _context.Carts.Update(cart);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool DeleteCart(int id)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == id);
            if (cart == null)
                return false;
            var entry = _context.Carts.Remove(cart);
            _context.SaveChanges();
            return true;
        }
    }
}
