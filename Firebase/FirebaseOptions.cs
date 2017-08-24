using Firebase.Offline;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase
{
 public  class FirebaseOptions
    {
        public FirebaseOptions()
        {
            this.OfflineDatabaseFactory = (s, t) => new Dictionary<string, OfflineEntry>();
            this.SubscriptionStreamReaderFactory = (s) => new StreamReader(s);
            this.JsonSerializerSettings = new JsonSerializerSettings();
            this.SyncPeriod = TimeSpan.FromSeconds(10);

        }
        public Func<Type,string,IDictionary<string,OfflineEntry>> OfflineDatabaseFactory
        {
            get;set;
        }
        public Func<Task<string>> AuthTokenAsyncFactory { get; set; }

        public Func<Stream,TextReader> SubscriptionStreamReaderFactory { get; set; }

        public JsonSerializerSettings JsonSerializerSettings { get; set; }

        public TimeSpan SyncPeriod { get; set; }

        public bool AsAccessToken { get; set; }
    }
}
