using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Circle
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Первая часть - принимаем исходные данные
                Console.WriteLine("В данной задачи определяем длину, площадь круга и находится ли точка внутри круга с заданными координатами.");

                Console.WriteLine("Введите значение радиуса окружности");
                double radiusCircle = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите значение x0 центра окружности");
                double x0Circle = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите значение y0 центра окружности");
                double y0Circle = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите значение x проверяемой точки");
                double xPoint = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите значение y проверяемой точки");
                double yPoint = Convert.ToDouble(Console.ReadLine());

               
                // Выдаём результат
                double lengthCircle = Circle.Length(radiusCircle);
                Console.WriteLine("Длина окружности {0:f2}.", lengthCircle);
                double areaCircle = Circle.Area(radiusCircle);
                Console.WriteLine("Площадь круга {0:f2}.", areaCircle);
                bool pointContains = Circle.PointContains(radiusCircle,x0Circle,y0Circle,xPoint,yPoint) ;

                if (pointContains)
                {
                    Console.WriteLine("Точка внутри круга или на его окружности.", pointContains);
                }
                else
                {
                    Console.WriteLine("Точка снаружи круга.", pointContains);
                }
                Console.WriteLine("Нажмите любую кнопку для выхода из программы.");

            }
            
            catch (ArgumentOutOfRangeException)
            {                
                Console.WriteLine("Придётся закрыть программу. Нажмите любую кнопку.");
            }
            catch (Exception except)
            {
                Console.WriteLine(except.Message);
                Console.WriteLine("Кажется, придётся закрыть программу. Нажмите любую кнопку.");
            }
;
            Console.ReadKey();
        }
    }

    public static class Circle
    {
        private static double radius;

        public static double Radius
        {
            set
            {
                if (value >= 0)
                {
                    radius = value;
                }
                else
                {
                    Console.WriteLine("Значение радиуса не может быть отрицательным.");
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return radius;
            }
        }

        public static double Length(double r)
        {
            Radius = r;
            double length = 2 * Math.PI * radius;
            return length;
        }
        public static double Area(double r)
        {
            Radius = r;
            double area = Math.PI * radius * radius;
            return area;
        }
        public static bool PointContains(double r, double x0, double y0, double x, double y)
        {
            Radius = r;
            bool contains = false;
            double yDifferent = Math.Max(x0, x) - Math.Min(x0, x);
            double xDifferent = Math.Max(y0, y) - Math.Min(y0, y);
            double distance = Math.Sqrt((xDifferent * xDifferent + yDifferent * yDifferent));
            if (radius >= distance)
            {
                contains = true;
            }
            return contains;
        }


    }
}
