namespace ABCAutoMotive
{
    partial class CheckoutResource
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lstSearchResults = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.txtBalanceDue = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtTelephoneNumber = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.btnGetStudent = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbStudentStatus = new System.Windows.Forms.ComboBox();
            this.txtResourceSearch = new System.Windows.Forms.TextBox();
            this.btnSearchForResource = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lstResourceSearchResults = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbReserveStatus = new System.Windows.Forms.ComboBox();
            this.cmbResourceStatus = new System.Windows.Forms.ComboBox();
            this.cmbResourceType = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnGetResource = new System.Windows.Forms.Button();
            this.dgvLoans = new System.Windows.Forms.DataGridView();
            this.btnCheckoutResource = new System.Windows.Forms.Button();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.cmbItemsToCheckout = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnRemoveFromList = new System.Windows.Forms.Button();
            this.btnResetForm = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(108, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(204, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search For Student";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(319, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.FormattingEnabled = true;
            this.lstSearchResults.Location = new System.Drawing.Point(6, 51);
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(388, 108);
            this.lstSearchResults.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Balance Due";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Program";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Start Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "End Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(250, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Student Status";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(272, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 11;
            // 
            // cmbProgram
            // 
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.Enabled = false;
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(118, 117);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(121, 21);
            this.cmbProgram.TabIndex = 3;
            // 
            // txtBalanceDue
            // 
            this.txtBalanceDue.Enabled = false;
            this.txtBalanceDue.Location = new System.Drawing.Point(118, 88);
            this.txtBalanceDue.Name = "txtBalanceDue";
            this.txtBalanceDue.Size = new System.Drawing.Size(100, 20);
            this.txtBalanceDue.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Enabled = false;
            this.txtLastName.Location = new System.Drawing.Point(118, 61);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Enabled = false;
            this.txtFirstName.Location = new System.Drawing.Point(118, 35);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 0;
            // 
            // txtAddress
            // 
            this.txtAddress.Enabled = false;
            this.txtAddress.Location = new System.Drawing.Point(333, 114);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 20);
            this.txtAddress.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Address";
            // 
            // lbl11
            // 
            this.lbl11.AutoSize = true;
            this.lbl11.Location = new System.Drawing.Point(88, 144);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(24, 13);
            this.lbl11.TabIndex = 21;
            this.lbl11.Text = "City";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Telephone Number";
            // 
            // txtCity
            // 
            this.txtCity.Enabled = false;
            this.txtCity.Location = new System.Drawing.Point(118, 144);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 20);
            this.txtCity.TabIndex = 4;
            // 
            // txtTelephoneNumber
            // 
            this.txtTelephoneNumber.Enabled = false;
            this.txtTelephoneNumber.Location = new System.Drawing.Point(118, 170);
            this.txtTelephoneNumber.Name = "txtTelephoneNumber";
            this.txtTelephoneNumber.Size = new System.Drawing.Size(100, 20);
            this.txtTelephoneNumber.TabIndex = 5;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Location = new System.Drawing.Point(333, 35);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 6;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Location = new System.Drawing.Point(333, 59);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDate.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(272, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Student Id";
            // 
            // txtStudentId
            // 
            this.txtStudentId.Enabled = false;
            this.txtStudentId.Location = new System.Drawing.Point(333, 140);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(100, 20);
            this.txtStudentId.TabIndex = 10;
            // 
            // btnGetStudent
            // 
            this.btnGetStudent.Location = new System.Drawing.Point(13, 166);
            this.btnGetStudent.Name = "btnGetStudent";
            this.btnGetStudent.Size = new System.Drawing.Size(75, 23);
            this.btnGetStudent.TabIndex = 4;
            this.btnGetStudent.Text = "Get Student Info";
            this.btnGetStudent.UseVisualStyleBackColor = true;
            this.btnGetStudent.Click += new System.EventHandler(this.btnGetStudent_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbStudentStatus);
            this.panel1.Controls.Add(this.txtFirstName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtStudentId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Controls.Add(this.cmbProgram);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtTelephoneNumber);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.txtBalanceDue);
            this.panel1.Controls.Add(this.txtCity);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtLastName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lbl11);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(13, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 237);
            this.panel1.TabIndex = 30;
            // 
            // cmbStudentStatus
            // 
            this.cmbStudentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudentStatus.Enabled = false;
            this.cmbStudentStatus.FormattingEnabled = true;
            this.cmbStudentStatus.Location = new System.Drawing.Point(334, 86);
            this.cmbStudentStatus.Name = "cmbStudentStatus";
            this.cmbStudentStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStudentStatus.TabIndex = 8;
            // 
            // txtResourceSearch
            // 
            this.txtResourceSearch.Location = new System.Drawing.Point(804, 11);
            this.txtResourceSearch.Name = "txtResourceSearch";
            this.txtResourceSearch.Size = new System.Drawing.Size(195, 20);
            this.txtResourceSearch.TabIndex = 5;
            // 
            // btnSearchForResource
            // 
            this.btnSearchForResource.Location = new System.Drawing.Point(1005, 8);
            this.btnSearchForResource.Name = "btnSearchForResource";
            this.btnSearchForResource.Size = new System.Drawing.Size(75, 23);
            this.btnSearchForResource.TabIndex = 6;
            this.btnSearchForResource.Text = "Search";
            this.btnSearchForResource.UseVisualStyleBackColor = true;
            this.btnSearchForResource.Click += new System.EventHandler(this.btnSearchForResource_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(690, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Search For Resource";
            // 
            // lstResourceSearchResults
            // 
            this.lstResourceSearchResults.FormattingEnabled = true;
            this.lstResourceSearchResults.Location = new System.Drawing.Point(693, 51);
            this.lstResourceSearchResults.Name = "lstResourceSearchResults";
            this.lstResourceSearchResults.Size = new System.Drawing.Size(481, 108);
            this.lstResourceSearchResults.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbReserveStatus);
            this.panel2.Controls.Add(this.cmbResourceStatus);
            this.panel2.Controls.Add(this.cmbResourceType);
            this.panel2.Controls.Add(this.txtTitle);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(693, 208);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(511, 108);
            this.panel2.TabIndex = 35;
            // 
            // cmbReserveStatus
            // 
            this.cmbReserveStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReserveStatus.FormattingEnabled = true;
            this.cmbReserveStatus.Location = new System.Drawing.Point(273, 55);
            this.cmbReserveStatus.Name = "cmbReserveStatus";
            this.cmbReserveStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbReserveStatus.TabIndex = 7;
            // 
            // cmbResourceStatus
            // 
            this.cmbResourceStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResourceStatus.FormattingEnabled = true;
            this.cmbResourceStatus.Location = new System.Drawing.Point(273, 13);
            this.cmbResourceStatus.Name = "cmbResourceStatus";
            this.cmbResourceStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbResourceStatus.TabIndex = 6;
            // 
            // cmbResourceType
            // 
            this.cmbResourceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResourceType.FormattingEnabled = true;
            this.cmbResourceType.Location = new System.Drawing.Point(55, 52);
            this.cmbResourceType.Name = "cmbResourceType";
            this.cmbResourceType.Size = new System.Drawing.Size(121, 21);
            this.cmbResourceType.TabIndex = 5;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(54, 16);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(100, 20);
            this.txtTitle.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(187, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Reserve Status";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(180, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Resource Status";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Type";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Title";
            // 
            // btnGetResource
            // 
            this.btnGetResource.Location = new System.Drawing.Point(693, 165);
            this.btnGetResource.Name = "btnGetResource";
            this.btnGetResource.Size = new System.Drawing.Size(105, 23);
            this.btnGetResource.TabIndex = 8;
            this.btnGetResource.Text = "Get Resource";
            this.btnGetResource.UseVisualStyleBackColor = true;
            this.btnGetResource.Click += new System.EventHandler(this.btnGetResource_Click);
            // 
            // dgvLoans
            // 
            this.dgvLoans.AllowUserToAddRows = false;
            this.dgvLoans.AllowUserToDeleteRows = false;
            this.dgvLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoans.Location = new System.Drawing.Point(240, 467);
            this.dgvLoans.Name = "dgvLoans";
            this.dgvLoans.ReadOnly = true;
            this.dgvLoans.Size = new System.Drawing.Size(629, 150);
            this.dgvLoans.TabIndex = 37;
            // 
            // btnCheckoutResource
            // 
            this.btnCheckoutResource.Location = new System.Drawing.Point(693, 400);
            this.btnCheckoutResource.Name = "btnCheckoutResource";
            this.btnCheckoutResource.Size = new System.Drawing.Size(75, 23);
            this.btnCheckoutResource.TabIndex = 12;
            this.btnCheckoutResource.Text = "Checkout";
            this.btnCheckoutResource.UseVisualStyleBackColor = true;
            this.btnCheckoutResource.Click += new System.EventHandler(this.btnCheckoutResource_Click);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(693, 323);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(75, 23);
            this.btnAddToList.TabIndex = 9;
            this.btnAddToList.Text = "Add To List";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // cmbItemsToCheckout
            // 
            this.cmbItemsToCheckout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemsToCheckout.FormattingEnabled = true;
            this.cmbItemsToCheckout.Location = new System.Drawing.Point(693, 373);
            this.cmbItemsToCheckout.Name = "cmbItemsToCheckout";
            this.cmbItemsToCheckout.Size = new System.Drawing.Size(121, 21);
            this.cmbItemsToCheckout.TabIndex = 10;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(240, 451);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(164, 13);
            this.label18.TabIndex = 41;
            this.label18.Text = "Resources Signed out by student";
            // 
            // btnRemoveFromList
            // 
            this.btnRemoveFromList.Location = new System.Drawing.Point(843, 373);
            this.btnRemoveFromList.Name = "btnRemoveFromList";
            this.btnRemoveFromList.Size = new System.Drawing.Size(93, 23);
            this.btnRemoveFromList.TabIndex = 11;
            this.btnRemoveFromList.Text = "Remove Item";
            this.btnRemoveFromList.UseVisualStyleBackColor = true;
            this.btnRemoveFromList.Click += new System.EventHandler(this.btnRemoveFromList_Click);
            // 
            // btnResetForm
            // 
            this.btnResetForm.Enabled = false;
            this.btnResetForm.Location = new System.Drawing.Point(243, 623);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(75, 23);
            this.btnResetForm.TabIndex = 13;
            this.btnResetForm.Text = "Reset Form";
            this.btnResetForm.UseVisualStyleBackColor = true;
            this.btnResetForm.Click += new System.EventHandler(this.btnResetForm_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(690, 358);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(148, 13);
            this.label19.TabIndex = 44;
            this.label19.Text = "Resources to be checked out";
            // 
            // CheckoutResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 724);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnResetForm);
            this.Controls.Add(this.btnRemoveFromList);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cmbItemsToCheckout);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.btnCheckoutResource);
            this.Controls.Add(this.dgvLoans);
            this.Controls.Add(this.btnGetResource);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lstResourceSearchResults);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnSearchForResource);
            this.Controls.Add(this.txtResourceSearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGetStudent);
            this.Controls.Add(this.lstSearchResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Name = "CheckoutResource";
            this.Text = "Check Out Resource";
            this.Load += new System.EventHandler(this.CheckoutResource_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lstSearchResults;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.TextBox txtBalanceDue;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtTelephoneNumber;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Button btnGetStudent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtResourceSearch;
        private System.Windows.Forms.Button btnSearchForResource;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbStudentStatus;
        private System.Windows.Forms.ListBox lstResourceSearchResults;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbReserveStatus;
        private System.Windows.Forms.ComboBox cmbResourceStatus;
        private System.Windows.Forms.ComboBox cmbResourceType;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnGetResource;
        private System.Windows.Forms.DataGridView dgvLoans;
        private System.Windows.Forms.Button btnCheckoutResource;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.ComboBox cmbItemsToCheckout;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnRemoveFromList;
        private System.Windows.Forms.Button btnResetForm;
        private System.Windows.Forms.Label label19;
    }
}