  
using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //çıplak class kalmamalı. Birden fazla tablonun joini olabilir bu nedenle IEntity değil.
    //IDto, Core gibi evrensel bir interfacetir.
    public class ProductDetailDto:IDto 
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
