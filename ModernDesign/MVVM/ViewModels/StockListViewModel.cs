using MVVMSettings.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSettings.MVVM.ViewModels
{
    public class StockListViewModel : ViewModelBase
    {

        private readonly StockDataModel _stockData;

        public string StockName => _stockData.StockName?.ToString();
        public string Shares => _stockData.Shares.ToString();
        public string ReturnInvestment => _stockData.ReturnInvestment.ToString();
        public string AvgBuyPrice => _stockData.AvgBuyPrice.ToString();
        public string CurrentBuyPrice => _stockData.CurrentBuyPrice.ToString();

        public StockListViewModel(StockDataModel stockData)
        {
            _stockData = stockData;
        }
    }
}
