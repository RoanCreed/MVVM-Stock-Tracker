using ModernDesign.API;
using ModernDesign.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSettings.MVVM.Models
{
    public class StocksList
    {

        private readonly List<StockDataModel> _stockDataList;
        private StockData _stockData;

        public StocksList()
        {
            _stockDataList = new List<StockDataModel>();
            _stockData = new StockData();
        }

        public IEnumerable<StockDataModel> GetAllStockData() 
        {
            return _stockData.GetAllStockData();
        }

        public async Task<IEnumerable<StockDataModel>> GetAllStockDataAsync()
        {
            return await _stockData.GetAllStockDataAsync();
        }


    }
}
