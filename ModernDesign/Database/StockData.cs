using ModernDesign.Exceptions;
using ModernDesign.MVVM.Models;
using MVVMSettings.MVVM.Models;
using MVVMSettings.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace ModernDesign.Database
{
    public static class StockData
    {
        public static void AddStockDataToDb(StockDataModel stock)
        {
            try
            {
                if (CheckInput(stock))
                {
                    using (var db = new StockContext())
                    {
                        db.Add(stock);
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception)
            {
            }


        }

        public static void DeleteStockDataFromDb(StockDataModel stock)
        {
            try
            {
                if (CheckInput(stock))
                {
                    using (var db = new StockContext())
                    {
                        db.Remove(stock);
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception)
            {
            }
        }

        public static void EditStockDataFromDb(StockDataModel stock)
        {
            try
            {
                if (CheckInput(stock))
                {
                    using (var db = new StockContext())
                    {
                        db.Update(stock);
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception)
            {
            }
        }

        public static List<StockDataModel> GetAllStockData()
        {
            using (var db = new StockContext())
            {
                return db.Stocks.ToList();
            }
        }


        public static bool CheckInput(StockDataModel stock)
        {
            if (stock.Shares == 0
                || stock.AvgBuyPrice == 0
                || stock.CurrentBuyPrice == 0
                || string.IsNullOrWhiteSpace(stock.StockName)
                )

            {
                throw new InputValidationException();
            }
            else if (!CheckIsString(stock.StockName))
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
