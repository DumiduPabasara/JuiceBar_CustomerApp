using Newtonsoft.Json;
using SexyJuiceBar_CustomerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace SexyJuiceBar_CustomerApp.DataProvider
{
    public class CustomerDataProvider : ICustomerDataProvider
    {
        private static readonly string _customersFileName = "customers.json";
        private static readonly StorageFolder _localFolder = ApplicationData.Current.LocalFolder;

        public async Task<IEnumerable<Customer>> LoadCustomersAsync()
        {
            var storageFile = await _localFolder.TryGetItemAsync(_customersFileName) as StorageFile;
            List<Customer> customerList = null;

            if (storageFile == null)
            {
                customerList = new List<Customer>
                {
                    new Customer {CustomerId=1, FirstName="Thalla", LastName="Amarakoon", Email="thallamare@gmail.com", TeleNo="0771234567", IsAlcoholUser=true},
                    new Customer {CustomerId=2, FirstName="Goyya", LastName="Bandara", Email="goybanda@gmail.com", TeleNo="0777654321", IsAlcoholUser=false},
                    new Customer {CustomerId=3, FirstName="Makara", LastName="Suti", Email="makarasuti@gmail.com", TeleNo="0777894561", IsAlcoholUser=false }
                };

            }
            else
            {
                using (var stream = await storageFile.OpenAsync(FileAccessMode.Read))
                {
                    using (var dataReader = new DataReader(stream))
                    {
                        await dataReader.LoadAsync((uint)stream.Size);
                        var json = dataReader.ReadString((uint)stream.Size);
                        customerList = JsonConvert.DeserializeObject<List<Customer>>(json);
                    }
                }
            }

            return customerList;
        }


        public async Task SaveCustomersAsync(IEnumerable<Customer> customers)
        {
            var storageFile = await _localFolder.CreateFileAsync(_customersFileName, CreationCollisionOption.OpenIfExists);

            using (var stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (var dataWriter = new DataWriter(stream))
                {
                    var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
                    dataWriter.WriteString(json);
                    await dataWriter.StoreAsync();
                }
            }
        }
    }
}
