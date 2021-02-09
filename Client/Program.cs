using System;
using Grpc.Net.Client;
using SystemStatusService;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("AUTHTOKEN"));
            using var Channel = GrpcChannel.ForAddress("https://localhost:5001");
            var greeterClient = new Greeter.GreeterClient(Channel);
            var res = greeterClient.info(new info_request
            {
                Token = "123456"
            });

            Console.WriteLine(res.Message);
            Console.ReadKey();
        }
    }
}
