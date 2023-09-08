using ModernDesign.Database;
using ModernDesign.Exceptions;
using MVVMSettings.MVVM.Models;
using MVVMSettings.MVVM.ViewModels;
using System;

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

            try
            {
                if (CheckInput(_addStockViewModel))
                {
                    float initalInvestment = _addStockViewModel.Shares * _addStockViewModel.AvgBuyPrice;
                    float currentInvestment = _addStockViewModel.Shares * _addStockViewModel.CurrentBuyPrice;

                    float returnInvestment = currentInvestment - initalInvestment;

                    StockDataModel stockData = new StockDataModel(
                        _addStockViewModel.StockName.ToUpper(),
                        _addStockViewModel.Shares,
                        returnInvestment,
                        _addStockViewModel.AvgBuyPrice,
                        _addStockViewModel.CurrentBuyPrice
                        );


                    StockData.AddStockDataToDb(stockData);
                    
                }
                
            }
            catch (Exception)
            {

            }

        }


        public static bool CheckInput(AddStockViewModel stock)
        {
            if (stock.Shares == 0
                || stock.AvgBuyPrice == 0
                || stock.CurrentBuyPrice == 0
                || string.IsNullOrWhiteSpace(stock.StockName)
                )

            {
                throw new InputValidationException();
            }
            else
            {
                return true;
            }
        }
    }
}
