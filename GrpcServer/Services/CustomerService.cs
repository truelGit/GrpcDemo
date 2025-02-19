using Grpc.Core;

namespace GrpcServer.Services
{
	public class CustomerService : Customer.CustomerBase
	{
		private ILogger<CustomerService> _logger;
		public CustomerService(ILogger<CustomerService> logger)
		{
			_logger = logger;
		}

		public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
		{
			CustomerModel output = new CustomerModel();

			if (request.UserId == 1)
			{
				output.FirstName = "Alex";
				output.LastName = "Smith";
			}
			else if (request.UserId == 2)
			{
				output.FirstName = "John";
				output.LastName = "Doe";
			}
			else
			{
				output.FirstName = "Thomas";
				output.LastName = "Clark";
			}

			return Task.FromResult(output);
		}
	}
}
