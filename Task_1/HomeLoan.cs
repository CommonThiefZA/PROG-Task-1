using System;
namespace Task_1
{
    class HomeLoan : Expense                                                    //the HomeLoan class is an abstract class of the Expense class
    {
        private bool renting;
        private int monthlyRent;
        private int purchasePrice;
        private int deposit;                                                    //sets variables for bothing renting and bond options
        private double interestRate;
        private int months;
        private double bond;

        public HomeLoan() : base()                                              //default operator with the base 
        {
            renting = false;
            monthlyRent = 0;
            purchasePrice = 0;
            deposit = 0;
            interestRate = 0.0;
            months = 0;
            bond = 0;
        }

        public HomeLoan(int income, int[] expenses, bool renting, int rent, int purchase, int deposit, double rate, int months) : base(income, expenses)
        {                                                                       //overloaded operator with the variables from the parent class aswell
            this.renting = renting;
            monthlyRent = rent;
            purchasePrice = purchase;
            this.deposit = deposit;
            interestRate = rate;
            this.months = months;
        }

        public bool Renting                                                     //getter and setter methods for the variables of this class
        {
            set { renting = value; }
            get { return renting; }
        }

        public int Monthly
        {
            set { monthlyRent = value; }
            get { return monthlyRent; }
        }

        public int Purchase
        {
            set { purchasePrice = value; }
            get { return purchasePrice; }
        }

        public int Deposit
        {
            set { deposit = value; }
            get { return deposit; }
        }

        public double Rate
        {
            set { interestRate = value; }
            get { return interestRate; }
        }

        public int Months
        {
            set { months = value; }
            get { return months; }
        }

        public double Bond
        {
            get { return bond; }
        }

        public double calcExpenses()                                            //this method will add up all the expenses together and will also calculate the bond monthly payment if necessary
        {
            double total = 0;
            bool validBond = false;

            for (int k = 0; k < 6; k++)                                         //for loop to run through the Expenses array to add up all the expenses
            {
                total = total + Expenses[k];
            }

            if (Renting)                            
            {
                total = total + Monthly;                                        //if the user is simply renting then the monthly payment is simply added to the 
            }
            else                                                                //if the user has chosen bond then the bond will be calculated via simple interest based on the values that they inputted 
            {
                bond = (((Purchase - Deposit) * (1 + ((Rate / 100) * (Months / 12)))) / Months);
                validBond = checkBond(bond);                                    //this method checks to see if the bond will be valid
                if (validBond)                                                  //if the bond is valid
                {
                    total = total + bond;
                }
                else                                                            //if the bond is invalid then it will display an error message and exit the program
                {
                    Console.WriteLine($"This property is too expensive as it exceeds 1/3 of your gross monthly income in payments ({bond}). Try again");
                    System.Environment.Exit(0);
                }
            }

            return total;                                                       //returns the total expenses 
        }

        public bool checkBond(double bond)                                      //this methods checks to see if the bond is valid by 
        {                                                                       //making sure the monthly payments will not exceed 1/3 of the users gross income amount 
            bool output = false;                                                //sets the bond to false originally so no need to ad an else statement as if the bond isn't valid
                                                                                //it will skip the if statement and the output will stay false
            if (bond < (Income / 3))
            {
                output = true;
            }
            return output;
        }
    }
}
