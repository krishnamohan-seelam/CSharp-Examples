using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCS
{
   
    class LearningCSMain
    {
        static int idCounter = 0;
       
        static void Main(string[] args)
        {
             

            Employee empRef = new Employee(++idCounter, "KrishnaMohan", "Seelam", 33, 10.48f);
            Manager mgrRef = new Manager(++idCounter,"GeethaSahasra","Seelam", 2,17.2f,20);

            //Delegate  variable referencing to DisplayEmployee() method
            empRef.dispDel = new Employee.displayDelegate(empRef.DisplayEmployee);

            empRef.dispDel();
            //or empRef.dispDel.Invoke();

            //Manager class inheriting Delegate variable declared in Employee
            mgrRef.dispDel = new Manager.displayDelegate(mgrRef.DisplayEmployee);
            mgrRef.dispDel();

           
            Console.ReadKey();

        }
    }
}
