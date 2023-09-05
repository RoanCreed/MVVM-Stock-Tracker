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
    public class DeleteStockCommand : CommandBase
    {
        private readonly EditStockViewModel _editStockViewModel;
        

        public DeleteStockCommand(EditStockViewModel editStockViewModel)
        {
            _editStockViewModel = editStockViewModel;
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



            StockData.DeleteStockDataFromDb(stockData);
            _editStockViewModel.UpdateStocks();

        }
    }
}
