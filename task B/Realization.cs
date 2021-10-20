using System;

namespace task_B
{
    class Realization
    {
        (int X, int Y) PointA;//создаем кортежи для точек треугольника A
        (int X, int Y) PointB;//B
        (int X, int Y) PointC;//C
        public void SetA(int x, int y) => PointA = (x, y); //сеттеры для точек A
        public void SetB(int x, int y) => PointB = (x, y);//B
        public void SetC(int x, int y) => PointC = (x, y);//C
        public double Area()//метод вычисления площади треугольника по координатам
        {
            double value = 0;//переменная площади
            value = (((PointA.X - PointC.X) * (PointB.Y - PointC.Y)) - ((PointB.X - PointC.X) * (PointA.Y - PointC.Y))) / Convert.ToDouble(2);//нашел страшную формулу в интернете
            return Math.Abs(value);//возвращаем абсолютное значение
        }
        double Side((int X, int Y) Point1, (int X, int Y) Point2)//метод который считает длинну стороны треугольника
        {
            double value = 0;
            value = Math.Sqrt(Math.Pow((Point2.X - Point1.X), 2) + Math.Pow((Point2.Y - Point1.Y), 2));//находим длинну отрезка по координатам
            return value;
        }
        public double Radius()//метод нахождения радиуса описанной окружности
        {
            double value = 0;
            value = (Side(PointA, PointB) * Side(PointB, PointC) * Side(PointC, PointA)) / (4 * Area());//нашел в инете формулу abc/4S
            return Math.Round(value,2);
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Треугольник с точками А({PointA.X};{PointA.Y}), B({PointB.X};{PointB.Y}), C({PointC.X};{PointC.Y})." +
                $"\nПлощадь равна {Area()} (у.е)^2.\nРадиус, описанной окружности, равен {Radius()} у.е.");
        }
    }
}
