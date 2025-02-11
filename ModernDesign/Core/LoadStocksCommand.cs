using ModernDesign.API;
using ModernDesign.Database;
using ModernDesign.Stores;
using MVVMSettings.MVVM.Models;
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

                CurrentDataAPI currentData = new CurrentDataAPI();
                foreach (StockDataModel stock in _stockStore.Stocks)
                {
                    APIData[] apiResponse = currentData.CallApiSync(stock.StockName);
                    if (apiResponse != null)
                    {
                        Console.WriteLine(apiResponse);
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

                        StockData stockDataHelper = new StockData();
                        await Task.Run(() => stockDataHelper.EditStockDataFromDbAsync(stockData));
                    }
                }

                _viewModel.UpdateStocksAsync(_stockStore.Stocks);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load stocks.", "Error");   //Add this into the global message store
            }
        }
    }
}
