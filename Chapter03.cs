using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


 // example to demonstrate various operators in C# ?,??,typeof ,is ,as
/*
 *  int? a;     --- Nullable type declaration
 *  a ?? default--- Null-coalescing(??)   returns  left hand  operand  if it's not null else returns right hand operand.
 *  is          --- equivalent of instanceof operator in java 
 *  as          --- as operator performs only reference conversions, nullable conversions and boxing conversions.
 *                  The as operator can't perform other conversions, such as user-defined conversions (int to double )
 */
namespace LearningCS
{
    class Chapter03
    {

        static int? GetNullInt()
        {
            return null;
        }

        static String GetString()
        {
            return null;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("This Main method is invoked from {0} " ,MethodBase.GetCurrentMethod().DeclaringType);
            int? a = null;// when your using nullable types always check HasValue before using it in computations

            int b = a ?? -1;
            Console.WriteLine("Examples on Nullable types and Nullable operator ... ");
            Console.WriteLine("value of b {0}" ,b);
            int c = GetNullInt() ?? default(int);
            Console.WriteLine("value of c {0}",c);

            String d = GetString();
            Console.WriteLine("String value is {0}", d ?? "Null");

            System.Type type = typeof(int);
            Console.WriteLine("Type of {0}", type);

            int sumValue = 10 +  (a.HasValue ? a.Value : default(int));
            Console.WriteLine("Sum of value ={0}", sumValue);

            Console.WriteLine("Example base and derived:");

            Parent baseRef = new Parent();
            baseRef.printFunc();

            Child derRef = new Child();
            derRef.printFunc();

            Console.WriteLine("Example base and derived using as : ");

            Parent newRef = derRef as Parent;
            Console.WriteLine("Type of newRef is {0}", newRef.GetType());
            newRef.printFunc();
            

            Console.WriteLine("Press any key to exit ....");
            Console.ReadKey();
        }


    }

    class Parent
    {
        public Parent()
        {
        }

        public void Inherit()
        {
            Console.WriteLine("from  Parent Inherit()");
        }
        public virtual void printFunc()
        {
            Console.WriteLine("Called From {0} , {1} method", MethodBase.GetCurrentMethod().DeclaringType ,MethodBase.GetCurrentMethod().Name);
        }

    }

    class Child : Parent
    {

        public Child()
        {
        }

        /* 
        * only methods declared as virtual/abstract/override can be overriden
          public override  void Inherit()
            {
            Console.WriteLine("from  Parent Inherit()");
             }
        
         */
        public override sealed void printFunc()
        {
            
            Console.WriteLine("Called From {0} , {1} method", MethodBase.GetCurrentMethod().DeclaringType ,MethodBase.GetCurrentMethod().Name);
        }

       
    }


    class GrandChild : Child
    {
        public GrandChild()
        {

        }

        /*
         * sealed methods cannot be overriden
         public override void printFunc()
        {

        }*/


    }


}
