
using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //çıplak class kalmamalı. Birden fazla tablonun joini olabilir bu nedenle IEntity değil.
    //IDto, Core gibi evrensel bir interfacetir.
    public class ProductDetailDto:IDto 
    {
    }
}
