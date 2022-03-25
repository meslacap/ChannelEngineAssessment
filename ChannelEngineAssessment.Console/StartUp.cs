using ChannelEngineAssessment.Services.Interfaces;
using ChannelEngineAssessment.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using ConsoleTables;
using ChannelEngineAssessment.Services.Models;

public class StartUp
{
    public static void Main(string[] args)
    {
        var services = ConfigureServices();

        var serviceProvider = services.BuildServiceProvider();

        serviceProvider.GetService<ChannelEngine>().FetchAllOrders();
    }

    private static IServiceCollection ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<IOrderService, OrdersService>();

        services.AddSingleton<ChannelEngine>();

        return services;
    }

    public class ChannelEngine
    {
        private readonly IOrderService _orderService;

        public ChannelEngine(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void FetchAllOrders()
        {
            var orders = _orderService.FetchAllOrdersAsync().Result;

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

            result = result.Take(5).ToList();

            Console.Clear();
            var table = new ConsoleTable("Product Name", "GTIN", "Quantity");
            foreach (var order in result)
            {
                table.AddRow(order.ChannelName, order.Lines.Select(l => l.GTIN).First(), order.Lines.Select(l => l.Quantity).First());
            }
            table.Write();
            Console.Read();
        }
    }
}