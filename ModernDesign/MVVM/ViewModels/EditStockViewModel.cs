using ModernDesign.Core;
using ModernDesign.MVVM.ViewModels;
using ModernDesign.Stores;
using MVVMSettings.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace MVVMSettings.MVVM.ViewModels
{
    public class EditStockViewModel : ViewModelBase
    {
        private StocksList _stocksList;
        private readonly ObservableCollection<StockListViewModel> _stockData;



        private string _stockName;
        public string StockName
        {
            get
            {
                return _stockName;
            }
            set
            {
                _stockName = value;
                OnPropertyChanged(nameof(StockName));
            }
        }

        private int _shares;
        public int Shares
        {
            get
            {
                return _shares;
            }
            set
            {
                _shares = value;
                OnPropertyChanged(nameof(Shares));
            }
        }

        
        private float _avgBuyPrice;
        public float AvgBuyPrice
        {
            get
            {
                return _avgBuyPrice;
            }
            set
            {
                _avgBuyPrice = value;
                OnPropertyChanged(nameof(AvgBuyPrice));
            }
        }

        private float _currentBuyPrice;
        public float CurrentBuyPrice
        {
            get
            {
                return _currentBuyPrice;
            }
            set
            {
                _currentBuyPrice = value;
                OnPropertyChanged(nameof(CurrentBuyPrice));
                
            }
        }

        private StockListViewModel _selectedItem;

        

        public StockListViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                UpdateTextboxes(SelectedItem);
            }
        }

        public IEnumerable<StockListViewModel> StockData => _stockData;

        public ICommand EditStockCommand { get; }
        public ICommand DeleteStockCommand { get; }


        public GlobalMessageViewModel GlobalMessageViewModel { get; }

        public EditStockViewModel(StocksList stocksList, NavigationStore navigationStore, MessageStore messageStore, GlobalMessageViewModel globalMessageViewModel)
        {
            _stocksList = stocksList;
            _stockData = new ObservableCollection<StockListViewModel>();
            GlobalMessageViewModel = globalMessageViewModel;

            EditStockCommand = new EditStockCommand(this, messageStore);
            DeleteStockCommand = new DeleteStockCommand(this, messageStore);

            InitializeAsync(); //NEVER CALLED???

        }

        private void UpdateTextboxes(StockListViewModel SelectedItem)
        {
            if(SelectedItem != null)
            {
                StockName = SelectedItem.StockName;
                Shares = int.Parse(SelectedItem.Shares);
                AvgBuyPrice = float.Parse(SelectedItem.AvgBuyPrice);
                CurrentBuyPrice = float.Parse(SelectedItem.CurrentBuyPrice);
                
            }
            else
            {
                StockName = "0";
                Shares = 0;
                AvgBuyPrice = 0;
                CurrentBuyPrice = 0;
                
            }
            
        }

        private async void InitializeAsync()
        {
            Console.WriteLine("we before the wait");
            await UpdateStocks();
            Console.WriteLine("we past the wait");
        }

        public async Task UpdateStocks()
        {
            _stockData.Clear();
            IEnumerable<StockDataModel> stocks = await _stocksList.GetAllStockDataAsync();
            foreach (StockDataModel stock in stocks)
            {
                StockListViewModel StockDataModel = new StockListViewModel(stock);
                _stockData.Add(StockDataModel);
            }
        }

        
    }
}
