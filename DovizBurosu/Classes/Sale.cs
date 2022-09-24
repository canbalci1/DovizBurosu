using DovizBurosu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DovizBurosu.Classes
{
    public class Sale
    {
        DovizProjeEntities db = new DovizProjeEntities();

        public void MakeSale (string customerName,string customerSurname,int currencyCode,string operationType, decimal currentValue, decimal amount, decimal
            totalPrice)
        {
            Tbl_Operation t = new Tbl_Operation();
            t.CustomerName = customerName;
            t.CustomerSurname = customerSurname;
            t.CurrencyId = currencyCode ;
            t.OperationType = operationType ;
            t.CurrentValue = currentValue;
            t.Amaunt = amount ;
            t.TotalPrice = totalPrice;
            t.Date =DateTime.Parse (DateTime.Now.ToShortTimeString());
            db.Tbl_Operation.Add(t);
            db.SaveChanges();
            Console.WriteLine("İşlem başarıyla kaydedildi");

        }
    }
}
