using BLL;
using Model;
using Model.Lists;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Types;

namespace ABCAutoMotive
{
    public partial class MakePayment : Form
    {
        Student student = new Student();
        MainForm myMainForm;
        public MakePayment(MainForm p)
        {
            myMainForm = p;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "" || txtSearch.Text == null)
            {
                MessageBox.Show("Please enter a search term");
            }
            else
            {
                SearchForStudent();
            }
        }

        /// <summary>
        /// Searching for a student
        /// </summary>
        private void SearchForStudent()
        {
            try
            {
                SearchBLL search = new SearchBLL();

                List<StudentLookup> studentsFromSearch = search.GetStudentList(txtSearch.Text);

                lstSearchResults.DataSource = studentsFromSearch;
                lstSearchResults.DisplayMember = "FullName";
                lstSearchResults.ValueMember = "StudentId";
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                MessageBox.Show("Failed to search for student");
            }

        }

        /// <summary>
        /// Populating the comboboxes on load
        /// </summary>
        private void FillComboBoxes()
        {
            cmbProgram.DataSource = Enum.GetValues(typeof(ProgramOptions));
            cmbStudentStatus.DataSource = Enum.GetValues(typeof(StudentStatus));
        }


        /// <summary>
        /// Fill the fields of the student with the information of the selected student
        /// </summary>
        private void PopulateStudentFields()
        {
            try
            {
                StudentBLL newStudentBLL = new StudentBLL();


                //Making sure the user has selected a person from the list of names
                if (lstSearchResults.SelectedIndex != -1)
                {
                    //Get the student for the retrieve
                    student = newStudentBLL.GetStudent(lstSearchResults.SelectedValue.ToString());
                }
                else
                {
                    MessageBox.Show("Please select a student from the list");
                }



                //If the retrieved student is null, just put in blank values
                if (student.StudentId != 0)
                {
                    txtFirstName.Text = student.FirstName;
                    txtLastName.Text = student.LastName;
                    cmbProgram.SelectedItem = student.Program;
                    cmbStudentStatus.SelectedItem = student.Status;
                    txtAmountDue.Text = student.AmountDue.ToString();

                    txtStartDate.Text = student.StartDate.ToLongDateString();
                    txtEndDate.Text = student.EndDate.ToLongDateString();
                }
                else
                {

                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    cmbProgram.SelectedItem = "";
                    cmbStudentStatus.SelectedItem = "";
                    txtAmountDue.Text = "";

                    txtStartDate.Text = "";
                    txtEndDate.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnGetStudent_Click(object sender, EventArgs e)
        {
            PopulateStudentFields();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (student.StudentId != 0)
                {
                    StudentBLL bll = new StudentBLL();

                    //Ensuring the amount entered is a decimal
                    if (decimal.TryParse(txtPaymentAmount.Text, out decimal amount) == true)
                    {
                        //If the amount trying to be paid is less than the student owes, continue
                        if (amount <= student.AmountDue)
                        {
                            int result = bll.MakePayment(student, amount);

                            //If the student amount due is updated, and the payments table has a value inserted, indicate successful payment
                            if (result == 2)
                            {
                                MessageBox.Show("Your payment has been made");
                                RefreshStudent();

                            }
                            else
                            {
                                MessageBox.Show("The payment has failed. Please try again. If this persists, contact an admin");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please ensure that the amount being paid is not more than the amount due");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ensure that you have entered a decimal value for a payment amount");
                    }
                }
                else
                {
                    MessageBox.Show("Please ensure you have selected a student");
                }
            }
            catch
            {
                MessageBox.Show("An unknown error has occured, please try again");
            }

            
        }

        private void MakePayment_Load(object sender, EventArgs e)
        {
            FillComboBoxes();
        }

        /// <summary>
        /// When a payment is made, refresh student info
        /// </summary>
        private void RefreshStudent()
        {
            StudentBLL bll = new StudentBLL();

            student = bll.GetStudent(student.StudentId.ToString());

            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            cmbProgram.SelectedItem = student.Program;
            cmbStudentStatus.SelectedItem = student.Status;
            txtAmountDue.Text = student.AmountDue.ToString();

            txtStartDate.Text = student.StartDate.ToLongDateString();
            txtEndDate.Text = student.EndDate.ToLongDateString();
        }
    }
}
