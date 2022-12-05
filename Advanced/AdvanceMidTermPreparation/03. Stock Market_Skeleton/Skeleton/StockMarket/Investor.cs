using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private Dictionary<string,Stock> portfolio;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;

            portfolio = new Dictionary<string, Stock>();
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count { get { return portfolio.Count; } }

        public void BuyStock(Stock stock)
        {
            
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                if (!portfolio.ContainsKey(stock.CompanyName))
                {
                    portfolio.Add(stock.CompanyName, stock);
                    MoneyToInvest -= stock.PricePerShare;  //check later
                }               
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!portfolio.ContainsKey(companyName))
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice < portfolio[companyName].PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            else 
            {
                this.MoneyToInvest += sellPrice;
                portfolio.Remove(companyName);
                return $"{companyName} was sold.";
            }
        }
        public Stock FindStock(string companyName)
        {
            if (portfolio.ContainsKey(companyName))
            {
                return portfolio[companyName];
            }
            else
            {
                return null;
            }
        }
        public Stock FindBiggestCompany()
        {
            if (this.Count == 0)
            {
                return null;
            }
            else
            {
                decimal biggestCap = 0;
                Stock biggestStock = null;
                foreach (var stock in portfolio.Values)
                {
                    if (stock.MarketCapitalization>biggestCap)
                    {
                        biggestCap = stock.MarketCapitalization;
                        biggestStock = stock;
                    }
                }

                return biggestStock;
            }
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var item in portfolio.Values)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
