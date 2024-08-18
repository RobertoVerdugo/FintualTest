using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fintual
{
	public class Stock
    {
        public string Name;
        private Dictionary<DateTime, double> prices = new Dictionary<DateTime, double>();

        public Stock(string name, Dictionary<DateTime, double> prices)
		{
			Name = name;
			this.prices = prices;
		}
		public double GetPrice(DateTime date)
		{
			if (prices.ContainsKey(date))
			{
				return prices[date];
			}
			throw new Exception("Price not available for the given date.");
		}

		public void AddPrice(DateTime date, double price)
        {
			prices[date] = price;
        }
    }
}
