using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeLoan exp = new HomeLoan();                                      //declares an object for the child class
            double totalExpenses;

            getInput(exp);                                                      //this runs a method that will get the users input and send it to the object class
            totalExpenses = getTotalExpenses(exp);                              //this method will claculate the total expenses 
            displayOutput(totalExpenses, exp);                                  //this method sends the final output and displays it 

            Console.ReadKey();                                                  //holds the console so you can read the output
        }        

        public static void getInput(HomeLoan exp)
        {
            int months;

            Console.Write("Enter the following details regarding your expenses : \n***************************\n\n");
            Console.Write("Enter your gross monthly income : R ");
            exp.Income = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your monthly tax : R ");
            exp.Expenses[0] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your monthly groceries expenses : R ");
            exp.Expenses[1] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your monthly utilities expenses : R ");
            exp.Expenses[2] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your monthly travel expenses: R ");            //these lines get the user input and sends them to the object class to be set
            exp.Expenses[3] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your monthly phone expenses: R ");
            exp.Expenses[4] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your monthly other expenses: R ");
            exp.Expenses[5] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter :\n(1) Renting\n(2) Buying");              // this prompts the user to enter a value based on if they are paying rent or a bond

            switch(Convert.ToInt32(Console.ReadLine()))                         //switch case the output based on what the user entered 
            {
                case 1: exp.Renting = true;
                        Console.Write("Enter the montly rental cost : R ");     //here the user has chosen rent so th system prompts them to enter their monthly rent
                        exp.Monthly = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:                                                         //case 2 is where the user wants a bond and all the details are asked and then sent to the object class to be set 
                        exp.Renting = false;
                        Console.Write("Enter the total value of the property : R ");
                        exp.Purchase = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the deposit paid: R ");
                        exp.Deposit = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the monthly interest rate : ");
                        exp.Rate = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter the total period of months you will be paying the bond off in (between 240 and 360) : ");
                        months = exp.Months = Convert.ToInt32(Console.ReadLine()); ;
                        if ((months > 360) || (months  < 240)) //this will check to make sure the user has enter between 240-360 for their months
                        {
                            Console.WriteLine("Error! Enter a valid number of months (between 240 and 360.)");
                            System.Environment.Exit(0);
                        }
                        else
                        {
                            exp.Months = months;
                        }   
                        
                    break;
                default:    Console.WriteLine("Error! Enter a valid option for rent."); //this default line is if the user inputs anything other than 1 or 2
                            System.Environment.Exit(0);                                 //this will exit the application
                    break;  
            }
        }

        public static double getTotalExpenses(HomeLoan exp)                     //this methods gets the total expenses from the HomeLoan and Expense Class and then minuses that    
        {                                                                       //from the gross income to calculate the final money left over at the end of the month
            double output = 0;
            double expenses = exp.calcExpenses();

            output = exp.Income - expenses;

            return output;
        }

        public static void displayOutput(double total, HomeLoan exp)                          //this method is simply to display the output and a breakdown of the expenses
        {
            double expenses = 0;

            for (int k = 0; k < 6; k++)
            {
                expenses = expenses + exp.Expenses[k];
            }            

            //expenses breakdown

            Console.WriteLine("\n\nExpenses Breakdown : \n***************************");
            Console.WriteLine($"All Expenses : R {expenses}");

            if (exp.Renting)
            {
                Console.WriteLine($"Monthly rent rayment: R {exp.Monthly}");
            }
            else
            {
                Console.WriteLine($"Monthly bond payment : R {exp.Bond}");
            }

            Console.WriteLine($"\n\nThe total amount of money you will have left for the month is : R {total} ");

        }
    }
}
