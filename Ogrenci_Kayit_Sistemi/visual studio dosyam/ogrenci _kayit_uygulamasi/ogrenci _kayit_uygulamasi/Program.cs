using System.ComponentModel.Design;
using System.Security.Claims;

namespace ogrenci__kayit_uygulamasi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liste ogrenciler = new Liste();
            int numara;
            String ad, soyad, ders;
            float vize, final;

        int secim = menu();
            while (secim != 0)
            {
                switch(secim)
                {
                    case 1:
                        Console.Write("numara  : "); numara = int.Parse(Console.ReadLine());
                        Console.Write("isim    : "); ad= Console.ReadLine();
                        Console.Write("Soy isim: "); soyad = Console.ReadLine();
                        Console.Write("Ders adi: "); ders = Console.ReadLine();
                        Console.Write("Vize    : "); vize = float.Parse(Console.ReadLine());
                        Console.Write("Final   : "); final = float.Parse(Console.ReadLine());
                        ogrenciler.ekle(numara, ad, soyad, ders, vize, final);   

                        break;
                    case 2:
                        Console.Write("Numara: "); numara = int.Parse(Console.ReadLine());
                        ogrenciler.sil(numara);
                        break;
                    case 3:
                        Console.Clear();
                        ogrenciler.yazdir();
                        break;
                    case 4:
                        Console.Clear();
                        ogrenciler.EnBasarili();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("...Hatalı bir secim yaptiniz...");
                        break;
                }
                Console.WriteLine();
                secim = menu();
            }


        }
        private static int menu()
        {
            int secim;
            Console.WriteLine("1- ogrenci ekle");
            Console.WriteLine("2- ogrenci sil");
            Console.WriteLine("3- ogrencileri yazdir");
            Console.WriteLine("4- En başarılı ogrenciyi goster");
            Console.WriteLine("0- programı kapat");
            Console.Write("Seciminiz: ");
            secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }
    class Ogrenci
    {
        public int numara;
        public String ad, soyad, ders;
        public float vize, final, ortalama;
        public string durum;

        public Ogrenci next;

        public Ogrenci(int numara, string ad, string soyad, string ders, float vize, float final)
        {
            this.numara = numara;
            this.ad = ad;   
            this.soyad = soyad;
            this.ders = ders;
            this.vize = vize;
            this.final = final;
            this.ortalama = this.vize * 40 / 100 + this.final * 60 / 100;
            this.durum = this.ortalama < 50 ? "Kaldı" : "Geçti";
        }
    }
    class Liste
    {
        Ogrenci head;
        public Liste()
        {
            head = null;
        }
        public void ekle(int numara, string ad, string soyad, string ders, float vize, float final)
        {
            Ogrenci ogr = new Ogrenci(numara, ad, soyad, ders, vize, final);
            if (head == null)
            {
                head = ogr;
                Console.WriteLine(numara+" numaralı öğrenci listeye eklendi");
            }
            else
            {
                ogr.next = head;
                head = ogr;
                Console.WriteLine(numara + " numaralı ögrenci eklendi");
            }
        }
        public void sil(int numara)
        {
            bool sonuc = false;
            if (head == null)
            {
                sonuc = true;
                Console.WriteLine("Listede kayitli ogrenci yok");
            }
            else if (head.next == null && head.numara == numara)
            {
                sonuc = true;
                head = null;
                Console.WriteLine($"Listeden, {numara} numaralı ogrenci silindi");
            }
            else if (head.next != null && head.numara == numara)
            {
                sonuc = true;

                head = head.next;
                Console.WriteLine($"Listeden, {numara} numaralı ogrenci silindi");
            }
            else
            {
                Ogrenci temp = head;
                Ogrenci temp2 = temp;

                while (temp.next != null)
                {
                    if (numara == temp.numara)
                    {
                        sonuc = true;

                        temp2.next = temp.next;
                        Console.WriteLine($"Listeden, {numara} numaralı ogrenci silindi");
                    }
                    temp2 = temp;
                    temp = temp.next;
                }
                if (numara == temp.numara)
                {
                    sonuc = true;

                    temp2.next = null;
                    Console.WriteLine($"Listeden, {numara} numaralı ogrenci silindi");
                }

            }
            if (sonuc == false)
            {
                Console.WriteLine(numara + " numaralı ogrenci kaydi yok");
            }
        }
        public void yazdir()
        {
            if ( head == null )
            {
                Console.WriteLine("Liste boş oldugu icin yazdirilmiyor");
            }
            else
            {
                Ogrenci temp = head;

                Console.WriteLine("Numara\tAd\tSoyad\tDersAdi\tOrtalama\tDurumu\n");
                while (temp.next != null)
                {
                    Console.WriteLine(temp.numara + "\t" + temp.ad + "\t" + temp.soyad + "\t" + temp.ders + "\t" + temp.ortalama + "\t" + temp.durum);
                    temp = temp.next;
                }
                Console.WriteLine(temp.numara + "\t" + temp.ad + "\t" + temp.soyad + "\t" + temp.ders + "\t" + temp.ortalama + "\t" + temp.durum);
            }
        }
        public void EnBasarili()
        {
            if (head == null)
            {
                Console.WriteLine("Listede kayitli ogrenci yok");
            }
            else
            {
                Ogrenci temp = head;
                Ogrenci yuksekOgr = head;
                float enYuksekOrt = head.ortalama;

                while (temp.next != null)
                {
                    if (enYuksekOrt < temp.ortalama)
                    {
                        enYuksekOrt = temp.ortalama;
                        yuksekOgr = temp;
                    }
                    temp = temp.next;
                }

                if (enYuksekOrt < temp.ortalama)
                {
                    enYuksekOrt = temp.ortalama;
                    yuksekOgr = temp;
                }
                Console.WriteLine("En yüksek ortalamalı ogrenci: " + yuksekOgr.ad+"   numarası: "+yuksekOgr.numara + "   Ortalaması: " + yuksekOgr.ortalama);

            }
        }
    }
}
