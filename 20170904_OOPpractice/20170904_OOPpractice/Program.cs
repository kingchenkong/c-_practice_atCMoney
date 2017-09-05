using System;

namespace _OOPpractice
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			CRect sh1 = new CRect(5.0, 15.0);
			CCircle sh2 = new CCircle(3.0);

			CShape[] arrShape = new CShape[4]; // 抽象型態的變數陣列
			arrShape[0] = new CRect(10.0, 20.0); // 變數參考子類別物件實體 
			arrShape[1] = new CRect(5.0, 15.0);
			arrShape[2] = new CCircle(3.0);
			arrShape[3] = new CCircle(6.0);

            for (int i = 0; i < arrShape.Length; i++)
			{
				arrShape[i].computeArea();
				arrShape[i].computePerimeter();
			}
            Console.WriteLine("###------Original------###");
			CShape.show(arrShape);
			Console.WriteLine("###------sort By Area------###");
			CShape.sortByArea(arrShape);
			CShape.show(arrShape);
			Console.WriteLine("###------sort By Perimeter------###");
			CShape.sortByPerimeter(arrShape);
			CShape.show(arrShape);
        }
    }
    abstract class CShape
    {
        protected double area;
        protected double perimeter;

        public static void show(CShape[] arrSh)
        {
            for (int i = 0; i < arrSh.Length; i++)
            {
                Console.WriteLine("----- " + arrSh.GetType().Name + " [" + i + "] -----");
                Console.WriteLine("class : {0} \n -Area : {1}\n -Perimeter : {2}\n", arrSh[i].GetType().Name, arrSh[i].area, arrSh[i].perimeter);
            }
        }
        public static void sortByArea(CShape[] arrSh)
        {
            for (int i = 0; i < arrSh.Length - 1; i++)
            {
                for (int j = 0; j < arrSh.Length - i - 1; j++)
                {
                    if (arrSh[j].area > arrSh[j + 1].area)
                    {
                        CShape temp = arrSh[j + 1];
                        arrSh[j + 1] = arrSh[j];
                        arrSh[j] = temp;
                    }
                }
            }
        }
        public static void sortByPerimeter(CShape[] arrSh)
        {
            for (int i = 0; i < arrSh.Length - 1; i++)
            {
                for (int j = 0; j < arrSh.Length - i - 1; j++)
                {
                    if (arrSh[j].perimeter > arrSh[j + 1].perimeter)
                    {
                        CShape temp = arrSh[j + 1];
                        arrSh[j + 1] = arrSh[j];
                        arrSh[j] = temp;
                    }
                }
            }
        }
        public abstract void computeArea();
        public abstract double getArea();
        public abstract void computePerimeter();
        public abstract double getPerimeter();
    }
    class CRect : CShape
    {


        protected double length;
        protected double width;

        public CRect(double l, double w)
        {
            this.length = l;
            this.width = w;
        }
        public void show()
        {
            Console.WriteLine("CRect :\n -length: {0}\n -width : {1}\n -Area : {2}\n -Perimeter : {3}\n", this.length, this.width, this.area, this.perimeter);
        }
        override public void computeArea()
        {
            this.area = this.length * this.width;
        }
        override public double getArea()
        {
            return this.area;
        }
        override public void computePerimeter()
        {
            this.perimeter = (this.length + this.width) * 2;
        }
        override public double getPerimeter()
        {
            return this.perimeter;
        }
    }
    class CCircle : CShape
    {


        protected double radius;

        public CCircle(double r)
        {
            this.radius = r;
        }
        public void show()
        {
            Console.WriteLine("CRect :\n -radius: {0}\n -Area : {1}\n -Perimeter : {2}\n", this.radius, this.area, this.perimeter);
        }
        override public void computeArea()
        {
            this.area = this.radius * this.radius * Math.PI;
        }
        override public double getArea()
        {
            return this.area;
        }
        override public void computePerimeter()
        {
            this.perimeter = 2 * this.radius * Math.PI;
        }
        override public double getPerimeter()
        {
            return this.perimeter;
        }
    }
}
