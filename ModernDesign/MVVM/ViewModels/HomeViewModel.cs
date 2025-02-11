using ModernDesign.API;
using ModernDesign.Stores;
using MVVMSettings.MVVM.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ModernDesign.Database;
using ModernDesign.Core;
using ModernDesign.MVVM.ViewModels;
using System.Threading.Tasks;
using System;



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
        public ICommand LoadStocksCommand { get; }

        public HomeViewModel(StocksList stocksList)
        {
            _stocksList = stocksList;
            _stockData = new ObservableCollection<StockListViewModel>();


            LoadStocksCommand = new LoadStocksCommand(this, new StockStore(stocksList));
            LoadStocksCommand.Execute(null);    //Loads the stocks through an async command
            //UpdateCurrentPrice();
            //GetStocks();

        }

        public void UpdateStocksAsync(IEnumerable<StockDataModel> _stocks)
        {
            _stockData.Clear();
            foreach (StockDataModel stock in _stocks)
            {
                StockListViewModel StockDataModel = new StockListViewModel(stock);
                _stockData.Add(StockDataModel);
                _totalReturn += stock.ReturnInvestment;
            }
            OnPropertyChanged(nameof(TotalReturn));
        }


       
        private void GetStocks() //never used? (cause it ain't async)
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

        private void UpdateCurrentPrice() //also never used (cause it ain't async)
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
