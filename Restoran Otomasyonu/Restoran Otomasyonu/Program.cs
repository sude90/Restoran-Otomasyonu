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
        public ArrayList masaNo = new ArrayList {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
        //Menüdeki Ürünlerin Sırası İle Olan Fiyat Listesi
        public int[] menuFiyat = {52, 52, 60, 50, 70, 60, 70, 50, 45, 40, 40, 40, 55, 60, 80, 30, 40, 50, 50, 10, 10, 10, 10, 10, 10, 10};
        //Menünün Dizi Şeklinde Olan Biçimi
        public string[] menu = {"\n1- Humus", "\n2- Mücver", "\n3- Patates Tabağı", "\n4- Peynir Tabağı", "\n5- Çıtır Tavuk Parçaları", "\n6- Körili Tavuk", "\n7- Izgara Tavuk ", "\n8- Bonfile", "\n9- Köfte", "\n10- Roka Salatası", "\n11- Akdeniz Salatası", "\n12- Tavuklu Salata", "\n13- Tavuk Dürüm", "\n14- Et Dürüm", "\n15- Tost", "\n16- Sandviç", "\n17- Hamburger", "\n18- Browni", "\n19- Cheescake", "\n20- Su", "\n21- Ayran", "\n22- Kola", "\n23- Çay", "\n24- Maden Suyu", "\n25- Türk Kahvesi" };

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
        //Garson, Kurye Ve Mutfak Alanları İçin Başvuru Şartları Aynı Olduğu İçin Böyle Bir Fonksiyon Oluşturuldu
        public void AyniKayitİslemi()
        {
            Console.Write("İsim Ve Soyisim Giriniz: ");
            adSoyad = Console.ReadLine();
        tel_no_donus:
            Console.Write("Telefon Numarası Giriniz(Sıfır İle): ");
            telefonNo = Console.ReadLine();
            if (telefonNo.Length != 11) //Numara Uzunluğu On Bir Olmalı Koşulu
            {
                Console.Clear();
                Console.WriteLine("Telefon Numarasını Eksik Veya Hatalı Girdiniz Lütfen Tekrar Deneyiniz!");
                goto tel_no_donus;
            }
        }

        public void IsciKayit()
        {
            giris:
            Console.Clear();
            Console.WriteLine("Hangi Alan İçin Başvuru Yapmak İstiyorsunuz?");
            Console.WriteLine("1- Garsonluk");
            Console.WriteLine("2- Kuryelik");
            Console.WriteLine("3- Mutfak");
            string secim = Console.ReadLine();
            int secim1;
            if (!int.TryParse(secim, out secim1))
            {
                Console.Clear();
                Console.WriteLine("Hatalı Tuşlama Yapıldı Lütfen Tekrar Giriniz.");
                Thread.Sleep(1500); Console.Clear();
                goto giris;
            }
        basvuruEkran:
            switch (secim1)
            {
                case 1:
                    AyniKayitİslemi();
                onayİsim:
                    Console.Write("Başvurunuzu Onaylamak İçin Adınızı Ve Soyadınızı Tekrar Giriniz: ");
                    string isim = Console.ReadLine();

                    if (isim == adSoyad)
                    {
                        Console.WriteLine("Başvurunuz Alınmıştır, İyi Günler Dileriz!"); Console.Clear();
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
                        Console.WriteLine("Başvurunuz Alınmıştır, İyi Günler Dileriz!"); Console.Clear();
                        //Başvuru Yapan Kişinin Başvuru Bilgileri En Baştaki Kurye Listesine Eklenir
                        kurye.Add("Ad-Soyad: " + isim1 + "\nTelefon Numarası: " + telefonNo + "\nBaşvuru Alanı: Kuryelik");
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
                        Console.WriteLine("Başvurunuz Alınmıştır, İyi Günler Dileriz!"); Console.Clear();
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
            string isciSecim = Console.ReadLine();
            int isciSecim1;
            if (!int.TryParse(isciSecim, out isciSecim1))
            {
                Console.Clear();
                Console.WriteLine("Hatalı Tuşlama Yapıldı Lütfen Tekrar Giriniz.");
                Thread.Sleep(1500); Console.Clear();
                goto IsciAlim;
            }
            switch (isciSecim1)
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

        public void KasaBakiyesi()
        {
            Console.Clear();
            Console.WriteLine("Restoranın Kasadaki Mevcut Miktarı = " + kasa + " TL' dir.");
        }
    }

    class MusteriMenu : Restoran
    {
        public void Menu()
        {
            Console.WriteLine("----------------MENÜ-----------------");
            Console.WriteLine("");
            Console.WriteLine("---APERATİFLER---");
            Console.WriteLine("1- Humus  " + menuFiyat[0] + " TL");
            Console.WriteLine("2- Mücver  " + menuFiyat[1] + " TL");
            Console.WriteLine("3- Patates Tabağı  " + menuFiyat[2] + " TL");
            Console.WriteLine("4- Peynir Tabağı  " + menuFiyat[3] + " TL");
            Console.WriteLine("5- Çıtır Tavuk Parçaları  " + menuFiyat[4] + " TL");
            Console.WriteLine("");
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
            Random masaRandom = new Random(); //Gelen Müşteriyi Rastgele Bir Masaya Yerleştirilir
            byte masa_no = Convert.ToByte(masaRandom.Next(1, 30));
            byte cagirilanMasa = Convert.ToByte(masa_no);  //Rastgele Verien Sayı Çağırılan Masa Numarası Oldu
            Console.WriteLine(cagirilanMasa + ". Masaya Yeni Müşteri Geldi. Hemen İlgilenilsin.");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Merhabalar, Hoş Geldiniz. Ne Alırdınız?");
            Thread.Sleep(1500);
            Console.Clear();
        alinanUrun:
            Menu();
            Console.Write("Lütfen Almak İstediğiniz Ürünün Numarasını Giriniz: ");
            byte masaSiparis = Convert.ToByte(Console.ReadLine());
            if(masaSiparis > 25)
            {
                Console.Clear();
                Console.WriteLine("Lütfen Doğru Bir Giriş Yapınız. İstediğiniz Ürün Numarası Bulunmamaktadır.");
                Thread.Sleep(1500); Console.Clear();
                goto alinanUrun;
            }
            byte odenecekHesap = Convert.ToByte(menuFiyat[masaSiparis]);
            Console.WriteLine("Ödenecek Tutar = " + odenecekHesap); Console.WriteLine("");

            while (true)
            {
                Console.WriteLine("Başka Bir İsteğiniz Var Mıdır? (Evet = 'E', Hayır = 'H')");
                ConsoleKeyInfo artiIstek = Console.ReadKey();

                if (artiIstek.Key == ConsoleKey.E)
                {
                    Console.Clear();
                    alinanArtiUrun:
                    Menu(); Console.WriteLine("");
                    Console.Write("Artı Olarak İstediğiniz Ürünün Numarasını Giriniz: ");
                    byte artiUrun = Convert.ToByte(Console.ReadLine());
                    if (artiUrun > 25)
                    {
                        Console.WriteLine("Lütfen Doğru Bir Giriş Yapınız. İstediğiniz Ürün Numarası Bulunmamaktadır.");
                        Thread.Sleep(1500); Console.Clear();
                        goto alinanArtiUrun;
                    }
                    odenecekHesap += Convert.ToByte(menuFiyat[artiUrun]); Console.WriteLine("");
                    Console.WriteLine("Ödenecek Tutar = " + odenecekHesap);
                    kasa += odenecekHesap;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Siparişiniz En Kısa Sürede Masanıza Ulaşacaktır.");
                    break;
                }
                   
            }
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
                hataliGiris:
                Console.WriteLine("Merhabalar, Gün Işığı Restoran. Buyurun?");
                Console.WriteLine("1- Masa Rezervasyonu Yapma");
                string rezerveSecim = Console.ReadLine();
                int rezerveSecim1;
                if (!int.TryParse(rezerveSecim, out rezerveSecim1))
                {
                    Console.Clear();
                    Console.WriteLine("Hatalı Tuşlama Yapıldı Lütfen Tekrar Giriniz.");
                    Thread.Sleep(1500); Console.Clear();
                    goto hataliGiris;
                }

                if (rezerveSecim == "1")
                {
                    Console.WriteLine("1 İla 30 Arasında Bir Masa Numarası Seçiniz.");
                    byte secilenMasa = Convert.ToByte(Console.ReadLine());
                    if (secilenMasa > 0 && secilenMasa < 31)
                    {
                        Console.WriteLine("Rezerve Tarihi Giriniz: ");
                        string rezerveTarih = Console.ReadLine();
                        Console.WriteLine(secilenMasa + " Numaralı Masa "+ rezerveTarih + " Tarihi İçin Rezerve Edilmiştir. İyi Günler Dileriz!");
                        //Rezerve Edilen Masanın Tekrar Rezerve Edilmesini Engellemek İçin En Başta Oluşturulan Masa Numaraları Dizisinden Rezerve Edilen Masa Numarası Silindi
                        masaNo.Remove(secilenMasa);
                    }
                    else
                    {
                        Console.WriteLine("Lütfen Doğru Bir Numara Giriniz!");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Hatalı Tuşlama Yapıldı Lütfen Tekrar Giriniz.");
                    Thread.Sleep(1500); Console.Clear();
                    goto hataliGiris;
                }
            }
            else if (rezerveArama.ToUpper() == "HAYIR")
            {
                Console.Clear();
                Console.WriteLine("- Çıkmak İçin 'ENTER' Tuşuna Basınız!");
            }
        }

        public void EvSiparis()
        {
           Console.Clear();
            RestoranBilgileri();
        ilkSecim:
            Console.WriteLine("Rezervasyon İçin Arama Yapmanız Gerekmektedir. İstiyorsanız 'E', İstemiyorsanız 'H' Yazınız.");
            ConsoleKeyInfo evArama = Console.ReadKey();

            if (evArama.Key == ConsoleKey.E)
            {
                Console.Clear();
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
                    Console.Write("Lütfen Almak İstediğiniz Ürünün Numarasını Giriniz: ");
                    byte urunSiparis = Convert.ToByte(Console.ReadLine());
                    byte odenecekTutar = Convert.ToByte(menuFiyat[urunSiparis]);
                    Console.WriteLine("Ödenecek Tutar = " + odenecekTutar); Console.WriteLine("");

                    while (true)
                    {
                        Console.WriteLine("Başka Bir İsteğiniz Var Mıdır? (Evet = 'E', Hayır = 'H')");
                        ConsoleKeyInfo artiİstek = Console.ReadKey();
                    
                        if (artiİstek.Key == ConsoleKey.E)
                        {
                            Console.Clear();
                            Menu(); Console.WriteLine("");
                            Console.Write("Artı Olarak İstediğiniz Ürünün Numarasını Giriniz: ");
                            byte artiUrun = Convert.ToByte(Console.ReadLine());
                            odenecekTutar += Convert.ToByte(menuFiyat[artiUrun]); Console.WriteLine("");
                            Console.WriteLine("Ödenecek Tutar = " + odenecekTutar);
                        }
                        else
                            break;
                        
                    }
                    Console.Clear();
                    Console.Write("Lütfen Bir Teslimat Adresi Söyleyiniz: ");
                    string teslimatAdresi = Console.ReadLine();
                    Console.Clear();
                    //Girilen Teslimat Adresinin Doğruluğu Teyit Edilir
                    Console.WriteLine("Teslimat Adresiniz: " + teslimatAdresi + " Onaylıyorsanız 'EVET', Onaylamıyorsanız 'HAYIR' yazınız.");
                    string teslimatAdresiOnay = Console.ReadLine();

                    if (teslimatAdresiOnay.ToUpper() == "EVET")
                    {
                        byte teslimZamani = 4;
                        Console.Clear();
                        Console.WriteLine("Bizi Tercih Ettiğiniz İçin Teşekkür Ederiz! Siparişiniz En Kısa Süre İçerisinde Teslimat Adresine Ulaşacaktır İyi Günler Dileriz!");
                        while(teslimZamani > 0) //Geri Sayım İşlemi
                        {
                            Console.Clear(); Console.WriteLine($"Siparişiniz Yola Çıktı. Tahmini Teslim Zamanı {teslimZamani} Saniye.");
                            Thread.Sleep(1000);
                            teslimZamani--;
                        }
                        Console.Clear();
                        Console.WriteLine("Kuryeden Restorana Mesaj: Adrese Varıldı.");
                        Thread.Sleep(1500);
                        Console.Clear();
                        Console.WriteLine("Gün Işığı Restoran. Siparişiniz Geldi. Ücreti " + odenecekTutar + " TL."); Console.WriteLine("");
                        Console.Write("Verilen Miktarı Giriniz: "); double ucretOdeme = Convert.ToDouble(Console.ReadLine());

                        if(ucretOdeme > odenecekTutar)
                        {
                            byte paraUstu = Convert.ToByte(ucretOdeme - odenecekTutar);
                            Console.WriteLine($"Para Üstünüz = {paraUstu} TL. İyi Günler.");
                        }

                        else if (ucretOdeme < odenecekTutar) //Eğer Toplam Hesap Müşterinin Verdiği Ücretten Fazla İse
                        {
                            byte eksikPara = Convert.ToByte(odenecekTutar - ucretOdeme);
                            Console.WriteLine($"Ödediğiniz Miktar Ücretten = {eksikPara} TL Eksik. Siparişi İptal Mi Edeceksiniz Yoksa Eksik Miktarı Mı Vereceksiniz? (İptal İçin 'I', Devam Etmek İçin 'D' Giriniz.)");
                            eksikParaIslem:
                            ConsoleKeyInfo tercih = Console.ReadKey(); //Girilen Tek Karakterli İfade Bilgisi Okunur
                            if (tercih.Key == ConsoleKey.I) //Girilen İfade 'I' İse
                            {
                                Console.Clear();
                                Console.WriteLine("Siparişiniz İptal Edilmiştir. İyi Günler.");
                            }

                            else if(tercih.Key == ConsoleKey.D)
                            {
                                Console.Clear();
                                Console.Write($"Eksik Kalan Ücreti Ödeyiniz {eksikPara} TL: "); byte eksikUcretOdeme = Convert.ToByte(Console.ReadLine());
                                if(eksikUcretOdeme > eksikPara) // İkinci Kez Verilen Ücet Zaten Eksik Olan Tutardan Büyük İse
                                {
                                    byte paraUstu2 = Convert.ToByte(eksikPara - eksikUcretOdeme);
                                    Console.WriteLine($"Para Üstünüz {paraUstu2} TL, Buyurun. İyi Günler.");
                                }
                                else if (eksikUcretOdeme < eksikPara) // İkinci Kez Verilen Ücet Zaten Eksik Olan Tutardan Küçük İse
                                {
                                    Console.Clear();
                                    byte eksikUcret2 = Convert.ToByte(eksikPara - eksikUcretOdeme);
                                    Console.WriteLine($"Ödediğiniz Miktar Eksik Ücretten = {eksikUcret2} TL Eksik. Siparişi İptal Mi Edeceksiniz Yoksa Eksik Miktarı Mı Vereceksiniz? (İptal İçin 'I', Devam Etmek İçin 'D' Giriniz.)");
                                    goto eksikParaIslem;
                                }
                                else if (eksikUcretOdeme == eksikPara) //Eksik Olan Ücret Tamamlandı İse
                                {
                                    Console.WriteLine("Ödeme Gerçekleşmiştir. İyi Günler.");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    Console.WriteLine("Kuryeden Restorana Mesaj: Sipariş Teslim Edilmiştir.");
                                    kasa += odenecekTutar;
                                }
                            }
                        }

                        else if(ucretOdeme == odenecekTutar) //Ödeme İşlemi Sorunsuz Bir Şekilde Tamamlandı İse
                        {
                            Console.WriteLine("İyi Günler.");
                            Thread.Sleep(2000);
                            Console.Clear();
                            Console.WriteLine("Kuryeden Restorana Mesaj: Sipariş Teslim Edilmiştir.");
                            kasa += odenecekTutar;
                        }

                    }
                    else if (teslimatAdresiOnay.ToUpper() == "HAYIR")
                    {
                        Console.Clear();
                        adresTekrar:
                        Console.Write("Lütfen Teslimat Adresini Tekrar Söyleyiniz: ");
                        string adresTekrar = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Teslimat Adresiniz: " + adresTekrar + " Onaylıyorsanız 'E', Onaylamıyorsanız 'H' yazınız.");
                        ConsoleKeyInfo teslimatAdresiOnay2 = Console.ReadKey();
                        if(teslimatAdresiOnay2.Key == ConsoleKey.E)
                        {
                            byte teslimZamani = 4;
                            Console.Clear();
                            Console.WriteLine("Bizi Tercih Ettiğiniz İçin Teşekkür Ederiz! Siparişiniz En Kısa Süre İçerisinde Teslimat Adresine Ulaşacaktır İyi Günler Dileriz!");
                            while (teslimZamani > 0) //Geri Sayım Olarak Siparişin Teslim Süresi Söylenir
                            {
                                Console.Clear(); Console.WriteLine($"Siparişiniz Yola Çıktı. Tahmini Teslim Zamanı {teslimZamani} Saniye.");
                                Thread.Sleep(1000);
                                teslimZamani--;
                            }
                            Console.Clear();
                            Console.WriteLine("Kuryeden Restorana Mesaj: Adrese Varıldı.");
                            Thread.Sleep(1500);
                            Console.Clear();
                            Console.WriteLine("Gün Işığı Restoran. Siparişiniz Geldi. Ücreti " + odenecekTutar + " TL."); Console.WriteLine("");
                            Console.Write("Verilen Miktarı Giriniz: "); double ucretOdeme = Convert.ToDouble(Console.ReadLine());
                            if (ucretOdeme > odenecekTutar)
                            {
                                byte paraUstu = Convert.ToByte(ucretOdeme - odenecekTutar);
                                Console.WriteLine($"Para Üstünüz = {paraUstu} TL. İyi Günler.");
                            }
                            else if (ucretOdeme < odenecekTutar)
                            {
                                byte eksikPara = Convert.ToByte(odenecekTutar - ucretOdeme);
                                Console.WriteLine($"Ödediğiniz Miktar Ücretten = {eksikPara} TL Eksik. Siparişi İptal Mi Edeceksiniz Yoksa Eksik Miktarı Mı Vereceksiniz? (İptal İçin 'I', Devam Etmek İçin 'D' Giriniz.)");
                            eksikParaIslem:
                                ConsoleKeyInfo tercih = Console.ReadKey();
                                if (tercih.Key == ConsoleKey.I)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Siparişiniz İptal Edilmiştir. İyi Günler.");
                                }
                                else if (tercih.Key == ConsoleKey.D)
                                {
                                    Console.Clear();
                                    Console.Write($"Eksik Kalan Ücreti Ödeyiniz {eksikPara} TL: "); byte eksikUcretOdeme = Convert.ToByte(Console.ReadLine());
                                    if (eksikUcretOdeme > eksikPara)
                                    {
                                        byte paraUstu2 = Convert.ToByte(eksikPara - eksikUcretOdeme);
                                        Console.WriteLine($"Para Üstünüz {paraUstu2} TL, Buyurun. İyi Günler.");
                                    }
                                    else if (eksikUcretOdeme < eksikPara)
                                    {
                                        Console.Clear();
                                        byte eksikUcret2 = Convert.ToByte(eksikPara - eksikUcretOdeme);
                                        Console.WriteLine($"Ödediğiniz Miktar Eksik Ücretten = {eksikUcret2} TL Eksik. Siparişi İptal Mi Edeceksiniz Yoksa Eksik Miktarı Mı Vereceksiniz? (İptal İçin 'I', Devam Etmek İçin 'D' Giriniz.)");
                                        goto eksikParaIslem;
                                    }
                                    else if (eksikUcretOdeme == eksikPara)
                                    {
                                        Console.WriteLine("Ödeme Gerçekleşmiştir. İyi Günler.");
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        Console.WriteLine("Kuryeden Restorana Mesaj: Sipariş Teslim Edilmiştir.");
                                        kasa += odenecekTutar;
                                    }
                                }
                            }
                            else if (ucretOdeme == odenecekTutar)
                            {
                                Console.WriteLine("İyi Günler.");
                                Thread.Sleep(2000);
                                Console.Clear();
                                Console.WriteLine("Kuryeden Restorana Mesaj: Sipariş Teslim Edilmiştir.");
                                kasa += odenecekTutar;
                            }
                        }
                        else if (teslimatAdresiOnay2.Key == ConsoleKey.H)
                        {
                            Console.Clear();
                            goto adresTekrar;
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Bir Hata Oluştu Lütfen Adres Onay Cevabını Tekrar Girmeniz Gerekmektedir.");
                            goto adresTekrar;
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Lütfen Doğru Bir Seçim Yapınız!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    goto istek;
                }
            }
            else if (evArama.Key == ConsoleKey.H)
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
                string secim = Console.ReadLine();
                int ilkGiris;
                if (!int.TryParse(secim, out ilkGiris))
                {
                    Console.Clear();
                    Console.WriteLine("Hatalı Tuşlama Yapıldı Lütfen Tekrar Giriniz.");
                    Thread.Sleep(1500); Console.Clear();
                    goto anaMenu;
                }

                switch (ilkGiris)
                {
                    case 1:
                        Console.Clear();
                        YetkiliMenu y = new YetkiliMenu(); //Yetkili Menünün Fonksiyonlarının Kullanılabilmesi İçin Nesne Oluşturulur
                        Console.WriteLine("1- Personel Alımı (Tam Olarak Çalışmıyor)");
                        Console.WriteLine("2- Personel Listesi (Tamamlanmadı)");
                        Console.WriteLine("3- Restoran Kasa Bakiyesi Sorgulama");
                        Console.WriteLine("4- Ana Menüye Dönüş");
                        Console.WriteLine("5- Çıkış");
                        byte yetkiliSecim = Convert.ToByte(Console.ReadLine());
                        if (yetkiliSecim == 1)
                        {
                            Console.Clear();
                            y.IsciAlimi();
                        }
                        else if(yetkiliSecim == 3)
                        {
                            Console.Clear();
                            y.KasaBakiyesi();
                            Console.WriteLine("Devam Etmek İçin Herhnagi Bir Tuşa Basınız."); Console.ReadKey();
                            Console.Clear();
                            goto anaMenu;

                        }
                        else if (yetkiliSecim == 4)
                        {
                            Console.Clear();
                            goto anaMenu;
                        }
                        else if (yetkiliSecim == 5)
                        {
                            Console.Clear();
                            Console.WriteLine("Çıkmak İçin 'ENTER' Tuşuna Basın.");
                        }
                        break;

                    case 2:
                        Console.Clear();
                        MusteriMenu m = new MusteriMenu();  //Müşteri Menüsünün Fonksiyonlarının Kullanılabilmesi İçin Nesne Oluşturulur
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
                            Console.WriteLine("- Çıkmak İçin 'ENTER' Tuşuna Basın.");
                        }
                        break;

                    case 3:
                        Console.Clear() ;
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
                        Thread.Sleep(1000);
                        Console.Clear();
                        goto anaMenu;
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
