using System;
namespace _QuickSort_practice
{
    public class Stock
    {
        // Attrubutes
        // 日期,股票代號,股票名稱,券商代號,券商名稱,成交價,買進張數,賣出張數
        private string date;
        private string stockCode;
        private string stockName;
        private string brokerageCode;
        private string brokerageName;
        private string price;
        private string buyCount;
        private string sellCount;
        private double pricedouble;
        // Constructor
        public Stock(string[] arr)
        {
            this.SetStock(arr);
        }
        // Setter
        public void SetStock(string[] arr)
        {
            this.date = arr[0];
            this.stockCode = arr[1];
            this.stockName = arr[2];
            this.brokerageCode = arr[3];
            this.brokerageName = arr[4];
            this.price = arr[5];
            this.buyCount = arr[6];
            this.sellCount = arr[7];
            try
            {
                this.pricedouble = Double.Parse(this.price);
            }
            catch
            {
                Console.WriteLine("Error: price format incorrect, \n data: "+ this.GetString());
            }
        }
        // Getter
        public string GetString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", this.date, this.stockCode, this.stockName, this.brokerageCode, this.brokerageName, this.price, this.buyCount, this.sellCount);
        }
        public double GetPriceDouble(){
            return this.pricedouble;
        }
        public string SearchByStockCode(string s)
        {
            if (s.Equals(this.stockCode))
                return GetString();
            else
                return null;
        }
    }
}
