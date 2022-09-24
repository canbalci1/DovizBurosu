using DovizBurosu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DovizBurosu.Classes
{
    public class GetCurrency
    {

        DovizProjeEntities db = new DovizProjeEntities();



        public void SaveCurrencyDollar()
        {

            string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);

            string dolarAlis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            dolarAlis = dolarAlis.Replace(".", ",");

            string dolarSatis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            dolarSatis = dolarSatis.Replace(".", ",");

            Tbl_CurrencyValue t = new Tbl_CurrencyValue();
            t.CurrencyID = 1;
            t.CurrencyBuying = decimal.Parse(dolarAlis);
            t.CurrencySelling = decimal.Parse(dolarSatis);
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_CurrencyValue.Add(t);
            db.SaveChanges();



        }

        public void SaveCurrencyEuro()
        {
            string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            string euroAlis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            euroAlis = euroAlis.Replace(".", ",");

            string euroSatis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            euroSatis = euroSatis.Replace(".", ",");

            Tbl_CurrencyValue t = new Tbl_CurrencyValue();
            t.CurrencyID = 2;
            t.CurrencyBuying = decimal.Parse(euroAlis);
            t.CurrencySelling = decimal.Parse(euroSatis);
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_CurrencyValue.Add(t);
            db.SaveChanges();



        }


        public void SaveCurrencyPound()
        {
            string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            string poundAlis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteBuying").InnerXml;
            poundAlis = poundAlis.Replace(".", ",");

            string poundSatis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            poundSatis = poundSatis.Replace(".", ",");

            Tbl_CurrencyValue t = new Tbl_CurrencyValue();
            t.CurrencyID = 4;
            t.CurrencyBuying = decimal.Parse(poundAlis);
            t.CurrencySelling = decimal.Parse(poundSatis);
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_CurrencyValue.Add(t);
            db.SaveChanges();



        }
    }
}
