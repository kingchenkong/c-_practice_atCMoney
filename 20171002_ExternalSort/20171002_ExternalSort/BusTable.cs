using System;
namespace _ExternalSort
{
    public class BusTable
    {
        public string data;
        public int offTime;
        public BusTable(string d)
        {
            this.data = d;
            if (d.Length > 8)
                this.SetOffTime();
        }
        public void SetOffTime()
        {
            string[] arr = this.data.Split(',');
            this.offTime = Int32.Parse(arr[7]);
        }
    }
}
