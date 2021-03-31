namespace ATM_Simulator
{
    partial class CentralBankingComputer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CentralBankingComputer));
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnCreateATM = new System.Windows.Forms.Button();
            this.btnRace = new System.Windows.Forms.Button();
            this.lblActiveATMs = new System.Windows.Forms.Label();
            this.lblRaceCondition = new System.Windows.Forms.Label();
            this.lblATMNum = new System.Windows.Forms.Label();
            this.lblRCStatus = new System.Windows.Forms.Label();
            this.btnLocking = new System.Windows.Forms.Button();
            this.lblLockingStatus = new System.Windows.Forms.Label();
            this.lblLocking = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(12, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(256, 13);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to SpeedyBank, where it\'s all about speed!";
            // 
            // btnCreateATM
            // 
            this.btnCreateATM.Location = new System.Drawing.Point(12, 42);
            this.btnCreateATM.Name = "btnCreateATM";
            this.btnCreateATM.Size = new System.Drawing.Size(124, 90);
            this.btnCreateATM.TabIndex = 1;
            this.btnCreateATM.Text = "Create ATM";
            this.btnCreateATM.UseVisualStyleBackColor = true;
            this.btnCreateATM.Click += new System.EventHandler(this.btnCreateATM_Click);
            // 
            // btnRace
            // 
            this.btnRace.Location = new System.Drawing.Point(144, 42);
            this.btnRace.Name = "btnRace";
            this.btnRace.Size = new System.Drawing.Size(124, 42);
            this.btnRace.TabIndex = 2;
            this.btnRace.Text = "Enable Racing";
            this.btnRace.UseVisualStyleBackColor = true;
            this.btnRace.Click += new System.EventHandler(this.btnRace_Click);
            // 
            // lblActiveATMs
            // 
            this.lblActiveATMs.AutoSize = true;
            this.lblActiveATMs.Location = new System.Drawing.Point(12, 135);
            this.lblActiveATMs.Name = "lblActiveATMs";
            this.lblActiveATMs.Size = new System.Drawing.Size(71, 13);
            this.lblActiveATMs.TabIndex = 3;
            this.lblActiveATMs.Text = "Active ATMs:";
            // 
            // lblRaceCondition
            // 
            this.lblRaceCondition.AutoSize = true;
            this.lblRaceCondition.Location = new System.Drawing.Point(12, 148);
            this.lblRaceCondition.Name = "lblRaceCondition";
            this.lblRaceCondition.Size = new System.Drawing.Size(83, 13);
            this.lblRaceCondition.TabIndex = 4;
            this.lblRaceCondition.Text = "Race Condition:";
            // 
            // lblATMNum
            // 
            this.lblATMNum.AutoSize = true;
            this.lblATMNum.ForeColor = System.Drawing.Color.Red;
            this.lblATMNum.Location = new System.Drawing.Point(78, 135);
            this.lblATMNum.Name = "lblATMNum";
            this.lblATMNum.Size = new System.Drawing.Size(13, 13);
            this.lblATMNum.TabIndex = 5;
            this.lblATMNum.Text = "0";
            // 
            // lblRCStatus
            // 
            this.lblRCStatus.AutoSize = true;
            this.lblRCStatus.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblRCStatus.Location = new System.Drawing.Point(91, 148);
            this.lblRCStatus.Name = "lblRCStatus";
            this.lblRCStatus.Size = new System.Drawing.Size(46, 13);
            this.lblRCStatus.TabIndex = 6;
            this.lblRCStatus.Text = "Enabled";
            // 
            // btnLocking
            // 
            this.btnLocking.Location = new System.Drawing.Point(142, 90);
            this.btnLocking.Name = "btnLocking";
            this.btnLocking.Size = new System.Drawing.Size(124, 42);
            this.btnLocking.TabIndex = 7;
            this.btnLocking.Text = "Enable Locking";
            this.btnLocking.UseVisualStyleBackColor = true;
            this.btnLocking.Click += new System.EventHandler(this.btnLocking_Click);
            // 
            // lblLockingStatus
            // 
            this.lblLockingStatus.AutoSize = true;
            this.lblLockingStatus.ForeColor = System.Drawing.Color.Red;
            this.lblLockingStatus.Location = new System.Drawing.Point(91, 161);
            this.lblLockingStatus.Name = "lblLockingStatus";
            this.lblLockingStatus.Size = new System.Drawing.Size(48, 13);
            this.lblLockingStatus.TabIndex = 9;
            this.lblLockingStatus.Text = "Disabled";
            // 
            // lblLocking
            // 
            this.lblLocking.AutoSize = true;
            this.lblLocking.Location = new System.Drawing.Point(12, 161);
            this.lblLocking.Name = "lblLocking";
            this.lblLocking.Size = new System.Drawing.Size(81, 13);
            this.lblLocking.TabIndex = 8;
            this.lblLocking.Text = "Locking Status:";
            // 
            // CentralBankingComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 190);
            this.Controls.Add(this.lblLockingStatus);
            this.Controls.Add(this.lblLocking);
            this.Controls.Add(this.btnLocking);
            this.Controls.Add(this.lblRCStatus);
            this.Controls.Add(this.lblATMNum);
            this.Controls.Add(this.lblRaceCondition);
            this.Controls.Add(this.lblActiveATMs);
            this.Controls.Add(this.btnRace);
            this.Controls.Add(this.btnCreateATM);
            this.Controls.Add(this.lblWelcome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CentralBankingComputer";
            this.Text = "Cental Bank Computer";
            this.Activated += new System.EventHandler(this.CentralBankingComputer_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnCreateATM;
        private System.Windows.Forms.Button btnRace;
        private System.Windows.Forms.Label lblActiveATMs;
        private System.Windows.Forms.Label lblRaceCondition;
        private System.Windows.Forms.Label lblATMNum;
        private System.Windows.Forms.Label lblRCStatus;
        private System.Windows.Forms.Button btnLocking;
        private System.Windows.Forms.Label lblLockingStatus;
        private System.Windows.Forms.Label lblLocking;
    }
}

