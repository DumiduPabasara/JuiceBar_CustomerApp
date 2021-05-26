using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SexyJuiceBar_CustomerApp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string TeleNo { get; set; }

        public bool IsAlcoholUser { get; set; }
    }
}
