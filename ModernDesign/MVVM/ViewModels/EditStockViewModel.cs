using ModernDesign.Core;
using ModernDesign.Exceptions;
using ModernDesign.MVVM.ViewModels;
using ModernDesign.Stores;
using MVVMSettings.MVVM.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

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

            EditStockCommand = new EditStockCommand(this, stocksList, messageStore);
            DeleteStockCommand = new DeleteStockCommand(this, messageStore);
            
            UpdateStocks();

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

        public void UpdateStocks()
        {
            _stockData.Clear();

            foreach (StockDataModel stock in _stocksList.GetAllStockData())
            {
                StockListViewModel StockDataModel = new StockListViewModel(stock);
                _stockData.Add(StockDataModel);
            }
        }

        
    }
}
