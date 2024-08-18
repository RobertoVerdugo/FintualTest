using Fintual;

DateTime date1 = new DateTime(2024, 1, 1);
DateTime date2 = new DateTime(2024, 12, 31);

var stock1 = new Stock("Stock1", new Dictionary<DateTime, double>
			{
				{ date1, 100 },
				{ date2, 120 }
			});

var stock2 = new Stock("Stock2", new Dictionary<DateTime, double>
			{
				{ date1, 200 },
				{ date2, 220 }
			});

var portfolio = new Portfolio();
portfolio.AddStock(stock1, 50.18293f); // 50.18293 acciones de Stock1
portfolio.AddStock(stock2, 100); // 100 acciones de Stock2

var profit = portfolio.GetProfit(date1, date2);
Console.WriteLine($"Profit: {profit}");

var annualizedReturn = portfolio.AnnualizedReturn(date1, date2);
Console.WriteLine($"Annualized Return: {annualizedReturn:P2}");
