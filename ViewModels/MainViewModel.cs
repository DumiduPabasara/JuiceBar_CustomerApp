using SexyJuiceBar_CustomerApp.Base;
using SexyJuiceBar_CustomerApp.DataProvider;
using SexyJuiceBar_CustomerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SexyJuiceBar_CustomerApp.ViewModels
{
    public class MainViewModel: Observable
    {

        private ICustomerDataProvider _customerDataProvider;

        private Customer _selectedCustomer;

        public MainViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            Customers = new ObservableCollection<Customer>();
        }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { 

                if(_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsCustomerSelected));
                }
               
            }
        }

        public bool IsCustomerSelected => SelectedCustomer != null;                

        public ObservableCollection<Customer> Customers { get; }

        public async Task LoadAsync()
        {

            Customers.Clear();

            var customers = await _customerDataProvider.LoadCustomersAsync();

            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }

            //return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _customerDataProvider.SaveCustomersAsync(Customers);
        }
    }
}
