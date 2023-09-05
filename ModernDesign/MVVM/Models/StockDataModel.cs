using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSettings.MVVM.Models
{
    public class StockDataModel
    {
        public StockDataModel(string stockName, int shares, float returnInvestment, float avgBuyPrice, float currentBuyPrice)
        {
            StockName = stockName;
            Shares = shares;
            ReturnInvestment = returnInvestment;
            AvgBuyPrice = avgBuyPrice;
            CurrentBuyPrice = currentBuyPrice;
        }

        public string StockName { get; set; }
        public int Shares { get; set; }
        public float ReturnInvestment { get; set; }
        public float AvgBuyPrice { get; set; }
        public float CurrentBuyPrice { get; set; }


        

    }
}
