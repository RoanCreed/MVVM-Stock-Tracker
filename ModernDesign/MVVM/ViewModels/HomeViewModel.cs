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


        public IEnumerable<StockListViewModel> StockData => _stockData;

        //public ICommand AddStockCommand { get; }

        public HomeViewModel(StocksList stocksList)
        {
            _stocksList = stocksList;
            _stockData = new ObservableCollection<StockListViewModel>();

            UpdateStocks();

            
            /*
            _stockData.Add(new StockListViewModel(new StockDataModel("AAPL", 50, 1000, 20, 20)));
            _stockData.Add(new StockListViewModel(new StockDataModel("RIVN", 7, 899, 54, 22)));
            _stockData.Add(new StockListViewModel(new StockDataModel("TSLA", 76, 6548, 90, 16)));
            _stockData.Add(new StockListViewModel(new StockDataModel("SBUX", 50, 323, 5, 6)));
            */
        }

        private void UpdateStocks()
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
    }
}
