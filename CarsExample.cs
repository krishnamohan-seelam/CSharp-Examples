using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Simple  Example to demonstrate  IComparable,Action delegate.
 */ 
namespace LearningCS
{
    class CarsExample
    {
       
        static void Main(string[] args)
        {
            Action<Car[]> actionPrint = new Action<Car[]>(PrintCars);
            Car[] cars =
            {
                new Car() { Name="SSC Ultimate Aero", MaxMph=257, Horsepower=1183, Price=654400m},
                new Car() { Name="Bugatti Veyron", MaxMph=253, Horsepower=1001, Price=1700000m},
                new Car() { Name="Saleen S7 Twin-Turbo", MaxMph=248, Horsepower=750, Price=555000m},
                new Car() { Name="Koenigsegg CCX", MaxMph=245, Horsepower=806, Price=545568m},
                new Car() { Name="McLaren F1", MaxMph=240, Horsepower=637, Price=970000m},
                new Car() { Name="Ferrari Enzo", MaxMph=217, Horsepower=660, Price=670000m},
                new Car() { Name="Jaguar XJ220", MaxMph=217, Horsepower=542, Price=650000m},
                new Car() { Name="Pagani Zonda F", MaxMph=215, Horsepower=650, Price=667321m},
                new Car() { Name="Lamborghini Murcielago LP640", MaxMph=211, Horsepower=640, Price=430000m},
                new Car() { Name="Porsche Carrera GT", MaxMph=205, Horsepower=612, Price=440000m},
            };

            actionPrint(cars);
            Array.Sort(cars);
            Console.WriteLine("Sorted Cars by Name....\n");
            actionPrint(cars);
            Console.ReadKey();

        }

        private static void PrintCars(Car[] cars)
        {
            Console.WriteLine("{0,-50}|{1,-10}|{2,-10}|{3,-10}","Name","MaxMph","HorsePower","Price");
            foreach(Car car in cars)
            {
                Console.WriteLine("{0,-50}|{1,-10}|{2,-10}|{3,-10}", car.Name, car.MaxMph, car.Horsepower, car.Price);
            }

        }

    }
}
