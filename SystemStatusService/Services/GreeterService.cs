using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Core;
using Newtonsoft.Json;

namespace SystemStatusService
{
    public class GreeterService : Greeter.GreeterBase
    {

        private readonly ILogger<GreeterService> _logger;
        private SystemInformation SysInfo;
        private readonly string Token;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
            Token = Environment.GetEnvironmentVariable("AUTHTOKEN");
            SysInfo = new SystemInformation();
        }

        public override Task<response> info(info_request request, ServerCallContext context)
        {
            if (request.Token == Token)
            {
                return Task.FromResult(new response
                {
                    Status = true,
                    Message = JsonConvert.SerializeObject(SysInfo.Info())
                });
            }
            else
            {
                return Task.FromResult(new response
                {
                    Status=false,
                    Message = "authentication error"
                });
            }
        }
    }
}
