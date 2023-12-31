﻿using ModernDesign.Core;
using ModernDesign.MVVM.ViewModels;
using ModernDesign.Stores;
using MVVMSettings.MVVM.Models;
using System.Windows;
using System.Windows.Input;

namespace MVVMSettings.MVVM.ViewModels
{
    public class AddStockViewModel : ViewModelBase
    {

        
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
            }
        }

        public ICommand AddStockCommand { get; }

        public GlobalMessageViewModel GlobalMessageViewModel { get; }

        public AddStockViewModel(NavigationStore navigationStore, MessageStore messageStore, GlobalMessageViewModel globalMessageViewModel)
        {
            GlobalMessageViewModel = globalMessageViewModel;
            AddStockCommand = new AddStockCommand(this, messageStore);
            
        }

        

    }
}
