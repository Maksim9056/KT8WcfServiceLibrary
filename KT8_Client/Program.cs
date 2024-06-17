using KT8WcfServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace KT8_Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("\nSync Client:\n");
            var binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType =
            MessageCredentialType.Windows;
            var factory = new ChannelFactory<IOrderService>(binding, new EndpointAddress("http://localhost:8733/Design_Time_Addresses/KT8WcfServiceLibrary/OrderService/mx"));
            var client = factory.CreateChannel();

            var Order1 = new Order
            {
                OrderId = 2,
                CustomerName = "Jane Doe",
                OrderDate = DateTime.Now,
                Items = new List<OrderItem>
                        {
                            new OrderItem { ItemId = 1, ProductName = "Smartphone", Quantity = 1 },
                            new OrderItem { ItemId = 2, ProductName = "Headphones", Quantity = 2 }
                        }
            };
            await client.AddOrderAsync(Order1);
            List<string> list = new List<string>();
            //var S = list.FirstOrDefault();
            //S.
              //  List<string> list = new List<string>();
              //   var S=     list.FirstOrDefault();
              //var A = S.ToList();
              //Получаем список всех заказов
              var asyncOrders = await client.GetOrdersAsync();
            foreach (var order in asyncOrders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Customer Name: {order.CustomerName}, Order Date: {order.OrderDate}");
            }

   
            Console.WriteLine("\nAsync Client:\n");
            var asyncSingleOrder = await client.GetOrderByIdAsync(2);
               Console.WriteLine($"Single Order - ID: {asyncSingleOrder.OrderId}, Customer Name: {asyncSingleOrder.CustomerName}");
            var book = new Book
            {
                Author="Иван Прохоров",
                BookId =1,
                PublishedDate = DateTime.Now,
                Title = "Рога и копыта",
            };
            await client.AddBookAsync(book);
            book.BookId = 2;
            book.Author = "Пушкин";
            book.Title = "Горе от ума";
            await client.AddBookAsync(book);


            //Получаем список всех заказов
            var asyncbook = await client.GetBooksAsync();
            foreach (var bookS in asyncbook)
            {
                Console.WriteLine($"BookId ID: {bookS.BookId}, Customer Title: {bookS.Title}, Order PublishedDate: {bookS.PublishedDate}");
            }


            Console.WriteLine("\nAsync Client:\n");
            var book1 = await client.GetBookByIdAsync(1);
            Console.WriteLine($"BookId ID: {book1.BookId}, Customer Title: {book1.Title}, Order PublishedDate: {book1.PublishedDate}");

            //Console.WriteLine("10KT");
            //var binding = new WSHttpBinding();
            //binding.Security.Mode = SecurityMode.Message;
            //binding.Security.Message.ClientCredentialType =
            //MessageCredentialType.Windows;
            //var endpoint = new EndpointAddress("http://localhost:8733/Design_Time_Addresses/KT8WcfServiceLibrary/OrderService/mx");
            //var channelFactory = new ChannelFactory<IOrderService>(binding, endpoint);

            //var proxy = channelFactory.CreateChannel();
            //await proxy.AddBookAsync(book);

            //var books = await proxy.GetBooksAsync();
            //foreach (var bookS in books)
            //{
            //    Console.WriteLine($"BookId ID: {bookS.BookId}, Customer Title: {bookS.Title}, Order PublishedDate: {bookS.PublishedDate}");
            //}
            //var book2 = await proxy.GetBookByIdAsync(1);
            //Console.WriteLine($"BookId ID: {book2.BookId}, Customer Title: {book2.Title}, Order PublishedDate: {book2.PublishedDate}");

            ////proxy.SecureMethod();
            ////client.Call Secure Method();
            //Console.WriteLine("Press <Enter> to exit." );
            Console.ReadLine();
        }
    }
}
//Console.WriteLine("\nSync Client:\n");

//var factory = new ChannelFactory<IOrderService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:8000/OrderService"));
//var client = factory.CreateChannel();

//// Добавляем новый заказ
//client.AddOrder(new Order
//{
//    OrderId = 1,
//    CustomerName = "John Doe",
//    OrderDate = DateTime.Now,
//    Items = new List<OrderItem>
//                    {
//                        new OrderItem { ItemId = 1, ProductName = "Laptop", Quantity = 1 },
//                        new OrderItem { ItemId = 2, ProductName = "Mouse", Quantity = 2 }
//                    }
//});

//// Получаем список всех заказов
//var orders = client.GetOrders();
//foreach (var order in orders)
//{
//    Console.WriteLine($"Order ID: {order.OrderId}, Customer Name: {order.CustomerName}, Order Date: {order.OrderDate}");
//}

//// Получаем заказ по ID
//var singleOrder = client.GetOrderById(1);
//Console.WriteLine($"Single Order - ID: {singleOrder.OrderId}, Customer Name: {singleOrder.CustomerName}");

//Console.WriteLine("\nAsync Client:\n");

//var asyncFactory = new ChannelFactory<IAsyncOrderService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:8000/AsyncOrderService"));
//var asyncClient = asyncFactory.CreateChannel();

//// Асинхронный вызов клиента
//Task.Run(async () =>
//{
//    // Добавляем новый заказ
//    await asyncClient.AddOrderAsync(new Order
//    {
//        OrderId = 2,
//        CustomerName = "Jane Doe",
//        OrderDate = DateTime.Now,
//        Items = new List<OrderItem>
//                        {
//                            new OrderItem { ItemId = 1, ProductName = "Smartphone", Quantity = 1 },
//                            new OrderItem { ItemId = 2, ProductName = "Headphones", Quantity = 2 }
//                        }
//    });

//    // Получаем список всех заказов
//    var asyncOrders = await asyncClient.GetOrdersAsync();
//    foreach (var order in asyncOrders)
//    {
//        Console.WriteLine($"Order ID: {order.OrderId}, Customer Name: {order.CustomerName}, Order Date: {order.OrderDate}");
//    }

//    // Получаем заказ по ID
//    var asyncSingleOrder = await asyncClient.GetOrderByIdAsync(2);
//    Console.WriteLine($"Single Order - ID: {asyncSingleOrder.OrderId}, Customer Name: {asyncSingleOrder.CustomerName}");