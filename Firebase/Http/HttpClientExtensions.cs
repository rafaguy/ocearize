using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace Firebase.Http
{
    internal static class HttpClientExtensions
    {
        public static async Task<IReadOnlyCollection<FirebaseObject<T>>> GetObjectCollection<T>(this HttpClient client, string requestUri)
        {
            var responseData = string.Empty;
            var statusCode = HttpStatusCode.OK;
            try
            {
                var response = await client.GetAsync(requestUri).ConfigureAwait(false);
                statusCode = response.StatusCode;
                responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, T>>(responseData);
                if (dictionary == null)
                    return new FirebaseObject<T>[0];

                return dictionary.Select(t => new FirebaseObject<T>(t.Key, t.Value)).ToList();
            }
            catch (Exception exception)
            {
                throw new FirebaseException(requestUri, string.Empty, responseData, statusCode);
            }
        }
        public static  IEnumerable<FirebaseObject<Object>> GetObjectCollection(this string data,Type elementType)
        {
            var dictionaryType = typeof(Dictionary<,>).MakeGenericType(typeof(string), elementType);
            IDictionary dictionary = null;

            if(data.StartsWith("["))
            {
                var listType = typeof(List<>).MakeGenericType(elementType);
                var list = JsonConvert.DeserializeObject(data, listType) as IList;
                dictionary = Activator.CreateInstance(dictionaryType) as IDictionary;
                int index = 0;
                foreach (var item in list) dictionary.Add(index++.ToString(), item);

            }
            else
            {
                dictionary = JsonConvert.DeserializeObject(data, dictionaryType) as IDictionary;
            }
            if (dictionary == null)
                yield break;
            foreach(DictionaryEntry entry in dictionary)
            {
                yield return new FirebaseObject<object>((string)entry.Key, entry.Value);
            } 
        }
    }
    
}
