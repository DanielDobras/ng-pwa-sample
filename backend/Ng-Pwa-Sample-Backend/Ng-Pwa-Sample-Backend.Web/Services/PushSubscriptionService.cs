using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lib.Net.Http.WebPush;
using LiteDB;

namespace Ng_Pwa_Sample_Backend.Web.Services
{
    public interface IPushSubscriptionService
    {
        void Insert(PushSubscription subscription);
        void Delete(string endpoint);
        void Dispose();
        IEnumerable<PushSubscription> GetAll();
    }

    public class PushSubscriptionService : IPushSubscriptionService, IDisposable
    {
        private class LitePushSubscription : PushSubscription
        {
            public int Id { get; set; }

            public LitePushSubscription()
            { }

            public LitePushSubscription(PushSubscription subscription)
            {
                Endpoint = subscription.Endpoint;
                Keys = subscription.Keys;
            }
        }

        private readonly LiteDatabase _db;
        private readonly LiteCollection<LitePushSubscription> _collection;

        public PushSubscriptionService()
        {
            _db = new LiteDatabase("PushSubscriptionsStore.db");
            _collection = _db.GetCollection<LitePushSubscription>("subscriptions");
        }

        public IEnumerable<PushSubscription> GetAll()
        {
            return _collection.FindAll();
        }

        public void Insert(PushSubscription subscription)
        {
            _collection.Insert(new LitePushSubscription(subscription));
        }

        public void Delete(string endpoint)
        {
            _collection.Delete(subscription => subscription.Endpoint == endpoint);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
