﻿using ModernDesign.Exceptions;
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
                
                    using (var db = new StockContext())
                    {
                        if (!db.Stocks.Contains(stock))
                        {
                            db.Add(stock);
                            db.SaveChanges();
                        }
                        else
                        {
                            db.SaveChanges();
                            throw new StockAlreadyExsistsException();
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
                
                    using (var db = new StockContext())
                    {
                        db.Remove(stock);
                        db.SaveChanges();
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
                
                    using (var db = new StockContext())
                    {
                        db.Update(stock);
                        db.SaveChanges();
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



        
    }
}
