using System;
namespace Task_1
{
    class Expense  
    {
        private int income;
        private int[] expenses = new int[6];                                    //stores the expenses in an array and the income in an int variable

        public Expense()                                                        //default operator
        {
            income = 0;

            for (int k = 0; k < 6; k++)
            {
                expenses[k] = 0;
            }
        }

        public Expense(int income, int[] expenses)                              //overloaded operator
        {
            this.income = income;
            this.expenses = expenses;
        }

        public int Income                                                       //next part is the getter and setter methods for the two variables in this class
        {
            set { income = value; }
            get { return income; }
        }

        public int[] Expenses
        {
            set { expenses = value; }
            get { return expenses; }
        }        
    }
}
