using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    //framework katmanımız. Tüm projelerde kullanabileceğimiz kodları içeren yapıdır.
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
