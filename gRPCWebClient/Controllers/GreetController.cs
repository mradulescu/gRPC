using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace gRPCWebClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetController : ControllerBase
    {

        [HttpGet]
        public async Task<string> Greet()
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client = new Greeter.GreeterClient(channel);
            
            //call to gRPCWebServer through gRPC
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Mihaela" });

            return reply.Message;
        }
    }
}
