using ModernDesign.Database;
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
            StockDataModel stockData = new StockDataModel(
                _editStockViewModel.StockName,
                _editStockViewModel.Shares,
                _editStockViewModel.AvgBuyPrice,
                _editStockViewModel.CurrentBuyPrice,
                _editStockViewModel.ReturnInvestment
                );

            

            StockData.EditStockDataFromDb(stockData);
            _editStockViewModel.UpdateStocks();

        }
    }
}
