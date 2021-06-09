using SexyJuiceBar_CustomerApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SexyJuiceBar_CustomerApp.DataProvider
{
    public interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>> LoadCustomersAsync();
        Task SaveCustomersAsync(IEnumerable<Customer> customers);
    }
}