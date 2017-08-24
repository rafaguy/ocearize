using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase.Streaming
{
    public class FirebaseEvent<T> : FirebaseObject<T>
    {
        public FirebaseEvent(string key, T obj,FirebaseEventType eventType, FirebaseEventSource source) : base(key, obj)
        {

        }
        public FirebaseEventType EventType { get; }
        public FirebaseEventSource EventSource { get; }

        public static FirebaseEvent<T> Empty(FirebaseEventSource source) => new FirebaseEvent<T>(string.Empty, default(T), FirebaseEventType.InsertOrUpdate, source);

    }
}
