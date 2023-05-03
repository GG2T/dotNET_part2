using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _335ass2.Models;

namespace _335ass2.Data
{
    public interface IWebAPIRepo
    {
        User Register(string UserName,string Password,string Address);
        Boolean Registed(string UserName);

        public bool ValidLogin(string UserName, string Password);
        Order Purchase(string UserName, int ProductId, int Quantity);


    }
}
