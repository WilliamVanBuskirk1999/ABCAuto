using BLL;
using Model.Entities;
using System;
using System.Windows.Forms;
using Types;

namespace ABCAutoMotive
{
    public partial class ModifyResourceStatus : Form
    {
        Resource resource = new Resource();
        MainForm myMainForm;
        public ModifyResourceStatus(MainForm p)
        {
            myMainForm = p;
            InitializeComponent();
        }

        /// <summary>
        /// Fill the combo boxes with values from the enum
        /// </summary>
        private void FillComboBoxes()
        {
            cmbReserveStatus.DataSource = Enum.GetValues(typeof(ReserveStatus));
            cmbResourceStatus.DataSource = Enum.GetValues(typeof(ResourceStatus));
            cmbType.DataSource = Enum.GetValues(typeof(ResourceType));
            cmbPublisherReference.DataSource = Enum.GetValues(typeof(PublisherReferenceNum));
        }

        private void ModifyResourceStatus_Load(object sender, EventArgs e)
        {
            FillComboBoxes();
        }

        /// <summary>
        /// Populates text and combo boxes with info of the resource
        /// </summary>
        private void PopulateResourceFields()
        {
            try
            {
                ResourceBLL newResourceBLL = new ResourceBLL();

                //Get the resource based on the selecteditem
                resource = new Resource();
                resource = newResourceBLL.GetResourceComplete(txtSearch.Text);


                if (resource != null)
                {
                    txtTitle.Text = resource.Title;
                    txtResourceId.Text = resource.ResourceId.ToString();
                    txtDescription.Text = resource.Description;
                    txtStock.Text = resource.Stock.ToString();
                    cmbReserveStatus.SelectedItem = resource.ReserveStatus;
                    cmbResourceStatus.SelectedItem = resource.ResourceStatus;
                    cmbType.SelectedItem = resource.Type;
                    cmbPublisherReference.SelectedItem = resource.PublisherReferenceNumber;
                }
                else
                {
                    txtTitle.Text = "";
                    txtResourceId.Text = "";
                    txtDescription.Text = "";
                    txtStock.Text = "";
                    cmbReserveStatus.SelectedItem = "";
                    cmbResourceStatus.SelectedItem = "";
                    cmbType.SelectedItem = "";
                    cmbPublisherReference.SelectedItem = "";

                    MessageBox.Show("Cannot find that resource");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to get info on that resource");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateResourceFields();
        }

        /// <summary>
        /// Modify the resource status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyResourceStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (resource.ResourceStatus != (ResourceStatus)1)
                {
                    resource.ResourceStatus = (ResourceStatus)cmbResourceStatus.SelectedItem;
                    ResourceBLL bll = new ResourceBLL();
                    if (resource.ResourceId != 0)
                    {
                        int result = bll.ChangeResourceStatus(resource);

                        if (result == 1)
                        {
                            MessageBox.Show("Successfully changed resource status");
                        }
                        else
                        {
                            string msg = "";
                            foreach(ValidationError error in bll.ResourceErrors)
                            {
                                msg += error.Message + Environment.NewLine;
                            }
                            MessageBox.Show(msg);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please ensure you have selected a resource to modify");
                    }
                }
                else
                {
                    MessageBox.Show("This resource is already on loan and may not have its status modified");
                }
            }
            catch
            {
                MessageBox.Show("An unknown error has occured, please try again");
            }
        }
    }
}
