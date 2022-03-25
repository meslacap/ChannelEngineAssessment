using ChannelEngineAssessment.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> FetchAllOrdersAsync();

        Task<bool> IsProductStockUpdated(List<Product> products);

        Task<List<Product>> GetProduct(Lines line);
    }
}
