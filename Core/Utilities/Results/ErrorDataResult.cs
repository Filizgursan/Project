using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //data-message
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        //data
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        //message
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        //hiçbirşey
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
