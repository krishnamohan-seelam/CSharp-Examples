using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCS
{
    class Car :IComparable<Car>
    {
        public string Name { get; set; }
        public int MaxMph { get; set; }
        public int Horsepower { get; set; }
        public decimal Price { get; set; }



        public int CompareTo(Car other)
        {
            return  this.Name.CompareTo(other.Name);
        }
    }
}
