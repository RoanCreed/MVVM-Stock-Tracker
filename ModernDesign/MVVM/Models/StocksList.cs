using ModernDesign.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSettings.MVVM.Models
{
    public class StocksList
    {

        private readonly List<StockDataModel> _stockData;

        public StocksList()
        {
            _stockData = new List<StockDataModel>();
        }

        public IEnumerable<StockDataModel> GetAllStockData() 
        { 
            return StockData.GetAllStockData();
        }

        public void AddStock(StockDataModel StockData)
        {
            _stockData.Add(StockData);
        }


    }
}
