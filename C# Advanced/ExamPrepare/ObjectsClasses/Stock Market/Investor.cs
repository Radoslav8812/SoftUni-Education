using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private Dictionary<string, Stock> Portfolio;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new Dictionary<string, Stock>();
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {

            if (stock.MarketCapitalization > 10000 && MoneyToInvest > stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock.CompanyName ,stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var item = Portfolio.FirstOrDefault(x => x.Key == companyName);

            if (item.Key == null)
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice < item.Value.PricePerShare)
            {
                return $"Cannot sell {item.Key}.";
            }
            else
            {
                Portfolio.Remove(item.Key);
                MoneyToInvest += sellPrice;
                return $"{companyName} was sold.";
            }
        }

        public Stock FindStock(string companyName)
        {
            var stockToFind = Portfolio.FirstOrDefault(x => x.Key == companyName);

            return stockToFind.Value;
        }

        public Stock FindBiggestCompany()
        {
            return Portfolio.Values.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var item in Portfolio)
            {
                sb.AppendLine(item.Value.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }

}
