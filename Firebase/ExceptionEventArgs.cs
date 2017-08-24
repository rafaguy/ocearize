using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase
{
   public class ExceptionEventArgs<T>:EventArgs where T:Exception
    {
        public readonly T Exception;

        public ExceptionEventArgs(T exception)
        {
            this.Exception = exception;
        }

    }
    public class ExceptionEventArgs : ExceptionEventArgs<Exception>
    {
        public ExceptionEventArgs(Exception exception) : base(exception)
        {

        }
    }
}
