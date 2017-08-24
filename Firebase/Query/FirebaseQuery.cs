using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Streaming;
using System.Net.Http;
using Firebase.Http;

namespace Firebase.Query
{
    public abstract class FirebaseQuery : IFirebaseQuery, IDisposable
    {
        protected readonly FirebaseQuery parent;
        private HttpClient client;

        public FirebaseQuery(FirebaseQuery parent,FirebaseClient client)
        {
            this.parent = parent;
            this.Client = client;
        }
        public FirebaseClient Client { get;}

        public IObservable<FirebaseEvent<T>> AsObservable<T>(EventHandler<ExceptionEventArgs<FirebaseException>> exceptionHandler, string elementRoot = "")
        {
            throw new NotImplementedException();
        }

        public async Task<string> BuildUrlAsync()
        {
            // if token factory is present on the parent then use it to generate auth token
            /*if (this.Client.Options.AuthTokenAsyncFactory != null)
            {
                var token = await this.Client.Options.AuthTokenAsyncFactory().ConfigureAwait(false);
                return this.WithAuth(token).BuildUrl(null);
            }*/

            return this.BuildUrl(null);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<FirebaseObject<T>>> OnceAsync<T>()
        {
            var path =await this.BuildUrlAsync().ConfigureAwait(false);
            return await this.client.GetObjectCollection<T>(path).ConfigureAwait(false);
        }
        public abstract string BuildUrlSegment(FirebaseQuery child);
        public string BuildUrl(FirebaseQuery child)
        {
            var url = this.BuildUrlSegment(child);
            if(this.parent !=null)
            {
                url = this.parent.BuildUrl(this) + url;
            }
            
                return url;
            
        }
        private HttpClient GetClient()
        {
            if(client==null)
            {
                this.client = new HttpClient();
            }
            return this.client;
        }
    }
}
