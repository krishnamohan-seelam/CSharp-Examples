using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * declarations:
 *              int[] numbers;
 *              string[,] names;                - Multidimensional 
 *              int[,] myMatrix= new int[3,4]; - rectangular array [each row is of the same length.] 
 *              int[][] myJagArray = new int[5][];-arrays contain some number of inner arrays, each of which may have a different upper limit.
 *  enums
 *  structs :
 *             define properties for structs 
 *             struct constructors - Constructor chaining,
 *                                   Single constructor using optional args
 */


namespace LearningCS
{

     struct Point {

         private int _X, _Y;

         public int X
         {
             get { return _X; }
              private set { _X = value; }
         }

         public int Y
         {
             get { return _Y; }
             private set { _Y = value; }
         }

         /* structs cannnot explicitly contain parameterless constructor
         public Point()
             : this(0, 0)
         {

         }
         */
         

         public Point(int X=0, int Y=0)
         {
             this._X = X;
             this._Y = Y;
         }

         public void  displayPoint()
         {
             Console.WriteLine("value of x co-ordinate:{0}", this.X);
             Console.WriteLine("value of y co-ordinate:{0}", this.Y);
         }

     }

    class Chapter04
    {


        [Flags]
        enum shape {  circle=0,rectangle,square }
        //constant declaration
        const double PI = 3.14D;
        static void Main(string[] args)
        {
             
             //aboutArrays();
             aboutEnums();
            // aboutStructs();
             //aboutStatic();
           

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();



        }

        private static void aboutStatic()
        {
            Console.WriteLine("InterestRate" + SavingAccount.interestRate);
        }

        private static void aboutStructs()
        {
            Console.WriteLine("Enter the co-ordinates of point");
            Point newPoint = new Point(5, 6);
            Point defaultPoint = new Point();
            newPoint.displayPoint();
            //newPoint.X = 10;
            //newPoint.Y = 15;
            newPoint.displayPoint();
            defaultPoint.displayPoint();
        }

        private static void aboutEnums()
        {
            Console.WriteLine("Enter shape type you want to calculate the area");
            Console.WriteLine("Please choose [circle/rectangle/square]");
            String input = Console.ReadLine();
            shape shapeType = (shape)Enum.Parse(typeof(shape), input);

            double area = 0F;
            double length, breadth;
            string inpLength;
            

            switch (shapeType)
            {

                case shape.rectangle: Console.WriteLine("Enter the length & breadth");
                    Console.WriteLine("Enter Length:");
                    inpLength = Console.ReadLine();
                    if (!Double.TryParse(inpLength, out length))
                    { length = 0F; }

                    Console.WriteLine("Enter breadth:");
                    string inpBreadth = Console.ReadLine();

                    if (!Double.TryParse(inpBreadth, out breadth))
                        breadth = 0F;

                    area = getArea(length, breadth);

                    break;

                case shape.square: Console.WriteLine("Enter side for Square:");
                    inpLength = Console.ReadLine();
                    if (!Double.TryParse(inpLength, out length))
                        length = 0F;
                    area = getArea(length, length);
                    break;
                case shape.circle: Console.WriteLine("Enter raidus  for Circle:");
                    inpLength = Console.ReadLine();
                    if (!Double.TryParse(inpLength, out length))
                        length = 0F;
                    area = getArea(length);

                    break;
            }

            Console.WriteLine("Area of {0} is {1}", shapeType.ToString(), area);

            Console.WriteLine("=> Information about {0}", shapeType.GetType().Name);
            Console.WriteLine("Underlying storage type: {0}", Enum.GetUnderlyingType(shapeType.GetType()));

            Array enumData = Enum.GetValues(shapeType.GetType());
            Console.WriteLine("This enum has {0} members.", enumData.Length);
        }

        private static void aboutArrays()
        {
            int[] arrayOfInt = { 100, 400, 200, 2040, 435, 9042, 903, 3232 };
            Console.WriteLine("=====Chapter04-System.base.Array=======");
            Array.Sort(arrayOfInt);
            Console.WriteLine("IsFixedSize:{0}", arrayOfInt.IsFixedSize.ToString());
            Console.WriteLine("Rank[No of Dimensions]:{0}", arrayOfInt.Rank);


            for (int iter = 0; iter < arrayOfInt.Length; iter++)
            {
                Console.WriteLine("element at {0} : {1}", iter, arrayOfInt[iter]);
            }
        }

        private static double getArea(double length)
        {
            return PI * getArea(length, length);
        }

        private static double getArea(double length, double breadth)
        {
            return length * breadth;
        }

        


    }

    class SavingAccount
    {
        public double currBalance;
        public static double interestRate =0.4;

        // static constructor  variable assignment would override declaration assigment
        static SavingAccount()
        {
            interestRate = 0.6;
        }
        public SavingAccount()
        {
            currBalance = 0;
            

        }
        


    }

}
