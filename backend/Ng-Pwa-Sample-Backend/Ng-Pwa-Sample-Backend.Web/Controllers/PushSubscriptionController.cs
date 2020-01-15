using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Lib.Net.Http.WebPush;
using Microsoft.AspNetCore.Mvc;
using Ng_Pwa_Sample_Backend.Web.Services;

namespace Ng_Pwa_Sample_Backend.Web.Controllers
{
    [ApiController]
    [Route("api/PushSubscriptions")]
    public class PushSubscriptionController : ControllerBase
    {
        private readonly IPushSubscriptionService _pushSubscriptionsService;

        public PushSubscriptionController(IPushSubscriptionService pushSubscriptionsService)
        {
            _pushSubscriptionsService = pushSubscriptionsService;
        }

        [HttpPost]
        public void Post([FromBody] PushSubscription subscription)
        {
            _pushSubscriptionsService.Insert(subscription);
        }

        [HttpDelete("{endpoint}")]
        public void Delete(string endpoint)
        {
            _pushSubscriptionsService.Delete(WebUtility.UrlDecode(endpoint));
        }
    }
}
