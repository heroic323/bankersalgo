namespace BankersAlgorithm
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.lblDefinition = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.tileChecking = new MetroFramework.Controls.MetroTile();
            this.tileAllocating = new MetroFramework.Controls.MetroTile();
            this.tileAcquiring = new MetroFramework.Controls.MetroTile();
            this.tileRejecting = new MetroFramework.Controls.MetroTile();
            this.tileEnd = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // lblDefinition
            // 
            this.lblDefinition.AutoSize = true;
            this.lblDefinition.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDefinition.Location = new System.Drawing.Point(19, 77);
            this.lblDefinition.Name = "lblDefinition";
            this.lblDefinition.Size = new System.Drawing.Size(402, 140);
            this.lblDefinition.TabIndex = 0;
            this.lblDefinition.Text = resources.GetString("lblDefinition.Text");
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(19, 234);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(183, 25);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Simulator Legends:";
            // 
            // tileChecking
            // 
            this.tileChecking.ActiveControl = null;
            this.tileChecking.BackColor = System.Drawing.Color.DimGray;
            this.tileChecking.Location = new System.Drawing.Point(37, 276);
            this.tileChecking.Name = "tileChecking";
            this.tileChecking.Size = new System.Drawing.Size(160, 45);
            this.tileChecking.TabIndex = 2;
            this.tileChecking.Text = "Checking";
            this.tileChecking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tileChecking.UseCustomBackColor = true;
            this.tileChecking.UseSelectable = true;
            // 
            // tileAllocating
            // 
            this.tileAllocating.ActiveControl = null;
            this.tileAllocating.BackColor = System.Drawing.Color.DimGray;
            this.tileAllocating.Location = new System.Drawing.Point(37, 355);
            this.tileAllocating.Name = "tileAllocating";
            this.tileAllocating.Size = new System.Drawing.Size(160, 45);
            this.tileAllocating.TabIndex = 3;
            this.tileAllocating.Text = "Allocating";
            this.tileAllocating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tileAllocating.UseCustomBackColor = true;
            this.tileAllocating.UseSelectable = true;
            // 
            // tileAcquiring
            // 
            this.tileAcquiring.ActiveControl = null;
            this.tileAcquiring.BackColor = System.Drawing.Color.DimGray;
            this.tileAcquiring.Location = new System.Drawing.Point(37, 433);
            this.tileAcquiring.Name = "tileAcquiring";
            this.tileAcquiring.Size = new System.Drawing.Size(160, 45);
            this.tileAcquiring.TabIndex = 4;
            this.tileAcquiring.Text = "Acquiring";
            this.tileAcquiring.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tileAcquiring.UseCustomBackColor = true;
            this.tileAcquiring.UseSelectable = true;
            // 
            // tileRejecting
            // 
            this.tileRejecting.ActiveControl = null;
            this.tileRejecting.BackColor = System.Drawing.Color.DimGray;
            this.tileRejecting.Location = new System.Drawing.Point(37, 509);
            this.tileRejecting.Name = "tileRejecting";
            this.tileRejecting.Size = new System.Drawing.Size(160, 45);
            this.tileRejecting.TabIndex = 5;
            this.tileRejecting.Text = "Rejecting";
            this.tileRejecting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tileRejecting.UseCustomBackColor = true;
            this.tileRejecting.UseSelectable = true;
            // 
            // tileEnd
            // 
            this.tileEnd.ActiveControl = null;
            this.tileEnd.BackColor = System.Drawing.Color.DimGray;
            this.tileEnd.Location = new System.Drawing.Point(37, 585);
            this.tileEnd.Name = "tileEnd";
            this.tileEnd.Size = new System.Drawing.Size(160, 45);
            this.tileEnd.TabIndex = 6;
            this.tileEnd.Text = "End";
            this.tileEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tileEnd.UseCustomBackColor = true;
            this.tileEnd.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(217, 276);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(291, 40);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "The Banker checks if it has enough resources\r\nfor Process N.";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(217, 360);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(287, 40);
            this.metroLabel7.TabIndex = 12;
            this.metroLabel7.Text = "If the Banker has enough resources, allocate \r\nto Process N";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(217, 433);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(288, 40);
            this.metroLabel8.TabIndex = 13;
            this.metroLabel8.Text = "After allocation, the Process N has executed. \r\nReacquire allocated resources.";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(217, 509);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(309, 40);
            this.metroLabel9.TabIndex = 14;
            this.metroLabel9.Text = "If the Banker does not have enough resources.\r\nReject and check other processes o" +
    "n the queue.";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(217, 595);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(250, 20);
            this.metroLabel3.TabIndex = 15;
            this.metroLabel3.Text = "Proceed to next process on the queue.";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 683);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.tileEnd);
            this.Controls.Add(this.tileRejecting);
            this.Controls.Add(this.tileAcquiring);
            this.Controls.Add(this.tileAllocating);
            this.Controls.Add(this.tileChecking);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.lblDefinition);
            this.Name = "HelpForm";
            this.Text = "What is Banker\'s Algorithm?";
            this.Load += new System.EventHandler(this.HelpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblDefinition;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTile tileChecking;
        private MetroFramework.Controls.MetroTile tileAllocating;
        private MetroFramework.Controls.MetroTile tileAcquiring;
        private MetroFramework.Controls.MetroTile tileRejecting;
        private MetroFramework.Controls.MetroTile tileEnd;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}