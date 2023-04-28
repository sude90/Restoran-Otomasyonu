using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restoran_Otomasyonu
{

    class Restoran
    {
        public string adSoyad;
        public string telefonNo;
        public int kasa;

        public ArrayList garson = new ArrayList(); //Garson Olarak İş Başvurusu Yapanlar
        public ArrayList kurye = new ArrayList();  //Kurye Olarak İş Başvurusu Yapanlar
        public ArrayList mutfak = new ArrayList(); //Mutfak İçin İş Başvurusu Yapanlar
        //Rezervasyon İçin Masa Numaraları
        public ArrayList masaNo = new ArrayList { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30};
        //Menüdeki Ürünlerin Sırası İle Olan Fiyat Listesi
        public int[] menuFiyat = {52, 52, 60, 50, 70, 60, 70, 50, 45, 40, 40, 40, 55, 60, 80, 30, 40, 50, 50, 10, 10, 10, 10, 10, 10 };

        public void RestoranBilgileri() 
        {
            Console.WriteLine("------------------------GÜN IŞIĞI RESTORAN------------------------");
            Console.WriteLine("|---------İLETİŞİM BİLGİLERİ---------|");
            Console.WriteLine("| TELEFON:0212 212 1212              |");
            Console.WriteLine("| MAİL:gunisigirestoran@gunisigi.com |");
        }
    }

    class Personel_Basvuru : Restoran
    {
        //Garson, Kurye Ve Mutfak Alanları İçin Başvuru Şartları Aynı Olduğu İçin Böyle Bir Fonksiyon Oluşturduk
        public void AyniKayitİslemi()
        {
            Console.Write("İsim Ve Soyisim Giriniz: ");
            adSoyad = Console.ReadLine();
        tel_no_donus:
            Console.Write("Telefon Numarası Giriniz(Sıfır İle): ");
            telefonNo = Console.ReadLine();
            if (telefonNo.Length != 11) //Numara Uzunluğu On Bir Olmalı Koşulu
            {
                Console.WriteLine("Telefon Numarasını Eksik Veya Hatalı Girdiniz Lütfen Tekrar Deneyiniz!");
                goto tel_no_donus;
            }
        }

        public void IsciKayit()
        {
            Console.Clear();
            Console.WriteLine("Hangi Alan İçin Başvuru Yapmak İstiyorsunuz?");
            Console.WriteLine("1- Garsonluk");
            Console.WriteLine("2- Kuryelik");
            Console.WriteLine("3- Mutfak");
            byte secim = Convert.ToByte(Console.ReadLine());
        basvuruEkran:
            switch (secim)
            {
                case 1:
                    AyniKayitİslemi();
                onayİsim:
                    Console.Write("Başvurunuzu Onaylamak İçin Adınızı Ve Soyadınızı Tekrar Giriniz: ");
                    string isim = Console.ReadLine();

                    if (isim == adSoyad)
                    {
                        Console.WriteLine("Başvurunuz Alınmıştır, İyi Günler Dileriz!");
                        //Başvuru Yapan Kişinin Başvuru Bilgileri En Baştaki Garson Listesine Eklenir
                        garson.Add("Ad-Soyad: " + isim + "\nTelefon Numarası: " + telefonNo + "\nBaşvuru Alanı: Garsonluk");
                    }
                    else
                    {
                        Console.WriteLine("Ad Ve Soyad Doğru Bir Şekilde Girilmedi Lütfen Tekrar Deneyin!");
                        Console.Clear();
                        goto onayİsim;
                    }
                    break;

                case 2:
                    AyniKayitİslemi();
                    Console.Write("Başvurunuzu Onaylamak İçin Adınızı Ve Soyadınızı Tekrar Giriniz: ");
                    string isim1 = Console.ReadLine();

                    if (isim1 == adSoyad)
                    {
                        Console.WriteLine("Başvurunuz Alınmıştır, İyi Günler Dileriz!");
                        //Başvuru Yapan Kişinin Başvuru Bilgileri En Baştaki Kurye Listesine Eklenir
                        kurye.Add("Ad-Soyad: "+ isim1 + "\nTelefon Numarası: " + telefonNo + "\nBaşvuru Alanı: Kuryelik");
                    }
                    else
                    {
                        Console.WriteLine("Ad Ve Soyad Doğru Bir Şekilde Girilmedi Lütfen Tekrar Deneyin!");
                        Console.Clear();
                        goto onayİsim;
                    }
                    break;

                case 3:
                    AyniKayitİslemi();
                    Console.Write("Başvurunuzu Onaylamak İçin Adınızı Ve Soyadınızı Tekrar Giriniz: ");
                    string isim2 = Console.ReadLine();

                    if (isim2 == adSoyad)
                    {
                        Console.WriteLine("Başvurunuz Alınmıştır, İyi Günler Dileriz!");
                        //Başvuru Yapan Kişinin Başvuru Bilgileri En Baştaki Mutfak Listesine Eklenir
                        mutfak.Add("Ad-Soyad: " + isim2 + "\nTelefon Numarası: " + telefonNo + "\nBaşvuru Alanı: Mutfak");
                    }
                    else
                    {
                        Console.WriteLine("Ad Ve Soyad Doğru Bir Şekilde Girilmedi Lütfen Tekrar Deneyin!");
                        Console.Clear();
                        goto onayİsim;
                    }
                    break;

                default:
                    Console.WriteLine("Hatalı Giriş Yaptınız Lütfen Tekrar Deneyiniz!");
                    goto basvuruEkran;
                break;
            }
        }
    }

    class YetkiliMenu : Restoran
    {
        public void IsciAlimi()
        {
            Console.Clear();
            IsciAlim:
            Console.WriteLine("Hangi Alanda Personel Almak İstiyorsunuz?");
            Console.WriteLine("1- Garsonluk");
            Console.WriteLine("2- Kuryelik");
            Console.WriteLine("3- Mutfak");
            byte isciSecim = Convert.ToByte(Console.ReadLine());
            switch (isciSecim)
            {
                case 1: //Garson Olarak Başvuru Yapan Kişilerin Bilgilerini Yetkili Bireye Sunar
                    foreach (var eleman in garson)
                    {
                        Console.WriteLine(eleman);
                    }
                    Console.WriteLine(garson.Count);
                break;
                    
                case 2: //Kurye Olarak Başvuru Yapan Kişilerin Bilgilerini Yetkili Bireye Sunar
                    foreach (var eleman in kurye)
                    {
                        Console.WriteLine(eleman);
                    }
                break;

                case 3: //Mutfak İçin Başvuru Yapan Kişilerin Bilgilerini Yetkili Bireye Sunar
                    foreach (var eleman in mutfak)
                    {
                        Console.WriteLine(eleman);
                    }
                break;

                default:
                    Console.WriteLine("Hatalı Giriş Yaptınız Lütfen Tekrar Deneyiniz!");
                    goto IsciAlim;
                break;
            }
        }
    }

    class MusteriMenu : Restoran
    {
        public void Menu()
        {
            Console.WriteLine("----------------MENÜ-----------------");
            Console.WriteLine("---APERATİFLER---");
            Console.WriteLine("");
            Console.WriteLine("1- Humus  " + menuFiyat[0] + " TL");
            Console.WriteLine("2- Mücver  " + menuFiyat[1] + " TL");
            Console.WriteLine("3- Patates Tabağı  " + menuFiyat[2] + " TL");
            Console.WriteLine("4- Peynir Tabağı  " + menuFiyat[3] + " TL");
            Console.WriteLine("5- Çıtır Tavuk Parçaları  " + menuFiyat[4] + " TL");
            Console.WriteLine("");
            Console.WriteLine("---ANA YEMEKLER---");
            Console.WriteLine("6- Körili Tavuk  " + menuFiyat[5] + " TL");
            Console.WriteLine("7- Izgara Tavuk  " + menuFiyat[6] + " TL");
            Console.WriteLine("8- Bonfile  " + menuFiyat[7] + " TL");
            Console.WriteLine("9- Köfte  " + menuFiyat[8] + " TL");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("---SALATALAR---");
            Console.WriteLine("10- Roka Salatası  " + menuFiyat[9] + " TL");
            Console.WriteLine("11- Akdeniz Salatası  " + menuFiyat[10] + " TL");
            Console.WriteLine("12- Tavuklu Salata  " + menuFiyat[11] + " TL");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("---SOKAK LEZZETLERİ---");
            Console.WriteLine("");
            Console.WriteLine("13- Tavuk Dürüm  " + menuFiyat[12] + " TL");
            Console.WriteLine("14- Et Dürüm  " + menuFiyat[13] + " TL");
            Console.WriteLine("15- Tost  " + menuFiyat[14] + " TL");
            Console.WriteLine("16- Sandviç  " + menuFiyat[15] + " TL");
            Console.WriteLine("17- Hamburger  " + menuFiyat[16] + " TL");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("---TATLILAR---");
            Console.WriteLine("18- Browni  " + menuFiyat[17] + " TL");
            Console.WriteLine("19- Cheescake  " + menuFiyat[18] + " TL");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("---İÇECEKLER---");
            Console.WriteLine("");
            Console.WriteLine("20- Su  " + menuFiyat[19] + " TL");
            Console.WriteLine("21- Ayran  " + menuFiyat[20] + " TL");
            Console.WriteLine("22- Kola  " + menuFiyat[21] + " TL");
            Console.WriteLine("23- Çay  " + menuFiyat[22] + " TL");
            Console.WriteLine("24- Maden Suyu  " + menuFiyat[23] + " TL");
            Console.WriteLine("25- Türk Kahvesi  " + menuFiyat[24] + " TL");
        }
        public void MasaSiparis()
        {
            Console.Clear();
            Random masaRandom = new Random(); //Gelen Müşteriyi Rastgele Bir Masaya Yerleştirir
            // ---Rastgele verilen masa numarasının tekrar gelmesi engellenmeye çalışıldı---\\
           /* ArrayList masa_No = new ArrayList();
            for (int i=0; i > 31; i++)
            {
                do
                {
                  byte masa_no = (byte)masaRandom.Next(1,31);
                }while (masa_No.Contains(masa_no));
                bytecagirilanMasa = masa_no;
            }*/
            byte masa_no = Convert.ToByte(masaRandom.Next(1, 30));
            byte cagirilanMasa = Convert.ToByte(masa_no);  //Rastgele Verien Sayı Çağırılan Masa Numarası Oldu
            Console.WriteLine(cagirilanMasa + ". Masaya Yeni Müşteri Geldi. Hemen İlgilenilsin.");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Merhabalar, Hoş Geldiniz. Ne Alırdınız?");
            Thread.Sleep(2000);
            Console.Clear();
            Menu();
            Console.WriteLine("Lütfen Almak İstediğiniz Ürünün (Ürünlerin) Numarasını Araya Artı (+) Koyarak Giriniz: ");
            string yemekSecim = Console.ReadLine();
            Thread.Sleep(2000);
            Console.WriteLine("Siparişiniz En Kısa Sürede Masanıza Ulaşacaktır.");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine(cagirilanMasa + " Numaralı Masanın Siparişi Götürülmüştür.");
        }

        public void Rezervasyon()
        {
            Console.Clear();
            RestoranBilgileri();
            Console.WriteLine("Rezervasyon İçin Arama Yapmanız Gerekmektedir. İstiyorsanız 'EVET', İstemiyorsanız 'HAYIR' Yazınız.");
            string rezerveArama = Console.ReadLine();

            if (rezerveArama.ToUpper() == "EVET") //ToUpper() => Girilen tüm karakterleri büyük harfe çevirir
            {
                Console.WriteLine("Arama Yapılıyor...");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Merhabalar, Gün Işığı Restoran. Buyurun?");
                Console.WriteLine("1- Masa Rezervasyonu Yapma");
                byte rezerveSecim = Convert.ToByte(Console.ReadLine());
                if (rezerveSecim == 1)
                {
                    Console.WriteLine("1 İla 30 Arasında Bir Masa Numarası Seçiniz.");
                    byte secilenMasa = Convert.ToByte(Console.ReadLine());
                    if (secilenMasa > 0 && secilenMasa < 31)
                    {
                        Console.WriteLine(secilenMasa + " Numaralı Masa Rezerve Edilmiştir. İyi Günler Dileriz!");
                        //Rezerve Edilen Masanın Tekrar Rezerve Edilmemesi İstendiği En Başta Oluşturulan Masa Numaraları Dizisinden Rezerve Edilen Masa Numarası Silindi
                        masaNo.Remove(secilenMasa);                   }
                    else
                    {
                        Console.WriteLine("Lütfen Doğru Bir Numara Giriniz!");
                    }
                }
            }
            else if (rezerveArama.ToUpper() == "HAYIR")
            {
                Console.Clear();
                Console.WriteLine("Çıkmak İçin 'ENTER' Tuşuna Basınız!");
            }
        }

        public void EvSiparis()
        {
            Console.Clear();
            RestoranBilgileri();
        ilkSecim:
            Console.WriteLine("Rezervasyon İçin Arama Yapmanız Gerekmektedir. İstiyorsanız 'EVET', İstemiyorsanız 'HAYIR' Yazınız.");
            string evArama = Console.ReadLine();

            if (evArama.ToUpper() == "EVET")
            {
                Console.WriteLine("Arama Yapılıyor...");
                Thread.Sleep(1000);
                Console.Clear();
            istek:
                Console.WriteLine("Merhabalar, Gün Işığı Restoran. Buyurun?");
                Console.WriteLine("1- Eve Sipariş Verme");
                byte evSiparisSecim = Convert.ToByte(Console.ReadLine());
                if (evSiparisSecim == 1)
                {
                    Console.Clear();
                    Menu();
                    Console.WriteLine("Lütfen Almak İstediğiniz Ürünün (Ürünlerin) Numarasını Araya Artı (+) Koyarak Giriniz: ");
                    string siparisUrun = Console.ReadLine();
                    Console.WriteLine("Siparişiniz Alınmıştır.");
                    Console.Clear();
                    Console.WriteLine("Lütfen Bir Teslimat Adresi Söyleyiniz.");
                    string teslimatAdresi = Console.ReadLine();
                    Console.Clear();
                adresOnay:
                    //Girilen Teslimat Adresinin Doğrulu Teyit Edilir
                    Console.WriteLine("Teslimat Adresiniz: " + teslimatAdresi + " Onaylıyorsanız 'EVET', Onaylamıyorsanız 'HAYIR' yazınız.");
                    string teslimatAdresiOnay = Console.ReadLine();

                    if (teslimatAdresiOnay.ToUpper() == "EVET")
                    {
                        Console.Clear();
                        Console.WriteLine("Bizi Tercih Ettiğiniz İçin Teşekkür Ederiz! Siparişiniz En Kısa Süre İçerisinde Teslimat Adresine Ulaşacaktır İyi Günler Dileriz!");
                    }
                    else if (teslimatAdresiOnay.ToUpper() == "HAYIR")
                    {
                        Console.Clear();
                        Console.WriteLine("Lütfen Teslimat Adresini Tekrar Söyleyiniz.");
                        string adresTekrar = Console.ReadLine();
                        Console.Clear();
                        teslimatAdresiOnay = adresTekrar;
                        Console.WriteLine("Teslimat Adresiniz: " + adresTekrar + " Onaylıyorsanız 'EVET', Onaylamıyorsanız 'HAYIR' yazınız.");
                        teslimatAdresiOnay = Console.ReadLine();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Lütfen Doğru Bir Seçim Yapınız!");
                    goto istek;
                }
            }
            else if (evArama.ToUpper() == "HAYIR")
            {
                Console.Clear();
                Console.WriteLine("Çıkış Yapmak İçin 'ENTER' Tuşuna Basınız!");
            }
            else
            {
                Console.WriteLine("Lütfen Doğru Bir Giriş Yapınız!");
                goto ilkSecim;
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
            anaMenu:
                Console.WriteLine("Merhabalar Efendim Bizi Tercih Ettiğiniz İçin Teşekkür Eder Ve İyi Günler Dileriz!");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("| Nereye Girmek İstediğinizi Giriniz  |");
                Console.WriteLine("| 1- Yetkili Menü                     |");
                Console.WriteLine("| 2- Müşteri Menü                     |");
                Console.WriteLine("| 3- İş Başvurusu                     |");
                Console.WriteLine("| 4- Çıkış                            |");
                Console.WriteLine("---------------------------------------");
                byte ilkGiris = Convert.ToByte(Console.ReadLine());
                switch (ilkGiris)
                {
                    case 1:
                        Console.Clear();
                        YetkiliMenu y = new YetkiliMenu(); //Yetkili Menünün Fonksiyonlarının Kullanılabilmesi İçin Nesne Oluşturulur
                        Console.WriteLine("1- Personel Alımı");
                        Console.WriteLine("2- Personel Listesi");
                        Console.WriteLine("3- Ana Menüye Dönüş");
                        Console.WriteLine("4- Çıkış");
                        byte yetkiliSecim = Convert.ToByte(Console.ReadLine());
                        if (yetkiliSecim == 1)
                        {
                            Console.Clear();
                            y.IsciAlimi();
                        }
                        else if (yetkiliSecim == 3)
                        {
                            Console.Clear();
                            goto anaMenu;
                        }
                        else if (yetkiliSecim == 4)
                        {
                            Console.Clear();
                            Console.WriteLine("Çıkmak İçin 'ENTER' Tuşuna Basın.");
                        }
                        break;

                    case 2:
                        MusteriMenu m = new MusteriMenu();  //Müşteri Menünün Fonksiyonlarının Kullanılabilmesi İçin Nesne Oluşturulur
                        Console.WriteLine("1- Masaya Sipariş Verme");
                        Console.WriteLine("2- Rezervasyon Yapma");
                        Console.WriteLine("3- Eve Sipariş Verme");
                        Console.WriteLine("4- Ana Menüye Dönüş");
                        Console.WriteLine("5- Çıkış");
                        byte musteriSecim = Convert.ToByte(Console.ReadLine());
                        if (musteriSecim == 1)
                        {
                            Console.Clear();
                            m.MasaSiparis();
                        }
                        else if (musteriSecim == 2)
                        {
                            Console.Clear();
                            m.Rezervasyon();
                        }
                        else if (musteriSecim == 3)
                        {
                            Console.Clear();
                            m.EvSiparis();
                        }
                        else if (musteriSecim == 4)
                        {
                            Console.Clear();
                            goto anaMenu;
                        }
                        else if (musteriSecim == 5)
                        {
                            Console.Clear();
                            Console.WriteLine("Çıkmak İçin 'ENTER' Tuşuna Basın.");
                        }
                        break;

                    case 3:
                        Personel_Basvuru pb = new Personel_Basvuru();  //Personel Başvurularının Alınabilmesi İçin Nesne Oluşturulur
                        Console.Clear();
                        pb.IsciKayit();
                        goto anaMenu;
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Çıkmak İçin 'ENTER' Tuşuna Basın.");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Hatalı Giriş Yaptınız! Lütfen Tekrar Deneyiniz.");
                        break;                }
                Console.ReadKey();
            }
        }
    }
}