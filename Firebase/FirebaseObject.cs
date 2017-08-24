using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase
{
  public  class FirebaseObject<T>
    {
        internal FirebaseObject(string key,T obj)
        {
            this.Key = key;
            this.Object = obj;
        }
        public String Key { get; set; }
        public T Object { get; set; }
    }
}
