using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //generic. Hangi tiple çalışacağını özel olarak söylemem gerekiyor.
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
