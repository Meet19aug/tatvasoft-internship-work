using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Models;
using System.Security.Cryptography;
using System.IO;

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
           return _context.Users.FirstOrDefault(c => c.Email.Equals(model.Email.ToLower()) && c.Password.Equals(Encrypt(model.Password)));
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public User Register  (RegisterModel model)
        {
            User user = new User()
            {
                Email = model.Email,
                Password = Encrypt(model.Password.ToString()),
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Roleid = model.Roleid,
            };
            Console.WriteLine("User is : " ,user);
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
