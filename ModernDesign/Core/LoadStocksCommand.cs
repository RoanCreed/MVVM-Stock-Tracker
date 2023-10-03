using ModernDesign.Stores;
using MVVMSettings.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernDesign.Core
{
    public class LoadStocksCommand : AsyncCommandBase
    {
        private HomeViewModel _viewModel;
        private readonly StockStore _stockStore;

        public LoadStocksCommand(HomeViewModel viewModel, StockStore stockStore)
        {
            _viewModel = viewModel;
            _stockStore = stockStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _stockStore.Load();

                _viewModel.UpdateStocks(_stockStore.Stocks);
            }
            catch (Exception)
            {
                //MessageBox.Show("Failed to load stocks.", "Error",   //Add this into the global message store
            }
        }
    }
}
