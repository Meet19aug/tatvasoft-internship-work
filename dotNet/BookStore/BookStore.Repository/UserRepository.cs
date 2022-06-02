using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Models;

namespace BookStore.Repository
{
    public class UserRepository : BaseRepository
    {


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

        public User GetUser(int id)
        {
            
            if (id > 0)
            {
                return _context.Users.Where(c => c.Id == id).FirstOrDefault();

            }
            return null;
        }

        public bool UpdateUser(User model)
        {
            if(model.Id > 0)
            {
                _context.Update(model);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteUser(User model)
        {
            if (model.Id > 0)
            {
                _context.Remove(model);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
