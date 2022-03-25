using ChannelEngineAssessment.Models;
using ChannelEngineAssessment.Services.Interfaces;
using ChannelEngineAssessment.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChannelEngineAssessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        public List<Order> orders = new();

        public HomeController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            orders = _orderService.FetchAllOrdersAsync().Result;            

            return View(DisplayTopFiveOrder(orders));
        }

        /// <summary>
        /// Update the stock to 25
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public IActionResult UpdateStockByOrderId(int orderId)
        {
            List<Order> orders = _orderService.FetchAllOrdersAsync().Result;

            List<Product> product = GetProduct(orders, orderId);

            _orderService.IsProductStockUpdated(product);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Filter result from API
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        private static List<Order> DisplayTopFiveOrder(List<Order> orders)
        {
            //Remove duplicate quantity of products ordered from an order
            foreach (Order order in orders)
            {
                if (order.Lines.Count > 1)
                {
                    int quantity = 0;
                    for (int i = 0; i < order.Lines.Count; i++)
                    {
                        if (order.Lines[i].Quantity < quantity)
                        {
                            order.Lines.Remove(order.Lines[i]);
                        }
                        else
                        {
                            quantity = order.Lines[i].Quantity;
                        }
                    }
                }
            }

            //Arrange to descending order by Quantity sold
            var result = from order in orders
                         from lines in order.Lines
                         orderby lines.Quantity descending
                         select order;

            //Return top 5 orders
            return result.Take(5).ToList();
        }

        /// <summary>
        /// Get Product by Order ID
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProduct(List<Order> orders, int orderId)
        {
            return _orderService.GetProduct(orders.FirstOrDefault(o => o.Id == orderId).Lines.Single()).Result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}