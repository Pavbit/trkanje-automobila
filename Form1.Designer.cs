namespace trka
{
    partial class Form1
    {
   
        private System.ComponentModel.IContainer components = null;

    
        /// <param name="disposing"
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblCoins = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCoins
            // 
            this.lblCoins.AutoSize = true;
            this.lblCoins.Location = new System.Drawing.Point(13, 13);
            this.lblCoins.Name = "lblCoins";
            this.lblCoins.Size = new System.Drawing.Size(54, 16);
            this.lblCoins.TabIndex = 0;
            this.lblCoins.Text = "Coins: 0";
            this.lblCoins.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(904, 13);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(51, 16);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "Time: 0";
            this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(982, 453);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblCoins);
            this.Name = "Form1";
            this.Text = "Trka Automobila";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblCoins;
        private System.Windows.Forms.Label lblTime;
    }
}
        #endregion