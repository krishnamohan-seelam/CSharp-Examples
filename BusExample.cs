using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
    class BusExample
    {
        static void Main(string[] args)
        {
            Bus myBus = new Bus("Volvo", 120, 10);
            myBus.AboutToBlow += new Bus.BusEngineHandler( BusAboutToBlow);
            myBus.AboutToBlow += new Bus.BusEngineHandler(BusIsAlmostDoomed);


            Bus.BusEngineHandler explodeEventHldr = new Bus.BusEngineHandler(BusExploded);
            myBus.Exploded += explodeEventHldr;

            Bus.BusEngineHandler repairEventHldr = new Bus.BusEngineHandler(RepairBus);
            myBus.Repair += repairEventHldr;

            Console.WriteLine("***** accelerate up *****");
            for (int i = 0; i < 6; i++)
                myBus.Accelerate(20);

           

            myBus.Accelerate(20);
            //myBus.Exploded -= explode;
           
            myBus.repairEngine();

            Console.WriteLine("press any  key to continue");
            
            Console.ReadKey();
          


            for (int i = 0; i < 6; i++)
                myBus.Accelerate(20);

            Console.ReadKey();
        }

        public static void BusAboutToBlow(string msg)
        { Console.WriteLine(msg); }

        public static void BusIsAlmostDoomed(string msg)
        { Console.WriteLine("=> Critical Message from Bus: {0}", msg); }

        public static void BusExploded(string msg)
        { Console.WriteLine(msg); }

        public static void RepairBus(string msg)
        { Console.WriteLine(msg); }

    }
}
