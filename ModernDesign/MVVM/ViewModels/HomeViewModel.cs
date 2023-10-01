using ModernDesign.API;
using ModernDesign.Core;
using ModernDesign.MVVM.ViewModels;
using ModernDesign.Stores;
using MVVMSettings.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModernDesign.Database;

namespace MVVMSettings.MVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private StocksList _stocksList;
        private readonly ObservableCollection<StockListViewModel> _stockData;

        private float _totalReturn;
        public float TotalReturn
        {
            get
            {
                return _totalReturn;
            }
            set
            {

                _totalReturn = value;
                OnPropertyChanged(nameof(TotalReturn));
            }
        }


        public IEnumerable<StockListViewModel> StockDataCollection => _stockData;

        public HomeViewModel(StocksList stocksList)
        {
            _stocksList = stocksList;
            _stockData = new ObservableCollection<StockListViewModel>();


            UpdateCurrentPrice();
            GetStocks();

            
        }

        private void GetStocks()
        {
            _stockData.Clear();


            foreach(StockDataModel stock in _stocksList.GetAllStockData())
            {
                StockListViewModel StockDataModel = new StockListViewModel(stock);
                _stockData.Add(StockDataModel);
                _totalReturn += stock.ReturnInvestment;
            }


            OnPropertyChanged(nameof(TotalReturn));
        }

        private void UpdateCurrentPrice()
        {
            CurrentDataAPI currentData = new CurrentDataAPI();


            foreach (StockDataModel stock in _stocksList.GetAllStockData())
            {
                APIData[] apiResponse = currentData.CallApiSync(stock.StockName);
                if (apiResponse != null)
                {
                    stock.CurrentBuyPrice = apiResponse[0].Price;

                    float initalInvestment = stock.Shares * stock.AvgBuyPrice;
                    float currentInvestment = stock.Shares * stock.CurrentBuyPrice;

                    float returnInvestment = currentInvestment - initalInvestment;

                    StockDataModel stockData = new StockDataModel(
                        stock.StockName.ToUpper(),
                        stock.Shares,
                        returnInvestment,
                        stock.AvgBuyPrice,
                        stock.CurrentBuyPrice
                        );

                    StockData.EditStockDataFromDb(stockData);
                }
            }

        }
    }
}
