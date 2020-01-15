using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lib.Net.Http.WebPush;
using Lib.Net.Http.WebPush.Authentication;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Ng_Pwa_Sample_Backend.Web.Models;

namespace Ng_Pwa_Sample_Backend.Web.Services
{
    public class NotificationService : BackgroundService
    {
        private readonly IPushSubscriptionService _pushSubscriptionsService;
        private readonly PushServiceClient _pushClient;

        public NotificationService(IOptions<PushNotificationOptions> options, IPushSubscriptionService pushSubscriptionsService, PushServiceClient pushClient)
        {
            _pushSubscriptionsService = pushSubscriptionsService;
            _pushClient = pushClient;
            _pushClient.DefaultAuthentication = new VapidAuthentication(options.Value.PublicKey, options.Value.PrivateKey)
            {
                Subject = "https://ng-pwa-sample.azurewebsites.net/"
            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // This method allows to re-engage with the user every minute.
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(6000, stoppingToken);
                SendNotification("New birds available!", stoppingToken);
            }
        }

        private void SendNotification(string message, CancellationToken stoppingToken)
        {
            PushMessage notification = new AngularPushNotification
            {
                Title = "The Bird Game",
                Body = message,
                Icon = "assets/icons/icon-96x96.png"
            }.ToPushMessage();

            foreach (PushSubscription subscription in _pushSubscriptionsService.GetAll())
            {
                // Fire-and-forget 
                _pushClient.RequestPushMessageDeliveryAsync(subscription, notification, stoppingToken);
            }
        }
    }
}
