using MVVMSettings.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDesign.Stores
{
    public class StockStore
    {
        private readonly List<StockDataModel> _stocks;
        private readonly StocksList _stocksList;

        public IEnumerable<StockDataModel> Stocks => _stocks;

        public StockStore(StocksList stocksList) 
        {
            _stocks = new List<StockDataModel>();
            _stocksList = stocksList;
        }

        public async Task Load()
        {
            IEnumerable<StockDataModel> stocks = await _stocksList.GetAllStockDataAsync();

            _stocks.Clear();
            _stocks.AddRange(stocks);
        }


    }
}
