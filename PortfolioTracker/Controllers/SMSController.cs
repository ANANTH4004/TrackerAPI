using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using NuGet.Protocol;
using PortfolioTracker.Data;
using Twilio.Clients;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using Twilio;

namespace PortfolioTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ITwilioRestClient client;
        private readonly IConfiguration config;
        public SMSController(ITwilioRestClient client , IConfiguration config)
        {
            this.config = config;
            this.client = client;
        }
        [HttpPost]
        public IActionResult SendSms(SmsClass model)
        {
            var accountSid = "ACb8408c94cfb36aab017e5b187b062e86";
            var authToken = "5e01b45e34513efbe3e8a9d46b31829d";
            Twilio.TwilioClient.Init(accountSid, authToken);


            var message = MessageResource.Create(
                to: new PhoneNumber(model.To),
                from: new PhoneNumber(model.From),
                body: model.Message,
                client: client
                );
            return Ok("Success" + message.Sid); 
        }
    }
}
