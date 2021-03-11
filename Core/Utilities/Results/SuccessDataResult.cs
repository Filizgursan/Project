using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        //data-message
        public SuccessDataResult(T data,string message):base(data,true,message)
        {

        }
        //data
        public SuccessDataResult(T data):base(data,true)
        {
                
        }
        //message
        public SuccessDataResult(string message):base(default,true,message)
        {

        }
        //hiçbirşey
        public SuccessDataResult():base(default,true)
        {

        }
    }
}
