using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Simulator
{
    public partial class ATM : Form
    {
        //List of Buttons
        List<Button> buttonMatrix = new List<Button>();

        //String for keeping track of what stage of the ATM process the user is at.
        //Initialized to "ACCOUNT_NUM" as it is the default state.
        string state = "ACCOUNT_NUM";

        //Account details.
        string accountNum;
        int accountIndex;

        //Track number of wrong pin attempts.
        int pinAttempts = 0;

        //Constructor
        public ATM()
        {
            InitializeComponent();
        }

        //Loader
        private void ATM_Load(object sender, EventArgs e)
        {
            labelEnableAll(false);
            displayAccountNumScreen();
        }

        //Event Handler for all number buttons on the keypad.
        private void btnPad_Click(object sender, EventArgs e)
        {
            txtNumpadInput.Text += (sender as Button).Text;
        }
       
        //Accept button, handles most of the ATM logic prior to the menu.
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Button eaves differently based on state.
            switch (state)
            {
                //If account number state, check if account number is correct.
                case "ACCOUNT_NUM_SCREEN":
                    if (checkAccountNum() == 0)
                    {
                        MessageBox.Show("Invalid account number. Please check your account number and try again.", "Invalid account number.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    break;
                //If account number state, check if pin number is correct.
                case "PIN_NUM_SCREEN":
                    if (checkPinNumber() == false)
                    {
                        MessageBox.Show("Invalid pin number. You have " + (3 - pinAttempts).ToString() + " attempts remaining.", "Invalid pin number.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    break;
                case "WITHDRAW_OTHER_SCREEN":
                    //If customer wants an unreasonable ammount of money tell them they can't.
                    float w = float.Parse(txtNumpadInput.Text);
                    if (w % 10 != 0)
                    {
                        MessageBox.Show("This machine can only dispense money in multiples of £10.", "SpeedyBank™", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumpadInput.Text = "";
                    }
                    //If they want something more reasonable then let them, unless they dont have enough.
                    else
                    {
                        withdrawHandler(w);
                        displayMenuScreen();
                    }
                    break;
            }
        }

        //Clear the text of the number entry box.
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNumpadInput.Text = "";
        }

        //Cancel button handler, logic differs based on state
        private void btnCancel_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case "ACCOUNT_NUM_SCREEN":
                    MessageBox.Show("Please take your card and have a nice day!", "SpeedyBank™", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    displayAccountNumScreen();
                    break;
                case "PIN_NUM_SCREEN":
                    displayAccountNumScreen();
                    break;
                case "MENU_SCREEN":
                    MessageBox.Show("Please take your card and have a nice day!", "SpeedyBank™", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    displayAccountNumScreen();
                    break;
                case "BALANCE_SCREEN":
                    displayMenuScreen();
                    break;
                case "WITHDRAW_SCREEN":
                    displayMenuScreen();
                    break;
                case "WITHDRAW_OTHER_SCREEN":
                    displayWithdrawScreen();
                    break;
            }
        }

        //Checks if account number is correct and sets up for pin input if true.
        public int checkAccountNum()
        {
            //Loop around the bank accounts until it finds the correct number.
            for (int i = 0; i < Program.accounts.Length; i++)
            {
                //Find correct account number.
                if (txtNumpadInput.Text == Program.accounts[i].getAccountNum())
                {
                    //If the number exists but has been locked out, inform the user.
                    if (!Program.accounts[i].getValid())
                    {
                        MessageBox.Show("This account has been deactivated for security reasons, you should contact your bank immediately.", "Account Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return 2;
                    }
                    //Store account number for later use.
                    accountNum = Program.accounts[i].getAccountNum();
                    accountIndex = i;

                    //Show the pin number entry screen.
                    displayPinNumScreen();

                    return (1);
                }
            }
            return (0);
        }

        //Check pin number is correct set variables for next state if true.
        public bool checkPinNumber()
        {
            if(txtNumpadInput.Text == Program.accounts[accountIndex].getPinNum())
            {
                //Show menu button labels.
                displayMenuScreen();
                return true;
            }
            else
            {
                //Increment number of incorrect in entries.
                pinAttempts++;

                //If user has gotten pin wrong 3 times then kick them back to the main screen.
                if (pinAttempts == 3)
                {
                    MessageBox.Show("You have entered the wrong pin number 3 times, for security reasons your account is no longer accessible. Please contact your bank for a reset.", "Security.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //Revokes access to this account for all ATMs
                    Program.accounts[accountIndex].setValid();
                    //Exit ATM instance.
                    this.Close();
                }

                return false;
            }
        }

        private void withdrawHandler(float w)
        {
            if (Program.accounts[accountIndex].withdrawMoney(w))
            {
                MessageBox.Show("Please take your cash.", "SpeedyBank™", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Insufficient funds in account, returning to withdraw screen.", "SpeedyBan™", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Top left button
        private void btnLeftTop_Click(object sender, EventArgs e)
        {
            //If coming from menu screen.
            if (state == "MENU_SCREEN")
            {
                displayBalanceScreen();
            }
            else if (state == "WITHDRAW_SCREEN")
            {
                withdrawHandler(10);
                displayMenuScreen();
            }
        }
        
        //Center left button
        private void btnLeft_Click(object sender, EventArgs e)
        {
            //Switch display to the Withdraw cash menu.
            if (state == "MENU_SCREEN")
            {
                displayWithdrawScreen();
            }
            else if (state == "WITHDRAW_SCREEN")
            {
                withdrawHandler(30);
                displayMenuScreen();
            }
        }
        //Bottom left button
        private void btnLeftBottom_Click(object sender, EventArgs e)
        {
            if (state == "WITHDRAW_SCREEN")
            {
                withdrawHandler(100);
                displayMenuScreen();
            }
        }

        //Top right button
        private void btnRightTop_Click(object sender, EventArgs e)
        {
            if (state == "WITHDRAW_SCREEN")
            {
                withdrawHandler(20);
                displayMenuScreen();
            }
        }

        //Center right button
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (state == "WITHDRAW_SCREEN")
            {
                withdrawHandler(50);
                displayMenuScreen();
            }
        }

        //Bottom right button
        private void btnRightBottom_Click(object sender, EventArgs e)
        {
            //If check balance is active, go back to main menu.
            if (state == "CHECK_BALANCE")
            {
                displayMenuScreen();
                state = "MENU_SCREEN";
            }
            else if (state == "WITHDRAW_SCREEN")
            {
                displayWithdrawOtherScreen();
            }
        }

        //Display the withdraw other ammount screen.
        public void displayWithdrawOtherScreen()
        {
            //Change state.
            state = "WITHDRAW_OTHER_SCREEN";

            //Display prompt
            lblEnterText.Visible = true;
            lblEnterText.Text = "Insert Withdraw Ammount:";

            //Clear numpad.
            txtNumpadInput.Text = "";
            txtNumpadInput.Enabled = true;
            txtNumpadInput.Visible = true;
            txtNumpadInput.PasswordChar = '\0';

            //Make background labels visible and assign correct text.
            lblLeft.Visible = false;
            lblLeftTop.Visible = false;
            lblLeftBottom.Visible = false;
            lblRight.Visible = false;
            lblRightTop.Visible = false;
            lblRightBottom.Visible = false;
        }

        //Display the withdraw options screen
        public void displayWithdrawScreen()
        {
            //Change state.
            state = "WITHDRAW_SCREEN";

            //Display prompt
            lblEnterText.Visible = false;

            //Clear numpad.
            txtNumpadInput.Text = "";
            txtNumpadInput.Enabled = false;
            txtNumpadInput.Visible = false;

            //Assign cash values to labels.
            lblLeftTop.Text = "£10";
            lblRightTop.Text = "£20";
            lblLeft.Text = "£30";
            lblRight.Text = "£50";
            lblLeftBottom.Text = "£100";
            lblRightBottom.Text = "Other";

            //Make background labels visible and assign correct text.
            lblLeft.Visible = true;
            lblLeftTop.Visible = true;
            lblLeftBottom.Visible = true;
            lblRight.Visible = true;
            lblRightTop.Visible = true;
            lblRightBottom.Visible = true;
        }

        //Display check balance screen.
        public void displayBalanceScreen()
        {
            //Change state.
            state = "BALANCE_SCREEN";

            //Display prompt
            lblEnterText.Visible = true;
            lblEnterText.Text = "Your balance is:";

            //Clear numpad.
            txtNumpadInput.Text = "";
            txtNumpadInput.Enabled = true;
            txtNumpadInput.Visible = true;
            txtNumpadInput.Text = "£" + Program.accounts[accountIndex].getBalance().ToString();
            txtNumpadInput.PasswordChar = '\0';

            //Make background labels visible and assign correct text.
            lblLeft.Visible = false;
            lblLeftTop.Visible = false;
            lblLeftBottom.Visible = false;
            lblRight.Visible = false;
            lblRightTop.Visible = false;
            lblRightBottom.Visible = false;
        }

        //Display main menu screen.
        public void displayMenuScreen()
        {
            //Change state.
            state = "MENU_SCREEN";

            //Display prompt
            lblEnterText.Visible = false;

            //Clear numpad.
            txtNumpadInput.Text = "";
            txtNumpadInput.Enabled = false;
            txtNumpadInput.Visible = false;

            //Make background labels visible and assign correct text.
            lblLeft.Visible = true;
            lblLeft.Text = "Withdraw Cash";
            lblLeftTop.Visible = true;
            lblLeftTop.Text = "Check Balance";

            //Hide these until needed.
            lblLeftBottom.Visible = false;
            lblRight.Visible = false;
            lblRightTop.Visible = false;
            lblRightBottom.Visible = false;
        }

        //Display pin number entry screen
        public void displayPinNumScreen()
        {
            //Assign state
            state = "PIN_NUM_SCREEN";

            //Display prompt
            lblEnterText.Visible = true;
            lblEnterText.Text = "Enter Pin Number:";

            //Clear numpad.
            txtNumpadInput.Text = "";
            txtNumpadInput.Enabled = true;
            txtNumpadInput.Visible = true;
            txtNumpadInput.PasswordChar = '*';

            //Make background labels invisible.
            lblLeft.Visible = false;
            lblLeftTop.Visible = false;
            lblLeftBottom.Visible = false;
            lblRight.Visible = false;
            lblRightTop.Visible = false;
            lblRightBottom.Visible = false;
        }

        //Display Account number entry screen
        public void displayAccountNumScreen()
        {
            //Assign state
            state = "ACCOUNT_NUM_SCREEN";

            //Display prompt
            lblEnterText.Visible = true;
            lblEnterText.Text = "Enter Account Number:";

            //Clear numpad.
            txtNumpadInput.Text = "";
            txtNumpadInput.Enabled = true;
            txtNumpadInput.Visible = true;
            //Null character. No password character.
            txtNumpadInput.PasswordChar = '\0';

            //Make background labels invisible.
            lblLeft.Visible = false;
            lblLeftTop.Visible = false;
            lblLeftBottom.Visible = false;
            lblRight.Visible = false;
            lblRightTop.Visible = false;
            lblRightBottom.Visible = false;
        }

        //Enable or Disable all button companion labels
        private void labelEnableAll(bool e)
        {
            //Hide the selection buttons.
            lblLeft.Visible = e;
            lblLeftBottom.Visible = e;
            lblLeftTop.Visible = e;
            lblRight.Visible = e;
            lblRightTop.Visible = e;
            lblRightBottom.Visible = e;
        }

        //When window is closed, decrement ATM count
        private void ATM_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Decrement ATM count
            Program.setActiveATMs(Program.getActiveATMs() - 1);
        }
    }
}
