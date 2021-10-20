using System;

/*Создать консольное приложение, используя тип кортеж.
2. Треугольники. В сущностях (типах) хранятся треугольники и координаты их точек на плоскости.
Вывести треугольник, площадь которого наиболее приближена к заданной.
Вывести треугольники, сумма площадей которых наиболее приближена
к заданной.
Вывести треугольники, которые помещаются в окружность заданного радиуса.
*/

namespace task_B
{
    class Program
    {
        static void Main(string[] args)
        {
            Realization[] triangles = new Realization[3];//массив будущих экземпляров класса
            double S, S0, S1, S2, sum01, sum02, sum12, R;//переменные для площадей, их сумм и заданого радиуса
            int X, Y;//для координат
            Console.WriteLine("Введите координаты вершин треулгольников: ");
            for(int i = 0; i < 3; i++)//проходим циклом по всем 3м объектам класса и вводим данные
             {
                 triangles[i] = new Realization();//создаем экземпляры класса
                 Console.WriteLine($"\n{i+1}й треугольник!");
                 Console.WriteLine("Вершина А координата X:");
                 int.TryParse(Console.ReadLine(), out X);
                 Console.WriteLine("Вершина А координата Y:");
                 int.TryParse(Console.ReadLine(), out Y);
                 triangles[i].SetA(X, Y);//вызов сеттера

                 Console.WriteLine("Вершина B координата X:");
                 int.TryParse(Console.ReadLine(), out X);
                 Console.WriteLine("Вершина B координата Y:");
                 int.TryParse(Console.ReadLine(), out Y);
                 triangles[i].SetB(X, Y);//вызов сеттера

                 Console.WriteLine("Вершина C координата X:");
                 int.TryParse(Console.ReadLine(), out X);
                 Console.WriteLine("Вершина C координата Y:");
                 int.TryParse(Console.ReadLine(), out Y);
                 triangles[i].SetC(X, Y);//вызов сеттера
             }
            for (int i = 0; i < 3; i++)//через метод класса выводим инфу о треугольнику
            {
                Console.WriteLine($"\n{i + 1}й треугольник!");
                triangles[i].ShowInfo();
            }
            Console.WriteLine("\nВведите произвольную площадь:");
            double.TryParse(Console.ReadLine(), out S);//вводим площадь с клавиатуры

            Console.WriteLine("\nВведите произвольный радиус:");
            double.TryParse(Console.ReadLine(), out R);//вводим радиус с клавиатуры

            S0 = triangles[0].Area();//сохраняем в переменную площадь первого треугольника
            S1 = triangles[1].Area();//сохраняем в переменную площадь второго треугольника
            S2 = triangles[2].Area();//сохраняем в переменную площадь третьего треугольника

            sum01 = S0 + S1;//сумма площадей первого и второго
            sum02 = S0 + S2;//сумма площадей первого и третьего
            sum12 = S1 + S2;//сумма площадей второго и третьего
            //дальше у нас идут проверки условий
            //где мы проверяем наиболее приближенный треугольник по площади к заданной
            //делаем это с помощью разности нашей площади и заданной
            //если разница минимальная - значит наша площадь ближе всех на числовой прямой к заданной
            if (Math.Abs((S0 - S)) <= Math.Abs((S1 - S)) && Math.Abs((S0 - S)) <= Math.Abs((S2 - S))) 
                Console.WriteLine($"\nПлощадь первого треугольника = {S0} у.е. наиболее приближена к заданой {S} у.е!");
            else if (Math.Abs((S1 - S)) <= Math.Abs((S0 - S)) && Math.Abs((S1 - S)) <= Math.Abs((S2 - S))) 
                Console.WriteLine($"\nПлощадь второго треугольника = {S1} у.е. наиболее приближена к заданой {S} у.е!");
            else 
                Console.WriteLine($"\nПлощадь третьего треугольника = {S2} у.е. наиболее приближена к заданой {S} у.е!");

            //тот же самый алгоритм, но теперь с суммой площадей
            if (Math.Abs((sum01 - S)) < Math.Abs((sum02 - S)) && Math.Abs((sum01 - S)) < Math.Abs((sum12 - S))) 
                Console.WriteLine($"\nСумма площадей первого и второго треугольников = {sum01} у.е. наиболее приближена к заданой {S} у.е!");
            else if (Math.Abs((sum02 - S)) < Math.Abs((sum01 - S)) && Math.Abs((sum02 - S)) < Math.Abs((sum12 - S))) 
                Console.WriteLine($"\nСумма площадей первого и третьего треугольников = {sum02} у.е. наиболее приближена к заданой {S} у.е!");
            else 
                Console.WriteLine($"\nСумма площадей второго и третьего треугольников = {sum12} у.е. наиболее приближена к заданой {S} у.е!");

            //проверяем условием можно ли вписать наш треугольник в окружность радиуса R
            if (R >= triangles[0].Radius()) 
                Console.WriteLine($"\nПервый треугольник с рaдиусом = {triangles[0].Radius()} у.е. может быть вписан в окружность c радиусом = {R} у.е!");
            if (R >= triangles[1].Radius()) 
                Console.WriteLine($"\nВторой треугольник с радиусом = {triangles[1].Radius()} у.е. может быть вписан в окружность c радиусом = {R} у.е!");
            if (R >= triangles[2].Radius()) 
                Console.WriteLine($"\nТретий треугольник с радиусом = {triangles[2].Radius()} у.е. может быть вписан в окружность c радиусом = {R} у.е!");
            //если не удалось вписать ни один из треугольников, выводим об этом сообщение
            if (triangles[0].Radius() > R && triangles[1].Radius() > R && triangles[2].Radius() > R)
                Console.WriteLine($"\nНи какой из треугольников не может быть вписан в окружность заданого радиуса = {R} у.е!");
        }
    }
}
