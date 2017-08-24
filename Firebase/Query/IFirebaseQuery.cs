using Firebase.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase.Query
{
  public  interface IFirebaseQuery
    {
       // FirebaseClient Client { get;  }
        Task<IReadOnlyCollection<FirebaseObject<T>>> OnceAsync<T>();
        IObservable<FirebaseEvent<T>> AsObservable<T>(EventHandler<ExceptionEventArgs<FirebaseException>> exceptionHandler, string elementRoot = "");
        Task<string> BuildUrlAsync();
    }
}
