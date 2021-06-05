using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SexyJuiceBar_CustomerApp.Models
{
    public static class CustomerConvertor
    {
        public static Customer CreateCustomerFromString(string inputString)
        {
            var values = inputString.Split(',');
            return new Customer
            {
                FirstName = values[0],
                LastName = values[1],
                Email = values[2],
                TeleNo = values[3],
                IsAlcoholUser = bool.Parse(values[4])
            };
        }
    }
}
