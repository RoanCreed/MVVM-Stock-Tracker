using ModernDesign.API;
using ModernDesign.Database;
using ModernDesign.Exceptions;
using ModernDesign.Stores;
using MVVMSettings.MVVM.Models;
using MVVMSettings.MVVM.ViewModels;
using System;
using System.Threading.Tasks;

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
                    CurrentDataAPI currentData = new CurrentDataAPI();

                    APIData[] apiResponse = currentData.CallApiSync(_addStockViewModel.StockName);
                    if (apiResponse != null)
                    {
                        _addStockViewModel.CurrentBuyPrice = apiResponse[0].Price;
                    }
                    else
                    {
                        
                        throw new StockDoesNotExsistException();
                    }

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
                    _messageStore.SetCurrentMessage("Stock added successfully!", MessageType.Status);
                }
                
            }
            catch (Exception ex)
            {
                if (ex is InputValidationException)
                {
                    _messageStore.SetCurrentMessage("Input validation failed", MessageType.Error);
                }
                else if(ex is StockDoesNotExsistException)
                {
                    _messageStore.SetCurrentMessage("Stock name does not exsist", MessageType.Error);
                }
                else if (ex is StockAlreadyExsistsException)
                {
                    _messageStore.SetCurrentMessage("Stock name already exsists", MessageType.Error);
                }
                else
                {
                    _messageStore.SetCurrentMessage("Error", MessageType.Error);
                }
                
            }

        }


        public static bool CheckInput(AddStockViewModel stock)
        {
            if (stock.Shares == 0
                || stock.AvgBuyPrice == 0
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

        public static bool CheckIsString(string stockName)  //Can delete?
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
