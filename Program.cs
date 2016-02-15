using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace Chapter12
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime currentDate = DateTime.Now;
            /*Print_To_Console(currentDate.ToString());
            Print_To_Console(currentDate.ToShortDateString());

            int month = currentDate.Month;
            Print_To_Console(String.Format("Current Month:{0}" ,month.ToString().PadLeft(2,'0')));
            month = currentDate.AddMonths(-4).Month;
            Print_To_Console(String.Format("Current Month {0} = {1}", -4, month.ToString().PadLeft(2,'0')));
             */

            Print_To_Console("Enter Date of Birth(\"MM/dd/YYYY\")");
            String dateOfBirthStr = Console.ReadLine();

            DateTime dobDate = GetDate(dateOfBirthStr);
           
            // if hashcode ==0 then is default date which is  not valid date 
            if (dobDate.GetHashCode() != 0)
            {
                Print_To_Console(String.Format("Entered Date of Birth(locale format): {0}", dobDate.ToShortDateString()));
                Print_To_Console(String.Format("Today's Date (locale format): {0}", DateTime.Now.ToShortDateString()));

                bool val = Validate_Date(dobDate);
                if (val)
                {
                    System.TimeSpan ageSpan = DateTime.Now - dobDate;
                    DateTime Age = DateTime.MinValue + ageSpan;
                    int Years = Age.Year - 1;
                    int Months = Age.Month - 1;

                    if (Years != 0)
                    {
                        Print_To_Console(String.Format("Age in years {0} ", Years.ToString()));
                    }
                    else
                    {
                        Print_To_Console(String.Format("Age in Months {0} ", Months.ToString()));
                    }
                }
                else
                {
                    Print_To_Console("Entered Date is today's date or future date");
                }

            }
            else
            {
                Print_To_Console(String.Format("Entered date {0} is invalid", dateOfBirthStr));
            }



            Print_To_Console("Press any key to exit....");
            Console.ReadKey();
        }


        private static bool Validate_Date(DateTime date)
        {

            int compValue = date.CompareTo(DateTime.Now);
            // Print_To_Console(compValue.ToString());
            return (compValue < 0) ? true : false;
        }

        private static DateTime GetDate(string dateOfBirth)
        {
            DateTime date;

            if (DateTime.TryParseExact(dateOfBirth, "MM/dd/yyyy", null, DateTimeStyles.None, out date))
            {
                Print_To_Console("Entered valid date, proceeding to age calculation");


            }
            else
            {
                Print_To_Console("Entered invalid date");
            }
            return date;
        }

        private static void Print_To_Console(String value)
        {
            Console.WriteLine(value);
        }

    }
}
