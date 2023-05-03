
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _335ass2.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace _335ass2.Data
{
    public class DBWebAPIRepo : IWebAPIRepo
    {
        private readonly WebAPIDBContext _dbContext;
        public DBWebAPIRepo(WebAPIDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order Purchase(string userName, int productId, int quantity)
        {
            Order orders = new Order();
            orders.UserName = userName;
            orders.ProductID = productId;
            orders.Quantity = quantity;
            _dbContext.Orders.Add(orders);
            _dbContext.SaveChanges();
            return orders;
            
        }

        public bool Registed(string Name)
        {
            if(_dbContext.Users.Any(u =>u.UserName == Name)){
                return true;
            }
            return false;
        }

        public User Register(string Name, string Password, string Address)
        {
            User users = new User();
            users.UserName = Name;
            users.Password = Password;
            users.Address = Address;
            _dbContext.Users.Add(users);
            _dbContext.SaveChanges();
            
            
            return users;
        }

        public bool ValidLogin(string userName, string password)
        {
            User u = _dbContext.Users.FirstOrDefault(e => e.UserName == userName && e.Password == password);
            if (u == null)
                return false;
            else
                return true;
        }
    }
}
