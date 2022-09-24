using DovizBurosu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DovizBurosu.Classes
{


    public class SaleOperation
    {
        public void CustomerSaleOperationAlis()
        {
            DovizProjeEntities db = new DovizProjeEntities();
            var values = db.Tbl_Operation.Where(x=> x.OperationType == "alış").ToList();
            foreach (var item in values)
            {
                Console.WriteLine("ID : "
                    + item.ID
                    + " "
                    + "Müşteri: "
                    + item.CustomerName
                    + " "
                    + "Döviz: "
                    + item.Tbl_Currency.CurrencyName
                    + " "
                    + "İşlem Türü: "
                    + item.OperationType
                    + " "
                    + "Kur Birim Tutarı: "
                    + item.CurrentValue
                    + " "
                    + "Alınan Tutar: "
                    + item.Amaunt
                    + " "
                    + "Toplam Tutar: "
                    + item.TotalPrice );
            }

        }

        public void CustomerSaleOperationSatis()
        {
            DovizProjeEntities db = new DovizProjeEntities();
            var values = db.Tbl_Operation.Where(x => x.OperationType == "satış").ToList();
            foreach (var item in values)
            {
                Console.WriteLine("ID : "
                    + item.ID
                    + " "
                    + "Müşteri: "
                    + item.CustomerName
                    + " "
                    + "Döviz: "
                    + item.Tbl_Currency.CurrencyName
                    + " "
                    + "İşlem Türü: "
                    + item.OperationType
                    + " "
                    + "Kur Birim Tutarı: "
                    + item.CurrentValue
                    + " "
                    + "Alınan Tutar: "
                    + item.Amaunt
                    + " "
                    + "Toplam Tutar: "
                    + item.TotalPrice);
            }

        }
    }
}
