using System;
using System.Security;

namespace net_hw2
{
    //编写面向对象程序实现长方形、正方形、三角形等形状的类。每个形状类都能计算面积、判断形状是否合法。 请尝试合理使用接口/抽象类、属性来实现。
    abstract class Shape
    {
        public double w;
        public double h;
        public abstract double Area();

        public Shape(double w,double h)
        {
            this.w = w;
            this.h = h;
        }
    }



    class Rectangle : Shape
    {
        public Rectangle(double w,double h):base(w,h)
        {
        }
        public void verification()
        {
            if(w > 0 && h > 0) Console.WriteLine("是长方形");
            else Console.WriteLine("不符合");

        }
        public override double Area()
        {
            Console.WriteLine(w * h);
            return w * h;
        }


    }
    class Square : Shape
    {
        public Square(double w, double h) : base(w, h)
        {
        }
        public void verification()
        {
            if (w > 0 && h > 0 && w == h) Console.WriteLine("是长方形");
            else Console.WriteLine("不符合");
        }
        public override double Area()
        {
            Console.WriteLine(w * h);
            return w * h;
        }
    }
    class Triangle : Shape
    {
        public Triangle(double w, double h) : base(w, h)
        {

        }
        public void verification()
        {
            if (w > 0 && h > 0) Console.WriteLine("是长方形");
            else Console.WriteLine("不符合");
        }

        public override double Area()
        {
            Console.WriteLine(w * h / 2);
            return w * h / 2;
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(-5, 6);
            r.verification();
            r.Area();


        }
    }
}
