using SexyJuiceBar_CustomerApp.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SexyJuiceBar_CustomerApp.Models
{
    public class Customer : Observable
    {
        private string firstName;
        private string lastName;
        private string email;
        private string teleNo;
        private bool isAlcoholUser;

        public int CustomerId { get; set; }

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string TeleNo
        {
            get => teleNo;
            set
            {
                teleNo = value;
                OnPropertyChanged();
            }
        }

        public bool IsAlcoholUser
        {
            get => isAlcoholUser;
            set
            {
                isAlcoholUser = value;
                OnPropertyChanged();
            }
        }


    }
}
