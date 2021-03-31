using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Simulator
{
    class BankAccount
    {
        //Account Variables, 
        //Account and Pin numbers are strings due to possibility of starting with 0.
        private string accountNum;
        private string pin;
        private float balance;

        //Boolean for preventing user from accessing account if it has been locked.
        private bool valid;

        //Constructor
        public BankAccount(string a, string p, float b)
        {
            //Asigns values to bank account when it is created.
            accountNum = a;
            pin = p;
            balance = b;
            //All accounts are valid when created.
            valid = true; 
        }

        //Compares provided pin with stored pin.
        public Boolean verifyPin(string p)
        {
            if(p == pin) { return true; }
            else { return false; }
        }

        //Locking object
        private Object withdrawLock = new object();

        //Withdraw money from account if ellidgable
        public bool withdrawMoney(float w)
        {
            //Locking solution is turned off.
            if (Program.getLocking())
            {
                //Lock the process so that it cannot be used by other threads
                //until after this one has finished.
                lock (withdrawLock)
                {
                    //Store Balance locally for sake of demonstrating problem.
                    float b = balance;

                    if (Program.getRacing())
                    {
                        //Sleep for 5 seconds to simulate simultaneous access.
                        System.Threading.Thread.Sleep(5000);
                    }

                    //If there is enough money to withdraw, ATM GUI will handle.
                    if (balance >= w)
                    {
                        balance = b - w;
                        return true;
                    }
                    //If there is note nough money to withdraw ATM Gui will handle.
                    else
                    {
                        return false;
                    }                    
                }
            }
            else
            {
                //Store Balance locally for sake of demonstrating problem.
                float b = balance;

                if (Program.getRacing())
                {
                    //Sleep for 5 seconds to simulate simultaneous access.
                    System.Threading.Thread.Sleep(5000);
                }

                //If there is enough money to withdraw, ATM GUI will handle.
                if (balance >= w)
                {
                    balance = b - w;
                    return true;
                }
                //If there is note nough money to withdraw ATM Gui will handle.
                else
                {
                    return false;
                }
            }
        }

        //Getters, setters
        //Gets account number.
        public string getAccountNum()
        {
            return accountNum;
        }

        //Gets pin number.
        public string getPinNum()
        {
            return pin;
        }

        //Gets balance of account.
        public float getBalance()
        {
            return balance;
        }

        //Sets balance of account.
        public void setBalance(float b)
        {
            balance = b;
        }

        //Gets account validity
        public bool getValid()
        {
            return valid;
        }

        //Sets account validity.
        public void setValid()
        {
            valid = !valid;
        }
    }
}
