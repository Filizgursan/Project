// Entity adında bir class olabilir bunun nerden geldiğini bvuradan anlayabiliriz. Abstracttan geliyor.
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    // Concretteki sınıflar bir veritabanına denk gelmektedir. Bu nedenle ilişkilendirmelidir. İşaretleme tekniği kullanmalıyız.
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
