using System;
using System.Collections.Generic;
using System.Text;
using Grpc.Net.Client;
using SystemStatusService;
using Newtonsoft.Json;
namespace Client
{
    class sdk
    {
        private string Token { get; set; }
        private string Address { get; set; }
        private GrpcChannel Channel;
        private Greeter.GreeterClient Client;
        public sdk(string Address, string Token)
        {
            this.Address = Address;
            this.Token = Token;
            this.Channel = GrpcChannel.ForAddress(Address);
            this.Client = new Greeter.GreeterClient(this.Channel);
        }

        public Dictionary<string,string> Info()
        {
            var response = this.Client.info(new info_request
            {
                Token = this.Token
            });
            return JsonConvert.DeserializeObject<Dictionary<string,string>>(response.Message);
        }

        public List<Dictionary<int, string>> Process()
        {
            var response = this.Client.process(new process_request
            {
                Token = this.Token
            });
            return JsonConvert.DeserializeObject<List<Dictionary<int, string>>>(response.Message);
        }

        public Dictionary<string,string> Command(string cmd)
        {
            var response = this.Client.command(new command_request
            {
                Token = this.Token,
                Cmd = cmd
            });
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Message);
        }
    }
}
