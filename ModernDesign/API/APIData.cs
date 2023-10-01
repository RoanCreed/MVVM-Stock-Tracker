using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDesign.API
{
    public class APIData
    {
        public string Symbol { get; set; } // "AAPL"

        public string Name { get; set; } // "Apple Inc."

        public float Price { get; set; } // 149.55000000

        public double ChangesPercentage { get; set; } // 0.38934135

        public double Change { get; set; } // 0.58000183

        public double DayLow { get; set; } // 148.75000000

        public double DayHigh { get; set; } // 151.41000000

        public double YearHigh { get; set; } // 157.26000000

        public double YearLow { get; set; } // 103.10000000

        public double MarketCap { get; set; } // 2472091320320.00000000

        public double PriceAvg50 { get; set; } // 149.04265000

        public double PriceAvg200 { get; set; } // 134.71935000

        public long Volume { get; set; } // 97750498

        public long AvgVolume { get; set; } // 78489468

        public string Exchange { get; set; } // "NASDAQ"

        public double Open { get; set; } // 150.63000000

        public double PreviousClose { get; set; } // 148.97000000

        public double Eps { get; set; } // 5.10800000

        public double Pe { get; set; } // 29.27760500

        public string EarningsAnnouncement { get; set; } // DateTime representation of "2021-07-27T16:30:00.000+0000"

        public long SharesOutstanding { get; set; } // 16530199400

        public long Timestamp { get; set; } // 1631575899


        public APIData()
        {
        }
    }
}
