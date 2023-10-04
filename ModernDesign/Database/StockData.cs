using Microsoft.EntityFrameworkCore;
using ModernDesign.Exceptions;
using ModernDesign.MVVM.Models;
using ModernDesign.Stores;
using MVVMSettings.MVVM.Models;
using MVVMSettings.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace ModernDesign.Database
{
    public class StockData
    {
        public static void AddStockDataToDb(StockDataModel stock)
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



        public async Task EditStockDataFromDbAsync(StockDataModel stock)
        {
            try
            {
                using (var db = new StockContext())
                {
                    db.Update(stock);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
            }
        }

        public List<StockDataModel> GetAllStockData()
        {
            using (var db = new StockContext())
            {
                return db.Stocks.ToList();
            }
        }

        
        public async Task<List<StockDataModel>> GetAllStockDataAsync()
        {
            using (var db = new StockContext())
            {
                return await db.Stocks.ToListAsync(); 
            }
        }

    }
}
