using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //const. implemente etmek için const oluşturuyoruz.
    // Result datalar içindi. DataResult aynı zamanda datası oldugu için

    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success, string message):base(success,message)
        {
            Data = data;
        }
        public DataResult(T data, bool success):base(success)
        {
            Data = data;

        }
        public T Data { get; }
    }
}
