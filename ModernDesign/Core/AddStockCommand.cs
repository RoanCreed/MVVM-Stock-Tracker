using ModernDesign.Database;
using MVVMSettings.MVVM.Models;
using MVVMSettings.MVVM.ViewModels;

namespace ModernDesign.Core
{
    public class AddStockCommand : CommandBase
    {
        private readonly AddStockViewModel _addStockViewModel;
        private readonly StocksList _stocksList;

        public AddStockCommand(AddStockViewModel addStockViewModel, StocksList stocksList)
        {
            _addStockViewModel = addStockViewModel;
            _stocksList = stocksList;
        }

        public override void Execute(object parameter)
        {
            StockDataModel stockData = new StockDataModel(
                _addStockViewModel.StockName, 
                _addStockViewModel.Shares, 
                _addStockViewModel.AvgBuyPrice, 
                _addStockViewModel.CurrentBuyPrice, 
                _addStockViewModel.ReturnInvestment
                );

            _stocksList.AddStock(stockData);
            StockData.AddStockDataToDb(stockData);
        }
    }
}
