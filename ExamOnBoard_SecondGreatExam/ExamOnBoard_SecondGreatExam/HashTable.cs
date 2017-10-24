using System;
namespace ExamOnBoard_SecondGreatExam
{
    public class HashTable
    {
        int buckets;
        int slot;
        Data[][] table;

        public HashTable(int h, int s)
        {
            buckets = h;
            slot = s;
            table = new Data[buckets][];

            for (int i = 0; i < buckets; i++)
            {
                table[i] = new Data[slot];
            }
        }
        public bool Insert(string d)
        {
            int key = HashTable.GetHashKey(d);
            int index = HashFunc(key);
            int i = 0;
            while (i < this.slot)
            {
                if (this.table[index][i] == null)
                {
                    this.table[index][i] = new Data(GetHashKey(d), d);
                    break;
                }
                else if (this.table[index][i].word == d)
                {
                    // word is equal
                    this.table[index][i].apearCount++;
                    break;
                }
                else if( i == this.slot - 1)
                {
                    // linear probling
                    if (index == this.buckets)
                        index = 0;
                    if (this.LinearProbling(d, key, index))
                        break;
                    else
                        return false;
                }
                else
                {
                    // is occupaid
                    i++;
                }
            }
            // sucess
            return true;


        }
        public void Search(string searchStr)
        {
			int key = HashTable.GetHashKey(searchStr);
			int index = HashFunc(key);
            int i = 0;
			while (i < this.slot)
			{
				if (this.table[index][i] == null)
				{
                    Console.WriteLine(searchStr + "isn't in HashTable.");
                    return;
				}
				else if (this.table[index][i].word == searchStr)
				{
					// word is equal
                    Console.WriteLine("‘" + searchStr + "’ is found at slot " + i + ", bucket " + index +"!");
                    return;
				}
				else if (i == this.slot - 1)
				{
                    // linear probling
                    //index++;
                    index = (index + 1) % this.buckets;
                    i = 0;
				}
				else
				{
					// is occupaid
					i++;
				}
			}			
        }
        public bool LinearProbling(string d, int key,int index)
        {
            int originalIndex = index;
            Console.WriteLine("LinearProbling " + key + ", " + index);
            //index++;
            index = (index + 1) % this.buckets;
			int i = 0;
			while (i < this.slot)
			{
                //if (index == 159)
                    //Console.WriteLine("isisisis");
				if (this.table[index][i] == null)
				{
					this.table[index][i] = new Data(GetHashKey(d), d);
                    return true;
				}
				else if (this.table[index][i].word == d)
				{
					// word is equal
					this.table[index][i].apearCount++;
                    return true;
				}
				else if (i == this.slot - 1)
				{
                    // linear probling
                    index = (index + 1) % this.buckets;
                    i = 0;
                    if (index == this.buckets)
                        index = 0;
                    if (index == originalIndex)// OverFlow
                        return false;
				}
				else
				{
					// is occupaid
					i++;
				}
			}
            return true;

        }
        public void SetData(string d, int i, int j)
        {
            if (this.table[i][j] == null)
                this.table[i][j] = new Data(GetHashKey(d), d);
            else
            {
                this.table[i][j].key = GetHashKey(d);
                this.table[i][j].word = d;
                this.table[i][j].apearCount++;
            }
        }
        public Data GetData(int i, int j)
        {
            return this.table[i][j];
        }
        public int HashFunc(int key)
        {
            return key % this.buckets;
        }
        public int GetBucket()
        {
            return this.buckets;
        }
        public static int GetHashKey(string str)
        {
			char[] arrC = str.ToCharArray();
			for (int i = 0; i < arrC.Length; i++)
			{
				int numAscii = (int)arrC[i];
				if (numAscii >= 65 && numAscii <= 90)
				{
					// to lower case
					arrC[i] = (char)(numAscii + 32);
				}
				//Console.WriteLine(arrC[i] + " => " + (int)arrC[i]);
			}
			int numToHash = 0;
			for (int i = 0; i < arrC.Length; i++)
			{
				numToHash += (int)arrC[i];
				//Console.WriteLine("num = " + numToHash + ", " + arrC[i]);
			}
			return numToHash;
        }
    }
}
