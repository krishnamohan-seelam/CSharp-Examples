using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * The below class is base class for Employee and Sales Person.To illustrate various concepts like 
 * constructors,properties,base virtual methods,delegates
 * 
 */

namespace LearningCS
{
    class Employee
    {
        private String empFName;
        private String empLName;
        private int empID;
        private int empAge;
        private float empPay;

        internal delegate void displayDelegate();
        internal displayDelegate dispDel;


        public Employee()
        {
        }
        public Employee(int id, String firstName, String lastName, int age, float pay)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.pay = pay;
        }

        


        public int id
        {
            get { return empID; }
            set { empID = value; }
        }

        public String firstName
        {

            get { return empFName; }
            set
            {
                if (value.Length > 20)
                    Console.WriteLine("Error ! First Name exceeds 20 characters");
                else
                empFName = value;
            }

        }
        public String lastName
        {

            get { return empLName; }
            set
            {
                if (value.Length > 20)
                    Console.WriteLine("Error ! Last Name exceeds 20 characters");
                else
                empLName = value;
            }

        }

        public int age
        {
            get { return empAge; }
            set { empAge = value; }
        }

        public float pay
        {
            get { return empPay; }
            set { empPay = value; }
        }

       internal virtual void DisplayEmployee()
        {
             Console.WriteLine("Employee Name {0}",firstName+" "+lastName);
             Console.WriteLine("ID: {0}", id);
             Console.WriteLine("Age: {0}", age);
             Console.WriteLine("Pay: {0}", pay);

        }

        public virtual void GiveBonus(float bonusAmount)
        {
            empPay += bonusAmount;
        }



       
    }
}
