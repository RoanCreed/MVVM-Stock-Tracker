using ModernDesign.Database;
using ModernDesign.Exceptions;
using ModernDesign.Stores;
using MVVMSettings.MVVM.Models;
using MVVMSettings.MVVM.ViewModels;
using System;

namespace ModernDesign.Core
{
    public class AddStockCommand : CommandBase
    {
        private readonly AddStockViewModel _addStockViewModel;
        
        private readonly MessageStore _messageStore;

        public AddStockCommand(AddStockViewModel addStockViewModel, MessageStore messageStore)
        {
            _addStockViewModel = addStockViewModel;
            
            _messageStore = messageStore;
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
                _messageStore.SetCurrentMessage("Input validation failed", MessageType.Error);
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

        public static bool CheckIsString(string stockName)
        {
            foreach (char c in stockName)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
