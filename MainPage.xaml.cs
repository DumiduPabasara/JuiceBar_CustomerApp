using SexyJuiceBar_CustomerApp.DataProvider;
using SexyJuiceBar_CustomerApp.Models;
using SexyJuiceBar_CustomerApp.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
//Learning 4

namespace SexyJuiceBar_CustomerApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private CustomerDataProvider _customerDataProvider;

        public MainPage()
        {
            //customerDetailsUserControl.SetBinding(Grid.RowProperty);
            //customerDetailsUserControl.Customer = null;
            //customerDetailsUserControl.SetValue(CustomerDetailsUserControl.CustomerProperty, null);
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            App.Current.Suspending += App_Suspending;
            _customerDataProvider = new CustomerDataProvider();
            RequestedTheme = App.Current.RequestedTheme == ApplicationTheme.Dark ? ElementTheme.Dark : ElementTheme.Light;
            //this.Resources.Add()
        }


        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            customerListView.Items.Clear();

            var customers =  await _customerDataProvider.LoadCustomersAsync();

            foreach (var customer in customers)
            {
                customerListView.Items.Add(customer);
            }
        }

        private async void App_Suspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral(); //to make sure data saved before app closed
            await _customerDataProvider.SaveCustomersAsync(customerListView.Items.OfType<Customer>());
            deferral.Complete(); //to make sure data saved before app closed
        }


        private void BtnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer { FirstName = "New" };
            customerListView.Items.Add(customer);
            customerListView.SelectedItem = customer;
            //var msgDialog = new MessageDialog("Customer Added!");
            //await msgDialog.ShowAsync();
        }

        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = customerListView.SelectedItem as Customer;
            if(customer != null)
            {
                customerListView.Items.Remove(customer);
            }
        }

        private void BtnMove_Click(object sender, RoutedEventArgs e)
        {
            //int column = (int)customerListGrid.GetValue(Grid.ColumnProperty);
            int column = Grid.GetColumn(customerListGrid);

            int newwColumn = column == 0 ? 2 : 0;

            //customerListGrid.SetValue(Grid.ColumnProperty, newwColumn);
            Grid.SetColumn(customerListGrid, newwColumn);

            moveSymbolIcon.Symbol = newwColumn == 0 ? Symbol.Forward : Symbol.Back;
        }

        //private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var customer = customerListView.SelectedItem as Customer;
        //    customerDetailsUserControl.Customer = customer;
        //    //txtFirstName.Text = customer?.FirstName ?? "";
        //    //txtLastName.Text = customer?.LastName ?? "";
        //    //txtEmail.Text = customer?.Email ?? "";
        //    //txtPhone.Text = customer?.TeleNo ?? "";
        //    //chkAlcohol.IsChecked = customer?.IsAlcoholUser;
        //}

        private void ButtonToggleTheme_Click(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = RequestedTheme == ElementTheme.Dark ? ElementTheme.Light : ElementTheme.Dark;
        }

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    UpdateCustomer();
        //}

        //private void CheckBox_IsCheckedChanged(object sender, RoutedEventArgs e)
        //{
        //    UpdateCustomer();
        //}

        //private void UpdateCustomer()
        //{
        //    var customer = customerListView.SelectedItem as Customer;
        //    if(customer != null)
        //    {
        //        customer.FirstName = txtFirstName.Text;
        //        customer.LastName = txtLastName.Text;
        //        customer.Email = txtEmail.Text;
        //        customer.TeleNo = txtPhone.Text;
        //        customer.IsAlcoholUser = chkAlcohol.IsChecked.GetValueOrDefault();
        //    }
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
