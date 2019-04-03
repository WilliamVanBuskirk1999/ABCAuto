using BLL;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Types;

namespace ABCAutoMotive
{
    public partial class CheckInResource : Form
    {
        Resource resource = new Resource();
        Student student = new Student();
        private MainForm myMainForm;
        public CheckInResource(MainForm p)
        {
            myMainForm = p;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoansBLL loanBll = new LoansBLL();
                StudentBLL studentBLL = new StudentBLL();


                List<Loans> loans = new List<Loans>();
                student = studentBLL.GetStudentCheckingInResource(txtSearch.Text);

                //If no student gets returned, set the student to null. If the student is null, the 
                //loans will be null, so the next if will send it to the else
                if (student != null)
                {
                    loans = loanBll.GetListOfLoansForCheckIn(txtSearch.Text, student);
                }

                //Making sure loans exist
                if (loans != null && loans.Count > 0)
                {
                    dgvSearchResults.DataSource = loans;
                    PopulateStudentObject();
                }
                else
                {
                    MessageBox.Show("This resource is not checked out or is an incorrect search. Try again");
                }
            }
            catch
            {
                MessageBox.Show("An unknown error has occured, please try again");
            }


        }
        #region Populating Objects and combo boxes


        /// <summary>
        /// Populating a student object based off a search
        /// </summary>
        private void PopulateStudentObject()
        {

            if (student != null)
            {
                txtAmountDue.Text = student.AmountDue.ToString();
                txtFirstName.Text = student.FirstName;
                txtLastName.Text = student.LastName;
                txtStartDate.Text = student.StartDate.ToLongDateString();
                txtEndDate.Text = student.EndDate.ToLongDateString();

                cmbProgram.SelectedItem = student.Program;
                cmbStudentStatus.SelectedItem = student.Status;
            }
        }
        private void CheckInResource_Load(object sender, EventArgs e)
        {
            //Loading items in the combobox
            cmbProgram.DataSource = Enum.GetValues(typeof(ProgramOptions));
            cmbStudentStatus.DataSource = Enum.GetValues(typeof(StudentStatus));

            //Working with toolstrip
            myMainForm.toolStripStatusLabel2.Text = "Loans Module";
            myMainForm.toolStripStatusLabel3.Text = "Checking in Resources";
        }
        #endregion

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try {
                if (dgvSearchResults.SelectedRows.Count > 0)
                {
                    LoansBLL bll = new LoansBLL();

                    foreach (DataGridViewRow row in dgvSearchResults.SelectedRows)
                    {

                        Loans loan = new Loans()
                        {
                            ResourceId = Convert.ToInt32(row.Cells["ResourceId"].Value),
                            Title = row.Cells["Title"].Value.ToString(),
                            ResourceStatus = (ResourceStatus)0,
                            Type = (ResourceType)row.Cells["Type"].Value,
                            CheckOutDate = Convert.ToDateTime(row.Cells["CheckOutDate"].Value),
                            CheckInDate = DateTime.Now,
                            DueDate = Convert.ToDateTime(row.Cells["DueDate"].Value),
                            StudentId = Convert.ToInt32(row.Cells["StudentId"].Value),
                            LoanStatus = (LoanStatus)1
                        };


                        bll.loans.Add(loan);
                    }

                    int result = bll.CheckInLoans(bll.loans, student);

                    if (result == 1)
                    {
                        MessageBox.Show("Successfully checked in resources");

                        if (dgvSearchResults.Rows.Count == 0)
                        {
                            ClearFields();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to check in resources");
                    }

                    //Rebinding the datagrid view 
                    dgvSearchResults.DataSource = bll.GetListOfLoansForCheckIn(txtSearch.Text, student);
                }

            }
            catch
            {
                MessageBox.Show("An unknown error has occured, please try again");
            }
            

        }

        private void btnReturnDamaged_Click(object sender, EventArgs e)
        {
            try
            {
                LoansBLL bll = new LoansBLL();

                foreach (DataGridViewRow row in dgvSearchResults.SelectedRows)
                {

                    Loans loan = new Loans()
                    {
                        ResourceId = Convert.ToInt32(row.Cells["ResourceId"].Value),
                        Title = row.Cells["Title"].Value.ToString(),
                        ResourceStatus = (ResourceStatus)2,
                        Type = (ResourceType)row.Cells["Type"].Value,
                        CheckOutDate = Convert.ToDateTime(row.Cells["CheckOutDate"].Value),
                        CheckInDate = DateTime.Now,
                        DueDate = Convert.ToDateTime(row.Cells["DueDate"].Value),
                        StudentId = Convert.ToInt32(row.Cells["StudentId"].Value),
                        LoanStatus = (LoanStatus)2,
                        DateRemoved = DateTime.Now

                    };


                    bll.loans.Add(loan);
                }

                int result = bll.CheckInLoans(bll.loans, student);

                if (result == 1)
                {
                    MessageBox.Show("Successfully checked in resources");

                    if (dgvSearchResults.Rows.Count == 0)
                    {
                        ClearFields();
                    }
                }
                else
                {
                    MessageBox.Show("Failed to check in resources");
                }

                //Rebinding the datagrid view 
                dgvSearchResults.DataSource = bll.GetListOfLoansForCheckIn(txtSearch.Text, student);
            }
            catch
            {
                MessageBox.Show("An unknown error has occured, please try again");
            }
        }

        private void btnFlagAsLost_Click(object sender, EventArgs e)
        {
            try
            {
                LoansBLL bll = new LoansBLL();

                foreach (DataGridViewRow row in dgvSearchResults.SelectedRows)
                {

                    Loans loan = new Loans()
                    {
                        ResourceId = Convert.ToInt32(row.Cells["ResourceId"].Value),
                        Title = row.Cells["Title"].Value.ToString(),
                        ResourceStatus = (ResourceStatus)2,
                        Type = (ResourceType)row.Cells["Type"].Value,
                        CheckOutDate = Convert.ToDateTime(row.Cells["CheckOutDate"].Value),
                        DueDate = Convert.ToDateTime(row.Cells["DueDate"].Value),
                        StudentId = Convert.ToInt32(row.Cells["StudentId"].Value),
                        LoanStatus = (LoanStatus)3,
                        DateRemoved = DateTime.Now
                    };


                    bll.loans.Add(loan);
                }

                int result = bll.CheckInLoans(bll.loans, student);

                if (result == 1)
                {
                    MessageBox.Show("Successfully checked in resources");

                    if (dgvSearchResults.Rows.Count == 0)
                    {
                        ClearFields();
                    }
                }
                else
                {
                    MessageBox.Show("Failed to check in resources");
                }

                //Rebinding the datagrid view 
                dgvSearchResults.DataSource = bll.GetListOfLoansForCheckIn(txtSearch.Text, student);
            }
            catch
            {
                MessageBox.Show("An unknown error has occured, please try again");
            }
        }

        private string ReturnChargesMessage(Loans loan)
        {
            string msg = "";

            if (loan.DueDate < DateTime.Now)
            {
                msg += "You have been charged for any late loans";
            }

            return msg;
        }

        private void ClearFields()
        {
            student = new Student();

            txtAmountDue.Text = "";
            txtEndDate.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtStartDate.Text = "";
        }
    }
}
