using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Models;

namespace BookStore.Repository
{
    public class UserRepository
    {
        BookStoreContext _context = new BookStoreContext();

        public List<User> GetUsers(int pageIndex, int pageSize , string keyword )
        {
            var users = _context.Users.AsQueryable();
            if(pageIndex >0)
            {
                if(string.IsNullOrEmpty(keyword) == false)
                {
                    users = users.Where(x => x.Firstname.ToLower().Contains(keyword) || x.Lastname.ToLower().Contains(keyword));
                }
                var userList = users.Skip((pageIndex-1)* pageSize).Take(pageSize).ToList();

                return userList;
            }
            return null;
        }

        public User Login(LoginModel model)
        {
           return _context.Users.FirstOrDefault(c => c.Email.Equals(model.Email.ToLower()) && c.Password.Equals(model.Password));
        }

        public User Register(RegisterModel model)
        {
            User user = new User()
            {
                Email = model.Email,
                Password = model.Password,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Roleid = model.Roleid,
            };
            var entry = _context.Users.Add(user);
            _context.SaveChanges();
            return entry.Entity;
        }


    }
}
