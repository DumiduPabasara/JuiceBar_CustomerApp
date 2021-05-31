using SexyJuiceBar_CustomerApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SexyJuiceBar_CustomerApp.UserControls
{
    public sealed partial class CustomerDetailsUserControl : UserControl
    {

        private Customer _customer;

        public CustomerDetailsUserControl()
        {
            this.InitializeComponent();
        }


        public Customer Customer
        {
            get { return _customer; }
            set {
                _customer = value;
                txtFirstName.Text = _customer?.FirstName ?? "";
                txtLastName.Text = _customer?.LastName ?? "";
                txtEmail.Text = _customer?.Email ?? "";
                txtPhone.Text = _customer?.TeleNo ?? "";
                chkAlcohol.IsChecked = _customer?.IsAlcoholUser;
            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCustomer();
        }

        private void CheckBox_IsCheckedChanged(object sender, RoutedEventArgs e)
        {
            UpdateCustomer();
        }

        private void UpdateCustomer()
        {
            //var customer = customerListView.SelectedItem as Customer;
            if (Customer != null)
            {
                Customer.FirstName = txtFirstName.Text;
                Customer.LastName = txtLastName.Text;
                Customer.Email = txtEmail.Text;
                Customer.TeleNo = txtPhone.Text;
                Customer.IsAlcoholUser = chkAlcohol.IsChecked.GetValueOrDefault();
            }
        }
    }
}
