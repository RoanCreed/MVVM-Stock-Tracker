using ModernDesign.MVVM.Models;
using MVVMSettings.MVVM.Models;

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
    }
}
