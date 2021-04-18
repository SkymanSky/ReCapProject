using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi"; 
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarModelNameInvalid = "Araba model ismi geçersiz";
        public static string CarListed = "Arabalar Listelendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorNameInvalid = "Renk ismi geçersiz";
        public static string ColorListed = "Renk bilgisine göre listelendi.";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string BrandListed = "Marka bilgisine göre listelendi.";

        public static string CompanyNameInvalid="Şirket ismi geçersiz.";
        public static string CustomerAdded="Müşteri Eklendi.";
        public static object CustomerDeleted="Müşteri Silindi.";
        public static string CustomerUpdated="Müşteri Güncellendi";
        public static string CustomerListed="Müşteriler Listelendi";
        public static string InvalidUserName="Geçersiz kullanıcı adı.";

        public static string UserAdded="Kullanıcı eklendi.";
        public static string UserDeleted="Kullanıcı silindi.";
        public static string UserUpdated="Kullanıcı güncellendi.";
        public static string UserListed="Kuallnıcı Listelendi.";

        public static string NotRentableCar="Bu araç hali hazırda kiralanmış.";
        public static string CarRented="Araç kiralandı.";
        public static string RentalDeleted="Araç kiralık listesinden silindi.";
        public static string RentalUpdated="Araç kiralama bilgileri güncellendi.";
        public static string RentalListed="Kiralanabilir araçlar listelendi.";
        public static string RentalListedByBrand="Kiralanabilir araçlar markaya göre listelendi.";
        public static string RentalListedByColor="Kiralanabilir araçlar renge göre listelendi.";

        public static string CarImageCountOfCarError="Bir araç için en fazla beş resim eklenebilir.";

        public static string AuthorizationDenied = "Yetkiniz Yok.";
    }
}
