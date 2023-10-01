using ModernDesign.Database;
using ModernDesign.Exceptions;
using ModernDesign.Stores;
using MVVMSettings.MVVM.Models;
using MVVMSettings.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDesign.Core
{
    public class DeleteStockCommand : CommandBase
    {
        private readonly EditStockViewModel _editStockViewModel;
        private readonly MessageStore _messageStore;

        public DeleteStockCommand(EditStockViewModel editStockViewModel, MessageStore messageStore)
        {
            _messageStore = messageStore;
            _editStockViewModel = editStockViewModel;
        }

        public override void Execute(object parameter)
        {
            try
            {
                if (_editStockViewModel.SelectedItem != null)
                {
                    float initalInvestment = _editStockViewModel.Shares * _editStockViewModel.AvgBuyPrice;
                    float currentInvestment = _editStockViewModel.Shares * _editStockViewModel.CurrentBuyPrice;

                    float returnInvestment = currentInvestment - initalInvestment;

                    StockDataModel stockData = new StockDataModel(
                        _editStockViewModel.StockName.ToUpper(),
                        _editStockViewModel.Shares,
                        returnInvestment,
                        _editStockViewModel.AvgBuyPrice,
                        _editStockViewModel.CurrentBuyPrice
                        );


                    StockData.DeleteStockDataFromDb(stockData);
                    _messageStore.SetCurrentMessage("Stock deleted", MessageType.Status);
                    _editStockViewModel.UpdateStocks();
                }
                else
                {
                    throw new NoSelectedItemException();
                }
            }
            catch (Exception)
            {
                _messageStore.SetCurrentMessage("Selection validation failed", MessageType.Error);
            }

        }
    }
}
