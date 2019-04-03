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

namespace ABCAutoMotive
{
   
    public partial class AddResource : Form
    {
        private string selectedFile = "";
        Resource resource = new Resource();

        MainForm myMainForm;
        public AddResource(MainForm p)
        {
            myMainForm = p;
            InitializeComponent();
        }

        private void PopulateResourceObject()
        {
            resource = new Resource();
            resource.Title = txtTitle.Text;
            resource.ResourceStatus = (ResourceStatus)cmbResourceStatus.SelectedItem;
            
            if(decimal.TryParse(txtPrice.Text, out decimal i) == true)
            {
                resource.Price = i;
            }

            resource.Publisher = txtPublisherName.Text;
            resource.DateAdded = dtpDateOfPurchase.Value;
            resource.Description = txtDescription.Text;
            resource.Type = (ResourceType)cmbResourceType.SelectedItem;
            resource.Image = selectedFile;
            
            if(int.TryParse(txtPublisherReferenceNum.Text, out int x) == true)
            {
                resource.PublisherReferenceNumber = (PublisherReferenceNum)x;
            }


            

           
        }

        /// <summary>
        /// Filling the comboboxes with enum values
        /// </summary>
        private void FillComboBoxes()
        {
            cmbResourceStatus.DataSource = Enum.GetValues(typeof(ResourceStatus));
            cmbResourceType.DataSource = Enum.GetValues(typeof(ResourceType));
        }

        private void btnAddResource_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateResourceObject();
                ResourceBLL bll = new ResourceBLL();

                if (bll.AddResource(resource) == 1)
                {
                    MessageBox.Show("Successfully added resource!");
                    ClearFields();
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
            catch
            {
                MessageBox.Show("An unknown error has occured, please try again");
            }
        }

        private void AddResource_Load(object sender, EventArgs e)
        {
            FillComboBoxes();
            myMainForm.toolStripStatusLabel2.Text = "Resource Module";
            myMainForm.toolStripStatusLabel3.Text = "Adding a resource";
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            string imgPath = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openFileDialog1.Filter = "Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF";
                if (openFileDialog1.FileNames.Length == 1)
                {
                    selectedFile = openFileDialog1.SafeFileName;
                }
                else
                {
                    selectedFile = openFileDialog1.SafeFileName;
                }

                imgPath = openFileDialog1.FileName;
            }

            pictureBox1.Image = Image.FromFile(imgPath);
        }

        /// <summary>
        /// Clearing the fields after a successful add
        /// </summary>
        private void ClearFields()
        {
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtPublisherName.Text = "";
            txtPublisherReferenceNum.Text = "";
            txtTitle.Text = "";
            selectedFile = "";

            pictureBox1.Image = null;


            
        }
    }
}
