using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // IResult ile soyuttu,
    // Result ise somut bir sınıftır.
    public class Result : IResult
    {
      
        public Result(bool success, string message):this(success)
        {
            Message = message;

            //DRY---- Succes işini altta da yapabilir.
            //Success = success;
        }
        //overloading
        public Result(bool success)
        {           
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }

        //getter read-only'dir.Read-only ise const'da set edilebilir. Bu nedenle Set edebildik.
    }
}
