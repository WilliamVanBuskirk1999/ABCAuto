using BLL;
using Model;
using Model.Lists;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Types;

namespace ABCAutoMotive
{
    public partial class StudentAccountInfo : Form
    {
        Student student = new Student();

        MainForm myMainForm;
        public StudentAccountInfo(MainForm p)
        {
            myMainForm = p;
            InitializeComponent();
        }

        private void StudentAccountInfo_Load(object sender, EventArgs e)
        {
            SetButtonStates(true);
            FillComboBoxes();
        }

        #region Populating Objects
        /// <summary>
        /// Populate the student object with new student info
        /// </summary>
        private void PopulateNewStudentObject()
        {
            //Making the student a new student
            student = new Student();
            try
            {
                student.Address = txtAddress.Text;
                student.Program = (ProgramOptions)cmbProgram.SelectedValue;
                student.City = txtCity.Text;
                student.AmountDue = 0;
                student.StartDate = dtpStartDate.Value;
                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                student.Status = (StudentStatus)cmbStudentStatus.SelectedValue;

                string phoneNumber = txtTelephoneNumber.Text.Replace("-", "").Replace("(","").Replace(")","");

                student.TelephoneNumber = phoneNumber;
                student.PostalCode = txtPostalCode.Text;
                student.EndDate = dtpEndDate.Value;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to populate student object");
            }
        }
        /// <summary>
        /// Populates the student object with the textbox info when searching for a student
        /// </summary>
        private void PopulateStudentObject()
        {
            try
            {
                student.Address = txtAddress.Text;
                student.Program = (ProgramOptions)cmbProgram.SelectedValue;
                student.City = txtCity.Text;
                student.AmountDue = 0;
                student.StartDate = dtpStartDate.Value;
                student.EndDate = dtpEndDate.Value;
                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                student.Status = (StudentStatus)cmbStudentStatus.SelectedValue;

                string phoneNumber = txtTelephoneNumber.Text.Replace("-", "").Replace("(", "").Replace(")", "");

                student.TelephoneNumber = phoneNumber;
                student.StudentId = Convert.ToInt32(lstSearchResults.SelectedValue);
                student.PostalCode = txtPostalCode.Text;
            }
            catch
            {
                MessageBox.Show("Failed to populate student object");
            }
        }
        /// <summary>
        /// Fill the fields of the student with the information of the selected student
        /// </summary>
        private void PopulateStudentFields()
        {
            try
            {
                StudentBLL newStudentBLL = new StudentBLL();

                //If there is no selected student, do not retrieve
                Student retrievedStudent = null;

                if (lstSearchResults.SelectedIndex != -1)
                {
                    //Get the student for the retrieve
                    retrievedStudent = newStudentBLL.GetStudent(lstSearchResults.SelectedValue.ToString());
                }


                //If the retrieved student is null, just put in blank values
                if (retrievedStudent != null)
                {
                    txtStudentId.Text = retrievedStudent.StudentId.ToString();
                    txtAddress.Text = retrievedStudent.Address;
                    txtCity.Text = retrievedStudent.City;
                    txtFirstName.Text = retrievedStudent.FirstName;
                    txtLastName.Text = retrievedStudent.LastName;
                    cmbProgram.SelectedItem = retrievedStudent.Program;
                    cmbStudentStatus.SelectedItem = retrievedStudent.Status;
                    txtTelephoneNumber.Text = retrievedStudent.TelephoneNumber;
                    txtPostalCode.Text = retrievedStudent.PostalCode;

                    dtpStartDate.Value = retrievedStudent.StartDate;
                    dtpEndDate.Value = retrievedStudent.EndDate;

                    SetButtonStates(false);
                }

                //Setting the student object equal to the retrieved student
                student = retrievedStudent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Filling the comboboxes with enum values
        /// </summary>
        private void FillComboBoxes()
        {
            cmbProgram.DataSource = Enum.GetValues(typeof(ProgramOptions));
            cmbStudentStatus.DataSource = Enum.GetValues(typeof(StudentStatus));
        }
        #endregion

        #region Search Functions
        /// <summary>
        /// When clicked searches for student based on a search parameter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void btnGetStudent_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateStudentFields();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region House Keeping
        private void SetButtonStates(bool state)
        {
            //Enabled by default
            btnAdd.Enabled = state;

            //When the state is set to false, enable these buttons
            btnDelete.Enabled = !state;
            btnUpdate.Enabled = !state;
            btnCancel.Enabled = !state;


            if (state)
            {
                // Toolstrip setup
                myMainForm.toolStripStatusLabel3.Text = "Add a student";
            }
            else
            {
                // Toolstrip setup
                myMainForm.toolStripStatusLabel3.Text = "Edit or Delete a Student";
            }
           

        }

        #endregion

        #region Adding a student
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateNewStudentObject();
                StudentBLL bll = new StudentBLL();
                if (bll.AddStudent(student) > 0)
                {
                    MessageBox.Show("The student was successfully inserted");
                    ClearFields();
                }
                else
                {
                    string msg = "";
                    foreach (ValidationError error in bll.errors)
                    {
                        msg += error.Message + Environment.NewLine;
                    }
                    MessageBox.Show(msg);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            //Resetting the buttons
            SetButtonStates(true);

            //Setting the student and resource to null 
            student = null;

            //Clearing the list boxes
            lstSearchResults.DataSource = null;


            //Clearing textboxes
            txtSearch.Text = "";

            txtAddress.Text = "";
            txtCity.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPostalCode.Text = "";
            txtSearch.Text = "";
            txtStudentId.Text = "";
            txtTelephoneNumber.Text = "";

            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;


            // Toolstrip setup
            myMainForm.toolStripStatusLabel3.Text = "Add a student";



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                StudentBLL bll = new StudentBLL();

                DialogResult confirmDelete = MessageBox.Show("Are you sure you would like to delete this record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                //If the user confirms delete, attempt to perform a delete
                if (confirmDelete == DialogResult.Yes)
                {

                    //Peforming Delete
                    if (bll.DeleteStudent(student) > 0)
                    {
                        MessageBox.Show("This student has been deleted!");
                        ResetForm();
                    }
                    else
                    {
                        string msg = "";
                        foreach (ValidationError error in bll.errors)
                        {
                            msg += error.Message + Environment.NewLine;
                        }
                        MessageBox.Show(msg);
                    }
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                MessageBox.Show("An unknown error has occured while attempting to delete a student. Please contact an administrator");
            }
           
        }

        /// <summary>
        /// When clicked will update student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                StudentBLL bll = new StudentBLL();

                PopulateStudentObject();

                if (bll.UpdateStudent(student) > 0)
                {
                    PopulateStudentObject();
                    MessageBox.Show("Student successfully updated!");
                }
                else
                {
                    string msg = "";

                    foreach(ValidationError error in bll.errors)
                    {
                        msg += error.Message + Environment.NewLine;
                    }
                    MessageBox.Show(msg);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ClearFields()
        {
            student = new Student();

            txtAddress.Text = "";
            txtCity.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPostalCode.Text = "";
            txtTelephoneNumber.Text = "";
        }
    }
}