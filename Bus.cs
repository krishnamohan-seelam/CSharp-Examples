using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
    class Bus
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } 

        public string PetName { get; set; }

         // Is the bus alive or dead?
        private bool isBusDead;

        public delegate void BusEngineHandler(string msg);

        public event BusEngineHandler Exploded;
        public event BusEngineHandler AboutToBlow;
        public event BusEngineHandler Repair;
        // Class constructors.
         public Bus() {}
        public Bus(string name, int maxSp=100, int currSp=0)
            {
              CurrentSpeed = currSp;
                 MaxSpeed = maxSp;
                 PetName = name;
             }

        public void repairEngine()
        {
            if (isBusDead)
            {
                isBusDead = false;
                CurrentSpeed = 10;
                if (Repair != null) Repair("Engine repair complete");
            }
        }

        public void Accelerate(int delta)
        {
            if (isBusDead)
            {
                if (Exploded != null) Exploded("Bus has Exploded");
            }
            else 
            {
                CurrentSpeed += delta;
                 if (10 == MaxSpeed - CurrentSpeed  && AboutToBlow!=null)
                 {
                     AboutToBlow("Slow down ,Engine is going to explode");

                 }
                if (CurrentSpeed >= MaxSpeed)
                    isBusDead = true;
                 else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }

        }

    }
}
