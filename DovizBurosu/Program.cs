using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DovizBurosu.Classes;
using DovizBurosu.Models;



namespace DovizBurosu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
            //var xmlDoc = new XmlDocument();
            //xmlDoc.Load(today);
            //string dolarAlis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            //Console.WriteLine("Alış Fiyatı : " + dolarAlis);


            //string dolarSatis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            //Console.WriteLine("Satış Fiyatı : "+ dolarSatis);
            
            //Console.WriteLine("***********************");

            //string euroSatis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            //Console.WriteLine("Euro Satış : "+ euroSatis);

            //string euroAlis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            //Console.WriteLine("Euro Alış : " +euroAlis);

            DovizProjeEntities db = new DovizProjeEntities();
            Sale sale = new Sale();

            void CurrencyList()
            {
                var values = db.Tbl_Currency.ToList();
                foreach (var item in values)
                {
                    Console.WriteLine();
                    Console.WriteLine("Döviz Listesi : ");
                    Console.WriteLine();
                    Console.WriteLine(item.ID + " " + " " + item.CurrencyName);
                }
            }

            void CurrentCurrency()
            {
                Console.WriteLine();
                Console.WriteLine("Güncel Kur Bilgisi");
                Console.WriteLine();
                var values = db.Tbl_CurrencyValue.ToList();
                foreach (var item in values)
                {
                    Console.WriteLine();
                    Console.WriteLine("Güncel Kur Listesi : ");
                    Console.WriteLine();
                    Console.WriteLine( "Döviz " + item.Tbl_Currency.CurrencyName + "Alış " + item.CurrencyBuying + "Satış " + item.CurrencySelling);
                }
            }


            void GetCurrencyClass()
            {
                GetCurrency getCurrency = new GetCurrency();
                getCurrency.SaveCurrencyDollar();
                getCurrency.SaveCurrencyEuro();
                getCurrency.SaveCurrencyPound();
                Console.WriteLine("Kur bilgileri veritabanına aktarıldı");
            }

          


            Console.WriteLine("Döviz işlemlerine Hoş Geldiniz");
            Console.WriteLine(" ");
            Console.WriteLine(" Mevcut kullanıcı adı :  Admin" + "    " + "Tarih : " + DateTime.Now.ToShortDateString());
            Console.WriteLine(" ");
            Console.WriteLine("Yapmak istediğiniz işlemi seçiniz");
            Console.WriteLine(" ");
            Console.WriteLine("1-Döviz Listesi");
            Console.WriteLine("2-Güncel Kurlar");
            Console.WriteLine("3-Satış Yap");
            Console.WriteLine("4-Müşterilere Yapılan Satış Hareketleri");
            Console.WriteLine("5-Müşterilerden Yapılan Satış Hareketleri");
            Console.WriteLine("6-Kurları Veri Tabanına Kaydet");
            Console.WriteLine("7-Yardım");
            Console.WriteLine("8-Çıkış Yap");
            Console.WriteLine("");
            Console.Write("İşlem Numarası :  ");

            string choose;
            choose = Console.ReadLine();
            if (choose == "1" || choose == "01" )
            {
                CurrencyList();
            }
            if (choose == "2" || choose == "02")
            {
                CurrentCurrency();

            }
            if (choose == "3" || choose == "03")
            {
                Console.WriteLine();
                
                Console.Write("Müşteri Adı:");
                string customerName = Console.ReadLine();
                
                Console.Write("Müşteri Soyadı:");
                string customerSurname = Console.ReadLine();
                
                Console.Write("Döviz Kodu:");
                int currenyCode = int.Parse(Console.ReadLine());

                Console.Write("İşlem Türü:");
                string operationType = Console.ReadLine();

                Console.Write("Güncel Kur Değeri:");
                decimal currentValue = decimal.Parse(Console.ReadLine());

                Console.Write("Alıncak Tutar:");
                decimal amount = decimal.Parse(Console.ReadLine());

                Console.Write("Toplam Ücret:");
                decimal totalPrice = decimal.Parse(Console.ReadLine());






                sale.MakeSale(customerName, customerSurname, currenyCode, operationType, currentValue, amount, totalPrice
                    );
            }
            if (choose == "4" || choose == "04")
            {
                SaleOperation saleOperation = new SaleOperation();
                saleOperation.CustomerSaleOperationAlis();

            }
            if (choose == "5" || choose == "05")
            {
                SaleOperation saleOperation = new SaleOperation();
                saleOperation.CustomerSaleOperationSatis();

            }
            if (choose == "6" || choose == "06")
            {
                GetCurrencyClass();

            }
            if (choose == "7" || choose == "07")
            {
                Console.WriteLine("Yardım almak için lütfen mail@mail.com adresine yazınız.");
            }
            if (choose == "8" || choose == "08")
            {
                Environment.Exit(1);

            }
            Console.ReadLine();

        }
    }
}
