using System;
using System.IO;
using System.Text;
namespace _QuickSort_practice
{
    public class Trader
    {
        // Attrubutes
        // IO
        private string sourceFileName;
        private string destinationFileName;
        // - in
        private FileStream fromStream;
        private StreamReader fileReader;
        //  - out
        private FileStream toStream;
        private StreamWriter fileWriter;
        // Stock
        private Stock[] stockList;
        private int dataCount;
        private String title;

        // Constructor
        // 建構子接受欲處理的資料檔路徑
        public Trader(String sourceFileName)
        {
            this.stockList = new Stock[100];
            this.SetSourceFileName(sourceFileName);
            this.fromStream = new FileStream(this.sourceFileName, FileMode.Open, FileAccess.Read);
            this.fileReader = new StreamReader(fromStream, Encoding.UTF8);

            String loadInStr;

            title = fileReader.ReadLine();

            while ((loadInStr = fileReader.ReadLine()) != null)
            {
                //Console.WriteLine(loadInStr);
                //fileWriter.WriteLine(loadInStr);
                string[] arrToSplit = loadInStr.Split(',');

                if (dataCount == this.stockList.Length)
                    this.Resize();
                stockList[dataCount++] = new Stock(arrToSplit);
            }
            // Close stream
            this.fromStream.Close();
            this.fileReader.Close();
        }

        // Setter
        public void SetSourceFileName(string source)
        {
            this.sourceFileName = source;
        }
        public void SetDestinationFileName(string dest)
        {
            this.destinationFileName = dest;
        }
        public void Resize()
        {
            Stock[] copy = new Stock[this.stockList.Length * 2];
            for (int i = 0; i < dataCount; i++)
                copy[i] = this.stockList[i];
            this.stockList = copy;
        }
        public void ExportFile()
        {
			// Write in
			this.toStream = new FileStream(this.destinationFileName, FileMode.Create, FileAccess.Write);
			this.fileWriter = new StreamWriter(this.toStream);

			try
			{
				this.fileWriter.WriteLine(this.title);
                for (int i = 0; i < this.dataCount; i++)
				{
                    this.fileWriter.WriteLine(this.stockList[i].GetString());
				}
			}
			catch
			{
				Console.WriteLine("Error. File writting issue.");
			}

			this.fileWriter.Close();
			this.toStream.Close();
        }
        // 請提供一個成員方法，接受一個股票名稱與一個檔名作為參數，
        // 此方法將會從原本的股票交易檔案中篩選出符合指定股票名稱的交易資料，並存入參數所指定的檔案中
        public bool SearchStock(String stockName, String outputFileName)
        {
            string[] select = new string[100];
            int selectDataCount = 0;
            for (int i = 0; i < dataCount; i++)
            {
                if (stockList[i].SearchByStockCode(stockName) != null)
                {
                    if (selectDataCount == select.Length)
                    {
                        // Resize
                        string[] copy = new string[select.Length * 2];
                        for (int j = 0; j < select.Length; j++)
                        {
                            copy[j] = select[j];
                        }
                        select = copy;
                    }
                    select[selectDataCount++] = stockList[i].GetString();
                }
            }
            // Not found
            if (selectDataCount == 0)
                return false;

            // Write in
            this.toStream = new FileStream(this.destinationFileName, FileMode.Create, FileAccess.Write);
            this.fileWriter = new StreamWriter(this.toStream);

            try
            {
                this.fileWriter.WriteLine(this.title);
                for (int i = 0; i < selectDataCount; i++)
                {
                    this.fileWriter.WriteLine(select[i]);
                }
            }
            catch
            {
                Console.WriteLine("Error. File writting issue.");
            }
            this.fileWriter.Close();
            this.toStream.Close();
            return true;
        }
		// Getter
        public Stock[] GetStockList(){
            return this.stockList;
        }
		public string GetStockDataByIndex(int index)
        {
            if (index <= dataCount - 1)
                return stockList[index].GetString();
            else
                return null;
        }
        public StreamReader GetFileReader()
        {
            return this.fileReader;
        }
        public String GetSourceFileName()
        {
            return this.sourceFileName;
        }
        public int GetDataCount()
        {
            return this.dataCount;
        }
        public void SortByPrice(int left, int right)
        {
            if (left >= right)
                return;
            int pivot = left;
            int i = left;
            int j = right + 1;
            while (i < j)
            {
                do i++; while (i < right + 1 && this.stockList[i].GetPriceDouble() < this.stockList[pivot].GetPriceDouble());
                do j--; while (this.stockList[j].GetPriceDouble() > this.stockList[pivot].GetPriceDouble());
                if (i < j)
                    PracSwap(i, j);
            }
            PracSwap(pivot, j);
            SortByPrice(left, j - 1);  // Part left
            SortByPrice(j + 1, right); // Part right
        }
        public void PracSwap(int index1, int index2)
        {
            Stock temp = this.stockList[index1];
            this.stockList[index1] = this.stockList[index2];
            this.stockList[index2] = temp;
        }
    }
}
