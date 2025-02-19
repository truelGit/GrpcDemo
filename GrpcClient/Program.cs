using Grpc.Net.Client;
using GrpcServer;

namespace GrpcClient
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var input = new HelloRequest { Name = "Alex" };

			var channel = GrpcChannel.ForAddress("https://localhost:7071");
			var client = new Greeter.GreeterClient(channel);

			var reply = await client.SayHelloAsync(input);

			Console.WriteLine(reply.Message);

			Console.ReadLine();
		}
	}
}
