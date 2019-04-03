using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Types;
using BLL;
using Model.Lists;

namespace ABCAutoMotive
{
    public partial class ReserveResource : Form
    {
        Student student = new Student();
        Resource resource = new Resource();

        MainForm myMainForm;
        public ReserveResource(MainForm p)
        {
            myMainForm = p;
            InitializeComponent();
        }

        private void ReserveResource_Load(object sender, EventArgs e)
        {
            FillComboBoxes();
        }

        private void FillComboBoxes()
        {
            cmbProgram.DataSource = Enum.GetValues(typeof(ProgramOptions));
            cmbStudentStatus.DataSource = Enum.GetValues(typeof(StudentStatus));
            cmbReserveStatus.DataSource = Enum.GetValues(typeof(ReserveStatus));
            cmbResourceStatus.DataSource = Enum.GetValues(typeof(ResourceStatus));
            cmbResourceType.DataSource = Enum.GetValues(typeof(ResourceType));
        }
        #region Entities
        private void PopulateResourceFields()
        {
            try
            {
                ResourceBLL newResourceBLL = new ResourceBLL();

                //If the selected index of the listbox is -1, don't try to search
               

                if (txtResourceSearch.Text != "")
                {
                    //Get the resource based on the selecteditem
                    resource = newResourceBLL.GetResource(txtResourceSearch.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a search term");
                }

                if (resource != null)
                {
                    txtTitle.Text = resource.Title;
                    cmbReserveStatus.SelectedItem = resource.ReserveStatus;
                    cmbResourceStatus.SelectedItem = resource.ResourceStatus;
                    cmbResourceType.SelectedItem = resource.Type;
                }
                else
                {

                    txtTitle.Text = "";
                    cmbReserveStatus.SelectedItem = "";
                    cmbResourceStatus.SelectedItem = "";
                    cmbResourceType.SelectedItem = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to get info on that resource");
            }
        }

        /// <summary>
        /// Populates the student object with the textbox info
        /// </summary>
        private void PopulateStudentObject()
        {
            try
            {
                student = new Student();
                student.AmountDue = Convert.ToDecimal(txtAmountDue.Text);
                student.Program = (ProgramOptions)cmbProgram.SelectedValue;
                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                student.Status = (StudentStatus)cmbStudentStatus.SelectedValue;
                student.StudentId = Convert.ToInt32(lstSearchResults.SelectedValue);
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
                    txtFirstName.Text = retrievedStudent.FirstName;
                    txtLastName.Text = retrievedStudent.LastName;
                    cmbProgram.SelectedItem = retrievedStudent.Program;
                    txtAmountDue.Text = retrievedStudent.AmountDue.ToString();
                    cmbStudentStatus.SelectedItem = retrievedStudent.Status;


                    txtStartDate.Text = retrievedStudent.StartDate.ToLongDateString();
                    txtEndDate.Text = retrievedStudent.EndDate.ToLongDateString();
                }
                else
                {            
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    cmbProgram.SelectedItem = "";
                    cmbStudentStatus.SelectedItem = "";


                    txtStartDate.Text = "";
                    txtEndDate.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Searches
        private void btnSearchResource_Click(object sender, EventArgs e)
        {
            PopulateResourceFields();
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            if (txtStudentSearch.Text == "" || txtStudentSearch.Text == null)
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

                List<StudentLookup> studentsFromSearch = search.GetStudentList(txtStudentSearch.Text);

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

        #endregion

        /// <summary>
        /// Retrieves student info based off the student selected in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetStudent_Click(object sender, EventArgs e)
        {
            PopulateStudentFields();
            PopulateStudentObject();
        }

        /// <summary>
        /// Reserve a resource 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReserve_Click(object sender, EventArgs e)
        {
            try
            {
                //Ensuring we have a valid student and resource
                if (student != null && resource != null && student.StudentId != 0 && resource.ResourceId != 0)
                {
                    ResourceBLL bll = new ResourceBLL();

                    if (bll.ReserveResource(student, resource) == 1)
                    {
                        MessageBox.Show("Resource has been successfully reserved");
                        ClearListsAndObjects();
                    }
                    else
                    {
                        string msg = "";

                        foreach (ValidationError error in bll.ResourceErrors)
                        {
                            msg += error.Message + Environment.NewLine;
                        }

                        MessageBox.Show(msg);
                    }
                }
                else
                {
                    MessageBox.Show("Please ensure you have selected both a student and a resource");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An unknown error has occured. Please contact an administrator");
            }
        }


        /// <summary>
        /// Cleanup form elements that are filled in
        /// </summary>
        private void ClearListsAndObjects()
        {
            //Setting the student and resource to null 
            student = null;
            resource = null;

            //Clearing the list boxes
            lstSearchResults.DataSource = null;

            

            //Resetting resource fields
            PopulateResourceFields();
            PopulateStudentFields();


            //Clearing textboxes
            txtStudentSearch.Text = "";
            txtResourceSearch.Text = "";

            //Reset buttons
            btnGetStudent.Enabled = true;
        

        }
    }
}
