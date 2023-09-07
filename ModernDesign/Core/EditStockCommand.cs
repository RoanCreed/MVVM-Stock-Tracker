using ModernDesign.Database;
using ModernDesign.Exceptions;
using MVVMSettings.MVVM.Models;
using MVVMSettings.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDesign.Core
{
    public class EditStockCommand : CommandBase
    {

        private readonly EditStockViewModel _editStockViewModel;
        private readonly StocksList _stocksList;

        public EditStockCommand(EditStockViewModel editStockViewModel, StocksList stocksList)
        {
            _editStockViewModel = editStockViewModel;
            _stocksList = stocksList;
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


                    StockData.EditStockDataFromDb(stockData);
                    _editStockViewModel.UpdateStocks();
                }
                else 
                { 
                    throw new NoSelectedItemException(); 
                }
            }
            catch (Exception)
            { 
                
            }
            
            

        }
    }
}
