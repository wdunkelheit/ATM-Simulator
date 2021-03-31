using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Simulator
{
    public partial class CentralBankingComputer : Form
    {
        //Constructor
        public CentralBankingComputer()
        {
            InitializeComponent();
        }

        //Creates a new ATM window.
        public void newATM()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ATM());
        }

        //Creates a new ATM Window
        private void btnCreateATM_Click(object sender, EventArgs e)
        {
            //CODE FOR NEW ATM WINDOW HERE
            Thread tATM = new Thread(newATM);
            tATM.Start();

            //Increment active ATMs counter
            Program.setActiveATMs(Program.getActiveATMs() + 1);

            //Increment number of active ATMs tracking info on Central Bank Computer interface.
            lblATMNum.Text = Program.getActiveATMs().ToString();
            if (Convert.ToInt32(lblATMNum.Text) > 0)
            {
                lblATMNum.ForeColor = Color.Blue;
            }
        }

        //Change race condition variable and show current state
        private void btnRace_Click(object sender, EventArgs e)
        {
            //Change variable
            Program.enableRace();
            //Change display accordingly.
            if (Program.getRacing())
            {
                lblRCStatus.Text = "Enabled";
                lblRCStatus.ForeColor = Color.LimeGreen;
            }
            //Change to show disabled
            else
            {
                lblRCStatus.Text = "Disabled";
                lblRCStatus.ForeColor = Color.Red;
            }
        }

        //Change locking variable and show current state
        private void btnLocking_Click(object sender, EventArgs e)
        {
            //Change variable.
            Program.enableLocking();
            //Change display accordingly.
            if (Program.getLocking())
            {
                lblLockingStatus.Text = "Enabled";
                lblLockingStatus.ForeColor = Color.LimeGreen;
            }
            //Change to show Disabled
            else
            {
                lblLockingStatus.Text = "Disabled";
                lblLockingStatus.ForeColor = Color.Red;
            }
        }

        //Update Active ATMS when Window is made active..
        private void CentralBankingComputer_Activated(object sender, EventArgs e)
        {
            lblATMNum.Text = Program.getActiveATMs().ToString();
        }
    }
}
