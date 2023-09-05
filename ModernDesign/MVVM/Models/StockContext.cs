using Microsoft.EntityFrameworkCore;
using MVVMSettings.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDesign.MVVM.Models
{
    public class StockContext : DbContext
    {
        public DbSet<StockDataModel> Stocks { get; set; }

        public string dbPath = @"B:\Roan\Coding\C# Visual Studio\MVVMSettings\ModernDesign\Database\stocks.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={dbPath}"); //Connection string
    }
}
