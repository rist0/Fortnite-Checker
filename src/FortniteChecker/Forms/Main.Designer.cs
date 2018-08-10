namespace FortniteChecker.Forms
{
    partial class Main
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
            this.gbInputData = new System.Windows.Forms.GroupBox();
            this.btnLoadResultsDirectory = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtResultsDirectory = new System.Windows.Forms.TextBox();
            this.btnLoadAccounts = new System.Windows.Forms.Button();
            this.lblAccounts = new System.Windows.Forms.Label();
            this.btnLoadProxies = new System.Windows.Forms.Button();
            this.lblProxies = new System.Windows.Forms.Label();
            this.gbStatistics = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.cbUseProxies = new System.Windows.Forms.CheckBox();
            this.lblChecked = new System.Windows.Forms.Label();
            this.lblValid = new System.Windows.Forms.Label();
            this.lblInvalid = new System.Windows.Forms.Label();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.gbInputData.SuspendLayout();
            this.gbStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInputData
            // 
            this.gbInputData.Controls.Add(this.btnLoadResultsDirectory);
            this.gbInputData.Controls.Add(this.label7);
            this.gbInputData.Controls.Add(this.txtResultsDirectory);
            this.gbInputData.Controls.Add(this.btnLoadAccounts);
            this.gbInputData.Controls.Add(this.lblAccounts);
            this.gbInputData.Controls.Add(this.btnLoadProxies);
            this.gbInputData.Controls.Add(this.lblProxies);
            this.gbInputData.Location = new System.Drawing.Point(12, 12);
            this.gbInputData.Name = "gbInputData";
            this.gbInputData.Size = new System.Drawing.Size(360, 147);
            this.gbInputData.TabIndex = 0;
            this.gbInputData.TabStop = false;
            this.gbInputData.Text = "Input Data";
            // 
            // btnLoadResultsDirectory
            // 
            this.btnLoadResultsDirectory.Location = new System.Drawing.Point(251, 99);
            this.btnLoadResultsDirectory.Name = "btnLoadResultsDirectory";
            this.btnLoadResultsDirectory.Size = new System.Drawing.Size(94, 23);
            this.btnLoadResultsDirectory.TabIndex = 8;
            this.btnLoadResultsDirectory.Text = "Load Directory";
            this.btnLoadResultsDirectory.UseVisualStyleBackColor = true;
            this.btnLoadResultsDirectory.Click += new System.EventHandler(this.btnLoadResultsDirectory_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Results directory:";
            // 
            // txtResultsDirectory
            // 
            this.txtResultsDirectory.Location = new System.Drawing.Point(21, 101);
            this.txtResultsDirectory.Name = "txtResultsDirectory";
            this.txtResultsDirectory.ReadOnly = true;
            this.txtResultsDirectory.Size = new System.Drawing.Size(224, 20);
            this.txtResultsDirectory.TabIndex = 6;
            // 
            // btnLoadAccounts
            // 
            this.btnLoadAccounts.Location = new System.Drawing.Point(151, 48);
            this.btnLoadAccounts.Name = "btnLoadAccounts";
            this.btnLoadAccounts.Size = new System.Drawing.Size(94, 23);
            this.btnLoadAccounts.TabIndex = 5;
            this.btnLoadAccounts.Text = "Load Accounts";
            this.btnLoadAccounts.UseVisualStyleBackColor = true;
            this.btnLoadAccounts.Click += new System.EventHandler(this.btnLoadAccounts_Click);
            // 
            // lblAccounts
            // 
            this.lblAccounts.AutoSize = true;
            this.lblAccounts.Location = new System.Drawing.Point(148, 32);
            this.lblAccounts.Name = "lblAccounts";
            this.lblAccounts.Size = new System.Drawing.Size(55, 13);
            this.lblAccounts.TabIndex = 4;
            this.lblAccounts.Tag = "Accounts:";
            this.lblAccounts.Text = "Accounts:";
            // 
            // btnLoadProxies
            // 
            this.btnLoadProxies.Location = new System.Drawing.Point(21, 48);
            this.btnLoadProxies.Name = "btnLoadProxies";
            this.btnLoadProxies.Size = new System.Drawing.Size(94, 23);
            this.btnLoadProxies.TabIndex = 2;
            this.btnLoadProxies.Text = "Load Proxies";
            this.btnLoadProxies.UseVisualStyleBackColor = true;
            this.btnLoadProxies.Click += new System.EventHandler(this.btnLoadProxies_Click);
            // 
            // lblProxies
            // 
            this.lblProxies.AutoSize = true;
            this.lblProxies.Location = new System.Drawing.Point(18, 32);
            this.lblProxies.Name = "lblProxies";
            this.lblProxies.Size = new System.Drawing.Size(44, 13);
            this.lblProxies.TabIndex = 1;
            this.lblProxies.Tag = "Proxies:";
            this.lblProxies.Text = "Proxies:";
            // 
            // gbStatistics
            // 
            this.gbStatistics.Controls.Add(this.lblInvalid);
            this.gbStatistics.Controls.Add(this.lblValid);
            this.gbStatistics.Controls.Add(this.label5);
            this.gbStatistics.Controls.Add(this.label4);
            this.gbStatistics.Controls.Add(this.lblChecked);
            this.gbStatistics.Controls.Add(this.label3);
            this.gbStatistics.Location = new System.Drawing.Point(12, 173);
            this.gbStatistics.Name = "gbStatistics";
            this.gbStatistics.Size = new System.Drawing.Size(179, 123);
            this.gbStatistics.TabIndex = 6;
            this.gbStatistics.TabStop = false;
            this.gbStatistics.Text = "Statistics";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Invalid:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Valid:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Checked:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(212, 273);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(297, 273);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // cbUseProxies
            // 
            this.cbUseProxies.AutoSize = true;
            this.cbUseProxies.Location = new System.Drawing.Point(212, 250);
            this.cbUseProxies.Name = "cbUseProxies";
            this.cbUseProxies.Size = new System.Drawing.Size(82, 17);
            this.cbUseProxies.TabIndex = 8;
            this.cbUseProxies.Text = "Use Proxies";
            this.cbUseProxies.UseVisualStyleBackColor = true;
            // 
            // lblChecked
            // 
            this.lblChecked.AutoSize = true;
            this.lblChecked.Location = new System.Drawing.Point(77, 34);
            this.lblChecked.Name = "lblChecked";
            this.lblChecked.Size = new System.Drawing.Size(13, 13);
            this.lblChecked.TabIndex = 0;
            this.lblChecked.Text = "  ";
            // 
            // lblValid
            // 
            this.lblValid.AutoSize = true;
            this.lblValid.Location = new System.Drawing.Point(77, 62);
            this.lblValid.Name = "lblValid";
            this.lblValid.Size = new System.Drawing.Size(13, 13);
            this.lblValid.TabIndex = 1;
            this.lblValid.Text = "  ";
            // 
            // lblInvalid
            // 
            this.lblInvalid.AutoSize = true;
            this.lblInvalid.Location = new System.Drawing.Point(77, 91);
            this.lblInvalid.Name = "lblInvalid";
            this.lblInvalid.Size = new System.Drawing.Size(13, 13);
            this.lblInvalid.TabIndex = 2;
            this.lblInvalid.Text = "  ";
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Location = new System.Drawing.Point(12, 302);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(360, 23);
            this.progressBarStatus.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 342);
            this.Controls.Add(this.progressBarStatus);
            this.Controls.Add(this.cbUseProxies);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gbStatistics);
            this.Controls.Add(this.gbInputData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fortnite Checker";
            this.gbInputData.ResumeLayout(false);
            this.gbInputData.PerformLayout();
            this.gbStatistics.ResumeLayout(false);
            this.gbStatistics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInputData;
        private System.Windows.Forms.Button btnLoadProxies;
        private System.Windows.Forms.Label lblProxies;
        private System.Windows.Forms.Button btnLoadAccounts;
        private System.Windows.Forms.Label lblAccounts;
        private System.Windows.Forms.GroupBox gbStatistics;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnLoadResultsDirectory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtResultsDirectory;
        private System.Windows.Forms.CheckBox cbUseProxies;
        private System.Windows.Forms.Label lblInvalid;
        private System.Windows.Forms.Label lblValid;
        private System.Windows.Forms.Label lblChecked;
        private System.Windows.Forms.ProgressBar progressBarStatus;
    }
}

