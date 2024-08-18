using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fintual
{
	public class Portfolio
	{
		private Dictionary<Stock, double> holdings;

		public Portfolio()
		{
			holdings = new Dictionary<Stock, double>();
		}

		public void AddStock(Stock stock, double quantity)
		{
			if (holdings.ContainsKey(stock))
			{
				holdings[stock] += quantity;
			}
			else
			{
				holdings.Add(stock, quantity);
			}
		}

		public double GetProfit(DateTime startDate, DateTime endDate)
		{
			double initialPortfolioValue = 0;
			double finalPortfolioValue = 0;

			foreach (var holding in holdings)
			{
				Stock stock = holding.Key;
				double quantity = holding.Value;

				initialPortfolioValue += quantity * stock.GetPrice(startDate);
				finalPortfolioValue += quantity * stock.GetPrice(endDate);
			}

			return finalPortfolioValue - initialPortfolioValue;
		}

		public double AnnualizedReturn(DateTime startDate, DateTime endDate)
		{
			double profit = GetProfit(startDate, endDate);
			double initialPortfolioValue = holdings.Sum(holding => (double)holding.Value * holding.Key.GetPrice(startDate));

			double totalReturn = (double)(initialPortfolioValue + profit) / (double)initialPortfolioValue;
			double years = (endDate - startDate).TotalDays / 365.0;

			return Math.Pow(totalReturn, 1 / years) - 1;
		}
	}
}
