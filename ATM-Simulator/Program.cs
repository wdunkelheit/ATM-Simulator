using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Simulator
{
    static class Program
    {
        //Keep track of how many ATMs are active.
        private static int activeATMs = 0;

        //Bank account array.
        public static BankAccount[] accounts = new BankAccount[3];

        //Initialise bank accounts.
        private static void initAccounts()
        {
            accounts[0] = new BankAccount("111111", "1111", 300);
            accounts[1] = new BankAccount("222222", "2222", 750);
            accounts[2] = new BankAccount("333333", "3333", 3000);
        }

        //Boolean for controlling if Data Race is enabled. Enabled by default.
        public static bool racing = true;
        //Boolean for controlling if Locking is enabled. Disabled by default.
        public static bool locking = false;

        
        //Getter
        //Gets racing bool
        public static bool getRacing()
        {
            return racing;
        }
        //Gets locking bool
        public static bool getLocking()
        {
            return locking;
        }

        //Toggle for Racing
        public static void enableRace()
        {
            racing = !racing;
        }
        //Toggle for Locking
        public static void enableLocking()
        {
            locking = !locking;
        }

        //Getter for active ATMs
        public static int getActiveATMs()
        {
            return activeATMs;
        }
        //Setter for active ATMs
        public static void setActiveATMs(int a)
        {
            activeATMs = a;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            initAccounts();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CentralBankingComputer());
        }
    }
}
