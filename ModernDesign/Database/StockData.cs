using ModernDesign.MVVM.Models;
using MVVMSettings.MVVM.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModernDesign.Database
{
    public static class StockData
    {
        public static void AddStockDataToDb(StockDataModel stock)
        {
            using (var db = new StockContext())
            {
                db.Add(stock);
                db.SaveChanges();
            }
        }

        public static void DeleteStockDataFromDb(StockDataModel stock)
        {
            using (var db = new StockContext())
            {
                db.Remove(stock);
                db.SaveChanges();
            }
        }

        public static void EditStockDataFromDb(StockDataModel stock)
        {
            using (var db = new StockContext())
            {
                db.Update(stock);
                db.SaveChanges();
            }
        }

        public static List<StockDataModel> GetAllStockData()
        {
            using(var db = new StockContext())
            {
                return db.Stocks.ToList();
            }
        }
    }
}
