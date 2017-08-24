using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Firebase
{
  public  class FirebaseException:Exception
    {
        public FirebaseException(string requestUrl,string requestData,
            string responseData,HttpStatusCode statusCode):base(GenerateExceptionMessage(requestUrl,requestData,responseData))
        {
            this.RequestUrl = RequestUrl;
            this.RequestData = responseData;
            this.ResponseData = responseData;
            this.StatusCode = statusCode;
        }
        public FirebaseException(string requestUrl,string requestData,string responseData,HttpStatusCode statusCode,Exception innerException)
            :base(GenerateExceptionMessage(requestUrl,requestData,responseData),innerException)
        {
            this.RequestUrl = RequestUrl;
            this.RequestData = responseData;
            this.ResponseData = responseData;
            this.StatusCode = statusCode;
        }
        public string RequestData
        {
            get;
        }
        public string RequestUrl
        {
            get;
        }
        public string ResponseData
        {
            get;
        }
        public HttpStatusCode StatusCode
        {
            get;
        }

        private static string GenerateExceptionMessage(string requestUrl,
            string requestData,string responseData)
        {
            return $"Exception occured while processing the request.\n Url: {requestUrl}\nRequest Data:{ requestData}\n Response: {responseData}";
        }
    }
}
