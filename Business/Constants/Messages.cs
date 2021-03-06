﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        internal static readonly string UserRegistered;
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string MaintenanceTime = "Sistem Bakımda.";
        public static string ProductsListed = "Ürünler listelendi.";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir...";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün bulunmaktadır.";
        public static string CategoryLimitedExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor!";
        public static string AuthorizationDenied = "Yetkiniz Yok!";
    }
}
