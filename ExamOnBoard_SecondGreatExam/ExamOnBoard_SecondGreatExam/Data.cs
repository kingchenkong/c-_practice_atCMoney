using System;
namespace ExamOnBoard_SecondGreatExam
{
    public class Data
    {
        public string word;
        public int key;
        public int apearCount;

        public Data(int k, string s)
        {
            key = k;
            word = s;
            apearCount = 1;
        }
    }
}
