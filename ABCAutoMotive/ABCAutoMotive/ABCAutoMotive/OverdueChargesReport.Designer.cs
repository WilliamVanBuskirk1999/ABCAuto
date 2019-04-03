namespace ABCAutoMotive
{
    partial class OverdueChargesReport
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
            this.dgvCharges = new System.Windows.Forms.DataGridView();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.btnChargeStudent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharges)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCharges
            // 
            this.dgvCharges.AllowUserToAddRows = false;
            this.dgvCharges.AllowUserToDeleteRows = false;
            this.dgvCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCharges.Location = new System.Drawing.Point(3, 50);
            this.dgvCharges.Name = "dgvCharges";
            this.dgvCharges.ReadOnly = true;
            this.dgvCharges.Size = new System.Drawing.Size(798, 399);
            this.dgvCharges.TabIndex = 0;
            // 
            // btnRunReport
            // 
            this.btnRunReport.Location = new System.Drawing.Point(213, 12);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(345, 23);
            this.btnRunReport.TabIndex = 1;
            this.btnRunReport.Text = "Run Report";
            this.btnRunReport.UseVisualStyleBackColor = true;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);
            // 
            // btnChargeStudent
            // 
            this.btnChargeStudent.Location = new System.Drawing.Point(239, 455);
            this.btnChargeStudent.Name = "btnChargeStudent";
            this.btnChargeStudent.Size = new System.Drawing.Size(295, 23);
            this.btnChargeStudent.TabIndex = 2;
            this.btnChargeStudent.Text = "Charge Students";
            this.btnChargeStudent.UseVisualStyleBackColor = true;
            this.btnChargeStudent.Click += new System.EventHandler(this.btnChargeStudent_Click);
            // 
            // OverdueChargesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 549);
            this.Controls.Add(this.btnChargeStudent);
            this.Controls.Add(this.btnRunReport);
            this.Controls.Add(this.dgvCharges);
            this.Name = "OverdueChargesReport";
            this.Text = "Over Due Charges";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCharges;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.Button btnChargeStudent;
    }
}