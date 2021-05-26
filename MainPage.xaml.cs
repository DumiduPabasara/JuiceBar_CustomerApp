using SexyJuiceBar_CustomerApp.DataProvider;
using SexyJuiceBar_CustomerApp.Models;
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
//Learning

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
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            App.Current.Suspending += App_Suspending;
            _customerDataProvider = new CustomerDataProvider();
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


        private async void BtnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var msgDialog = new MessageDialog("Customer Added!");
            await msgDialog.ShowAsync();
        }

        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {

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

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
