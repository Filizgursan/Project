using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // voidleri bu IResult yapısı ile süslüyor olacağız.
    // Temel voidler için başlangıç
    // uygulamamızı kullanacak kişiler için yönlerdirme diye düşünebiliriz.
    public interface IResult
    {
        // yapmaya cALISTIGIM VOİD ADD METDOUNDAKİ ADD METODU ÇALIŞIYORSA TRUE, DEĞİLSE FALSE DÖNDÜRÜR;
        bool Success { get; }

        // EKLEME İŞLEMİ SONUCU BİLGİLENDİRME;
        string Message { get; }

    }
}
