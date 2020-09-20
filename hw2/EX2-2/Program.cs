using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace net_hw2
{
    //随机创建10个形状对象，计算这些对象的面积之和。 尝试使用简单工厂设计模式来创建对象。
    class EX2
    {
        abstract class Shape
        {
            public double w;
            public double h;
            public abstract double Area();

            public Shape(double w, double h)
            {
                this.w = w;
                this.h = h;
            }
        }

        class ShapeFactory//简单工厂
        {
            public Shape CreateShape(int shapeID, double w, double h)
            {
                Shape shape = null;
                //按ID形成不同的形状
                if (shapeID == 1)
                {
                    shape = new Rectangle(w, h);
                }
                else if (shapeID == 2)
                {
                    shape = new Square(w, h);
                }
                else if (shapeID == 3)
                {
                    shape = new Triangle(w, h);
                }
                return shape;
            }
        }


        class Rectangle : Shape
        {
            public Rectangle(double w, double h) : base(w, h)
            {
            }

            public override double Area()
            {
                Console.Write("随机一个长方形体积为：");
                Console.WriteLine(w * h);
                return w * h;
            }


        }
        class Square : Shape
        {
            public Square(double w, double h) : base(w, h)
            {
            }

            public override double Area()
            {
                Console.Write("随机一个正方形体积为：");
                Console.WriteLine(w * h);
                return w * h;
            }
        }
        class Triangle : Shape
        {
            public Triangle(double w, double h) : base(w, h)
            {

            }

            public override double Area()
            {
                Console.Write("随机一个三角形体积为：");
                Console.WriteLine(w * h / 2);
                return w * h / 2;
            }
        }
        class Test
        {
            static void Main(string[] args)
            {
                Console.WriteLine("随机创建10个形状对象：\n");
                ShapeFactory shapeFactory = new ShapeFactory();
                List<Shape> list_shape = new List<Shape>();
                //随机产生10个形状
                for(int i = 1; i <= 10; i++)
                {
                    Random random = new Random();
                    int randomW = random.Next(1, 10);
                    int randomH = random.Next(1, 10);
                    int ID = random.Next(1, 4);
                    list_shape.Add(shapeFactory.CreateShape(ID, randomW, randomH));
                }
                double sum = 0;
                foreach (var item in list_shape)
                {
                    sum += item.Area();
                }
                Console.WriteLine("\n面积之和为：" + sum);
                
            }
        }
    }
}
