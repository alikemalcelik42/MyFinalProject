using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants.Messages
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcud";
        public static string AccessTokenCreated = "Bağlantı jetonu oluşturuldu";

        public static string ProductAdded = "Ürün eklendi";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductFinded = "Ürün bulundu";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintantenceTime = "Sistem bakımda";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlredyExists = "Ürün ismi zaten var";

        public static string CategoryAdded = "Kategori eklendi";
        public static string CategoriesListed = "Kategoriler listelendi";
        public static string CategoryFinded = "Kategori bulundu";
        public static string CategoryUpdated = "Kategori güncellendi";
        public static string CategoryDeleted = "Kategori silindi";
    }
}
