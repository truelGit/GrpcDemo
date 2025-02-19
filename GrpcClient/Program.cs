using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;

namespace GrpcClient
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var channel = GrpcChannel.ForAddress("https://localhost:7071");
			var customerClient = new Customer.CustomerClient(channel);

			var customer = await customerClient.GetCustomerInfoAsync(new CustomerLookupModel { UserId = 1 });

			Console.WriteLine($"{customer.FirstName} {customer.LastName}");

			Console.WriteLine();
			Console.WriteLine("New Customers List");
			Console.WriteLine();

			using (var call = customerClient.GetNewCustomers(new NewCustomerRequest()))
			{
				while (await call.ResponseStream.MoveNext())
				{
					var currentCustomer = call.ResponseStream.Current;
					Console.WriteLine($"{currentCustomer.FirstName} {currentCustomer.LastName} : {currentCustomer.EmailAdress}");
				}
			}

			Console.ReadLine();
		}
	}
}
