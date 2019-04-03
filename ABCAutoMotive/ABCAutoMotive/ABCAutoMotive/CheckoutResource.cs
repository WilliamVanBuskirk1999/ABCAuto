using BLL;
using Model;
using Model.Entities;
using Model.Lists;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Types;

namespace ABCAutoMotive
{
    public partial class CheckoutResource : Form
    {
        //Setting a search business logic layer with a list that will fill with items I want to checkout
        LoansBLL add = new LoansBLL();
        Student student = new Student();
        Resource resource = new Resource();

        private MainForm myMainForm;
        public CheckoutResource(MainForm p)
        {
            myMainForm = p;
            InitializeComponent();
        }

        #region Searches
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
        /// Fills a datagridview with the loans when the user does a serch
        /// </summary>
        public void BindDataGridView()
        {
            try
            {
                LoansBLL bl = new LoansBLL();
                dgvLoans.DataSource = bl.RetrieveLoans(student);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to get Loans");
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

                if (studentsFromSearch.Count > 0)
                {
                    lstSearchResults.DataSource = studentsFromSearch;
                    lstSearchResults.DisplayMember = "FullName";
                    lstSearchResults.ValueMember = "StudentId";
                }
                else
                {
                    MessageBox.Show("No results for that search. Try something else");
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                MessageBox.Show("Failed to search for student");
            }

        }

        /// <summary>
        /// Searching for a resource
        /// </summary>
        private void SearchForResource()
        {
            try
            {
                SearchBLL searchForResource = new SearchBLL();

                List<ResourceLookup> resources = searchForResource.GetResourceList(txtResourceSearch.Text);

                if (resources.Count > 0)
                {
                    lstResourceSearchResults.DataSource = resources;
                    lstResourceSearchResults.ValueMember = "ResourceId";
                    lstResourceSearchResults.DisplayMember = "Title";
                }
                else
                {
                    MessageBox.Show("There is no results for that search");
                }
            }
            catch
            {
                MessageBox.Show("Failed to search for resource");
            }
        }

        #endregion

        #region Comboboxes
        /// <summary>
        /// Filling the comboboxes with enum values
        /// </summary>
        private void FillComboBoxes()
        {
            cmbProgram.DataSource = Enum.GetValues(typeof(ProgramOptions));
            cmbStudentStatus.DataSource = Enum.GetValues(typeof(StudentStatus));
            cmbReserveStatus.DataSource = Enum.GetValues(typeof(ReserveStatus));
            cmbResourceStatus.DataSource = Enum.GetValues(typeof(ResourceStatus));
            cmbResourceType.DataSource = Enum.GetValues(typeof(ResourceType));
        }

        /// <summary>
        /// On load, fill the comboboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckoutResource_Load(object sender, EventArgs e)
        {
            FillComboBoxes();

           
        }
        #endregion

        #region Populating Objects
      

        /// <summary>
        /// Populates text and combo boxes with info of the resource
        /// </summary>
        private void PopulateResourceFields()
        {
            try
            {
                ResourceBLL newResourceBLL = new ResourceBLL();

                //If the selected index of the listbox is -1, don't try to search
                Resource retrieved = null;

                if (lstResourceSearchResults.SelectedIndex != -1)
                {
                    //Get the resource based on the selecteditem
                    retrieved = newResourceBLL.GetResource(lstResourceSearchResults.SelectedValue.ToString());
                }

                if (retrieved != null)
                {
                    txtTitle.Text = retrieved.Title;
                    cmbReserveStatus.SelectedItem = retrieved.ReserveStatus;
                    cmbResourceStatus.SelectedItem = retrieved.ResourceStatus;
                    cmbResourceType.SelectedItem = retrieved.Type;
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
        /// Populates the required resource object properties
        /// </summary>
        private void PopulateResourceObject()
        {
            try
            {
                resource = new Resource();
                resource.ResourceId = Convert.ToInt32(lstResourceSearchResults.SelectedValue);
                resource.ReserveStatus = (ReserveStatus)cmbReserveStatus.SelectedItem;
                resource.Title = txtTitle.Text;
                resource.Type = (ResourceType)cmbResourceType.SelectedItem;
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to populate resource object");
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
                student.Address = txtAddress.Text;
                student.AmountDue = Convert.ToDecimal(txtBalanceDue.Text);
                student.Program = (ProgramOptions)cmbProgram.SelectedValue;
                student.City = txtCity.Text;
                student.StartDate = dtpStartDate.Value;
                student.EndDate = dtpEndDate.Value;
                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                student.Status = (StudentStatus)cmbStudentStatus.SelectedValue;
                student.TelephoneNumber = txtTelephoneNumber.Text;
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
                    txtAddress.Text = retrievedStudent.Address;
                    txtBalanceDue.Text = retrievedStudent.AmountDue.ToString();
                    txtCity.Text = retrievedStudent.City;
                    txtFirstName.Text = retrievedStudent.FirstName;
                    txtLastName.Text = retrievedStudent.LastName;
                    cmbProgram.SelectedItem = retrievedStudent.Program;
                    cmbStudentStatus.SelectedItem = retrievedStudent.Status;
                    txtTelephoneNumber.Text = retrievedStudent.TelephoneNumber;

                    dtpStartDate.Value = retrievedStudent.StartDate;
                    dtpEndDate.Value = retrievedStudent.EndDate;
                }
                else
                {
                    txtAddress.Text = "";
                    txtBalanceDue.Text = "";
                    txtCity.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    cmbProgram.SelectedItem = "";
                    cmbStudentStatus.SelectedItem = "";
                    txtTelephoneNumber.Text = "";

                    dtpStartDate.Value = DateTime.Now;
                    dtpEndDate.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion


        #region Search Buttons and Retrieve info buttons
        private void btnGetStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSearchResults.SelectedItem != null && lstSearchResults.SelectedIndex != -1)
                {
                    panel1.Visible = true;
                    PopulateStudentFields();
                    PopulateStudentObject();
                    BindDataGridView();

                    btnGetStudent.Enabled = false;
                    btnSearch.Enabled = false;

                    //Enabling a form reset
                    btnResetForm.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please select a student from the list");

                }
            }
            catch
            {

            }
        }

        private void btnSearchForResource_Click(object sender, EventArgs e)
        {
            if (txtResourceSearch.Text == "" || txtResourceSearch.Text == null)
            {
                MessageBox.Show("Please enter something to search for");
            }
            else
            {
                SearchForResource();
            }
        }

        private void btnGetResource_Click(object sender, EventArgs e)
        {
            if (lstResourceSearchResults.SelectedItem != null && lstResourceSearchResults.SelectedIndex != -1)
            {
                PopulateResourceFields();
                PopulateResourceObject();
            }
            else
            {
                MessageBox.Show("Please select a resource from the list");
            }
        }


        #endregion

        #region Checkout
        /// <summary>
        /// Checks out the resource the student has selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckoutResource_Click(object sender, EventArgs e)
        {
            try
            {
                if (student.StudentId == 0 || resource.ResourceId == 0)
                {
                    MessageBox.Show("Ensure you have selected a student and a resource");
                }
                else
                {
                    string msg = "";
                    ResourceBLL resourceBl = new ResourceBLL();

                    int result = resourceBl.CheckOutResource(student, add.loans,resource);

                    //If the loans are added successfully, bind the datagrid view and show a success message
                    if (result > 0)
                    {
                        MessageBox.Show("Success! These resources have been checked out");
                        BindDataGridView();

                        //Reenabling student search and get
                        btnSearch.Enabled = true;
                        btnGetStudent.Enabled = true;

                        //Clearing the list of resources
                        ClearListsAndObjects();
                    }
                    else
                    {
                        foreach (ValidationError error in resourceBl.ResourceErrors)
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
                MessageBox.Show("Failed to checkout resource unknown error");
            }
        }

        #endregion

        /// <summary>
        /// Adds a resource to the list of resources to be checked out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToList_Click(object sender, EventArgs e)
        {
            try
            {
                //Clearing the current error list 
                add.errors.Clear();
                //Ensuring a student and resource are selected
                if (resource.ResourceId != 0 && student.StudentId != 0)
                {
                    student.StudentId.ToString();
                    resource.ResourceId.ToString();
                    //Set a boolean to check for success
                    bool result = add.AddToLoansList(resource, student);

                    //Setting up a message to display to the user
                    string msg = "";
                    //If the result comes back true, add to the list. Else display validation Errors
                    if (result)
                    {
                        List<Loans> list = add.loans;

                        //Clearing the datasource
                        cmbItemsToCheckout.DataSource = null;

                        //Resetting datasource
                        cmbItemsToCheckout.DataSource = list;
                        cmbItemsToCheckout.ValueMember = "ResourceId";
                        cmbItemsToCheckout.DisplayMember = "Title";
                    }
                    else
                    {
                        //Looping through errors
                        foreach(ValidationError error in add.errors)
                        {
                            msg += error.Message + Environment.NewLine;
                        }

                        //Displaying the errors in a message box
                        MessageBox.Show(msg);
                    }


                }
                else
                {
                    MessageBox.Show("Ensure you have selected a resource and a student");
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                MessageBox.Show("An unknwon error has occurred adding this resource to the list of resources to be checked out");
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
            lstResourceSearchResults.DataSource = null;
            lstSearchResults.DataSource = null;

            //Clearing the list of resources to be checked out
            add.loans = null;
            add.loans = new List<Loans>();

            //Clearing the comboboxes datasource
            cmbItemsToCheckout.DataSource = null;

            //Resetting resource fields
            PopulateResourceFields(); 
            PopulateStudentFields();


            //Clearing textboxes
            txtSearch.Text = "";
            txtResourceSearch.Text = "";

            //Reset buttons
            btnGetStudent.Enabled = true;
            btnSearch.Enabled = true;

        }

        /// <summary>
        /// Remove the item from the list of items to be checked out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveFromList_Click(object sender, EventArgs e)
        {
            //If there is loans, you may remove
            if (add.loans.Count != 0)
            {
                add.RemoveFromLoansList(cmbItemsToCheckout.SelectedIndex);

                //Refreshing loans dropbox
                List<Loans> list = add.loans;

                //Clearing the datasource
                cmbItemsToCheckout.DataSource = null;

                cmbItemsToCheckout.DataSource = list;
                cmbItemsToCheckout.ValueMember = "ResourceId";
                cmbItemsToCheckout.DisplayMember = "Title";
            }
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ClearListsAndObjects();
        }
    }
}
