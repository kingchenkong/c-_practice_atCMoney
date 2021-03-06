﻿using System;
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
        public void QuickSortByPrice(int left, int right)
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
            QuickSortByPrice(left, j - 1);  // Part left
            QuickSortByPrice(j + 1, right); // Part right
        }
        public void PracSwap(int index1, int index2)
        {
            Stock temp = this.stockList[index1];
            this.stockList[index1] = this.stockList[index2];
            this.stockList[index2] = temp;
        }
		public void MergeSortByPrice(int start, int end)
		{
            for (int j = 0; j < this.dataCount / 2; j++)
			{
				int spSta = start;
				int spMid = 0;
				int spCount = 0;
				for (int i = start; i < end; i++)
				{
                    if (this.stockList[i].GetPriceDouble() > this.stockList[i + 1].GetPriceDouble())
					{
						spCount++;
						if (spCount % 2 == 1)
						{
							spMid = i;
							if (i == end - 1)
							{
                                this.MergeList(spSta, spMid, end);
							}
						}
						else
						{
							this.MergeList(spSta, spMid, i);
							spSta = i + 1;
						}
					}
				}
				if (spCount == 1)
                    this.MergeList(start, spMid, end);
				if (spCount == 0)
					break;
			}
		}
		public void MergeList(int s, int m, int e)
		{
            Stock[] temp = new Stock[this.dataCount];
			int i = s;
			int j = m + 1;
			int k = i;
			while (i <= m && j <= e)
			{
				if (this.stockList[i].GetPriceDouble() < this.stockList[j].GetPriceDouble())
                    temp[k++] = this.stockList[i++];
				else
					temp[k++] = this.stockList[j++];
			}
			if (i > m)
				for (int t = j; t <= e; t++)
					temp[k++] = this.stockList[t];
			else
				for (int t = i; t <= m; t++)
					temp[k++] = this.stockList[t];
			for (int l = s; l <= e; l++)
			{
				this.stockList[l] = temp[l];
			}
		}
        public void RecusiveMergeSortByPrice(int start, int end)
        {
            if (start >= end)
                return;
            int mid = (start + end) / 2;
            this.RecusiveMergeSortByPrice(start, mid);
            this.RecusiveMergeSortByPrice(mid + 1, end);
            this.MergeList(start, mid, end);

        }
        public void HeapSortByPrice(int n)
		{
			for (int i = (n - 1) / 2; i >= 0; i--)
				Adjust(i, n);
			for (int i = n - 2; i >= 0; i--)
			{
				PracSwap(0, i + 1);
				Adjust(0, i + 1);
			}
		}
		public void Adjust(int root, int n)
		{
            Stock temp = this.stockList[root];
			int child = 2 * root + 1; // left child
			while (child < n) // 做到最後一層的子節點
			{
                if ((child < n - 1) && (this.stockList[child].GetPriceDouble() < this.stockList[child + 1].GetPriceDouble()))
					child++;
                if (temp.GetPriceDouble() > this.stockList[child].GetPriceDouble()) // 比較 root 和 左右二子中較大者
					break;
				else
				{
                    this.stockList[(child - 1) / 2] = this.stockList[child]; // 子節點較大就交換
					child = 2 * child + 1;
				}
			}
			this.stockList[(child - 1) / 2] = temp; // 回到前一個(終止會超過一層)   
		}
    }
}
