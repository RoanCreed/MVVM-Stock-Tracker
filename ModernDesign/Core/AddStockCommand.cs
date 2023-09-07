using ModernDesign.Database;
using ModernDesign.Exceptions;
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
            
                float initalInvestment = _addStockViewModel.Shares * _addStockViewModel.AvgBuyPrice;
                float currentInvestment = _addStockViewModel.Shares * _addStockViewModel.CurrentBuyPrice;

                float returnInvestment = currentInvestment - initalInvestment;

                StockDataModel stockData = new StockDataModel(
                    _addStockViewModel.StockName,
                    _addStockViewModel.Shares,
                    returnInvestment,
                    _addStockViewModel.AvgBuyPrice,
                    _addStockViewModel.CurrentBuyPrice
                    );


                StockData.AddStockDataToDb(stockData);
            
        }
    }
}
