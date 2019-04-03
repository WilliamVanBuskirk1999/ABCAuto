using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MdiTabControl;

namespace ABCAutoMotive
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Forms
        CheckoutResource newCheckout;
        CheckInResource newCheckin;
        StudentAccountInfo newStudentsAccount;
        ReserveResource newReserveResource;
        ModifyResourceStatus newModifyResourceStatus;
        MakePayment newMakePayment;
        AddResource newAddResource;
        OverdueChargesReport newOverdueChargesReport;
        #endregion 
        private void MainForm_Load(object sender, EventArgs e)
        {
            Splash newSplash = new Splash();
            newSplash.ShowDialog();

            Login newLogin = new Login();
            newLogin.ShowDialog();

            if (newLogin.DialogResult == DialogResult.Cancel)
            {
                this.Close();
            }

                SetUpStatusStrip();
            
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                if (newCheckout == null || newCheckout.IsDisposed)
                {
                    newCheckout = new CheckoutResource(this);

                    newCheckout.Visible = true;

                    //Toolstrip setup
                    toolStripStatusLabel2.Text = "Loans Module";
                    toolStripStatusLabel3.Text = "Checkout Resources";
                }

                if (tabControl1.Contains(newCheckout))
                {
                    tabControl1.TabPages[newCheckout].Select();
                    // Toolstrip setup
                    toolStripStatusLabel2.Text = "Loans Module";
                    toolStripStatusLabel3.Text = "Checkout Resources";
                }
                else
                {
                    tabControl1.TabPages.Add(newCheckout);

                    // Toolstrip setup
                    toolStripStatusLabel2.Text = "Loans Module";
                    toolStripStatusLabel3.Text = "Checkout Resources";
                }
            
        }

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(newCheckin == null || newCheckin.IsDisposed)
            {
                newCheckin = new CheckInResource(this);
                newCheckin.Visible = true;

                // Toolstrip setup
                toolStripStatusLabel2.Text = "Loans Module";
                toolStripStatusLabel3.Text = "Check in Resources";
            }

            if (tabControl1.Contains(newCheckin))
            {
                tabControl1.TabPages[newCheckin].Select();

                // Toolstrip setup
                toolStripStatusLabel2.Text = "Loans Module";
                toolStripStatusLabel3.Text = "Check in Resources";
            }
            else
            {
                tabControl1.TabPages.Add(newCheckin);

                // Toolstrip setup
                toolStripStatusLabel2.Text = "Loans Module";
                toolStripStatusLabel3.Text = "Check in Resources";
            }
        }

        private void editStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AccessLevel == 1)
            {
                if (newStudentsAccount == null || newStudentsAccount.IsDisposed)
                {
                    newStudentsAccount = new StudentAccountInfo(this);
                    newStudentsAccount.Visible = true;

                    // Toolstrip setup
                    toolStripStatusLabel2.Text = "Student Module";
                    toolStripStatusLabel3.Text = "Add a student";
                }

                if (tabControl1.Contains(newStudentsAccount))
                {
                    tabControl1.TabPages[newStudentsAccount].Select();

                    // Toolstrip setup
                    toolStripStatusLabel2.Text = "Student Module";
                    toolStripStatusLabel3.Text = "";
                }
                else
                {
                    tabControl1.TabPages.Add(newStudentsAccount);

                    // Toolstrip setup
                    toolStripStatusLabel2.Text = "Student Module";
                    toolStripStatusLabel3.Text = "";
                }
            }
            else
            {
                MessageBox.Show("You do not have the correct priviledges to enter this module");
            }
        }

        private void reserveResourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(newReserveResource == null || newReserveResource.IsDisposed)
            {
                newReserveResource = new ReserveResource(this);
                newReserveResource.Visible = true;

                // Toolstrip setup
                toolStripStatusLabel2.Text = "Resource Module";
                toolStripStatusLabel3.Text = "Reserve resources";
            }

            if (tabControl1.Contains(newReserveResource))
            {
                tabControl1.TabPages[newReserveResource].Select();
                // Toolstrip setup
                toolStripStatusLabel2.Text = "Resource Module";
                toolStripStatusLabel3.Text = "Reserve resources";
            }
            else
            {
                tabControl1.TabPages.Add(newReserveResource);

                // Toolstrip setup
                toolStripStatusLabel2.Text = "Resource Module";
                toolStripStatusLabel3.Text = "Reserve resources";
            }
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AccessLevel == 1)
            {
                if (newModifyResourceStatus == null || newModifyResourceStatus.IsDisposed)
                {
                    newModifyResourceStatus = new ModifyResourceStatus(this);
                    newModifyResourceStatus.Visible = true;

                    // Toolstrip setup
                    toolStripStatusLabel2.Text = "Resource Module";
                    toolStripStatusLabel3.Text = "Modify Resource";
                }

                if (tabControl1.Contains(newModifyResourceStatus))
                {
                    tabControl1.TabPages[newModifyResourceStatus].Select();


                    // Toolstrip setup
                    toolStripStatusLabel2.Text = "Resource Module";
                    toolStripStatusLabel3.Text = "Modify Resource";
                }
                else
                {
                    tabControl1.TabPages.Add(newModifyResourceStatus);


                    // Toolstrip setup
                    toolStripStatusLabel2.Text = "Resource Module";
                    toolStripStatusLabel3.Text = "Modify Resource";
                }
            }
            else
            {
                MessageBox.Show("You do not have the correct priviledges to enter this module");
            }
        }

        private void makePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (newMakePayment == null || newMakePayment.IsDisposed)
            {
                newMakePayment = new MakePayment(this);
                newMakePayment.Visible = true;


                // Toolstrip setup
                toolStripStatusLabel2.Text = "Student Module";
                toolStripStatusLabel3.Text = "Make Payment";
            }

            if (tabControl1.Contains(newMakePayment))
            {
                tabControl1.TabPages[newMakePayment].Select();
                // Toolstrip setup
                toolStripStatusLabel2.Text = "Student Module";
                toolStripStatusLabel3.Text = "Make Payment";
            }
            else
            {
                tabControl1.TabPages.Add(newMakePayment);
                // Toolstrip setup
                toolStripStatusLabel2.Text = "Student Module";
                toolStripStatusLabel3.Text = "Make Payment";
            }
        }

        private void addResourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AccessLevel == 1)
            {
                if (newAddResource == null || newAddResource.IsDisposed)
                {
                    newAddResource = new AddResource(this);
                    newAddResource.Visible = true;

                    // Toolstrip setup
                    toolStripStatusLabel2.Text = "Resource Module";
                    toolStripStatusLabel3.Text = "Add a Resource";
                }

                if (tabControl1.Contains(newAddResource))
                {
                    tabControl1.TabPages[newAddResource].Select();
                    // Toolstrip setup
                    toolStripStatusLabel2.Text = "Resource Module";
                    toolStripStatusLabel3.Text = "Add a Resource";
                }
                else
                {
                    tabControl1.TabPages.Add(newAddResource);
                    // Toolstrip setup
                    toolStripStatusLabel2.Text = "Resource Module";
                    toolStripStatusLabel3.Text = "Add a Resource";
                }
            }
            else
            {
                MessageBox.Show("You do not have the correct priviledges to enter this module");
            }
        }

        private void SetUpStatusStrip()
        {
            statusStrip1.LayoutStyle = ToolStripLayoutStyle.Table;

            toolStripStatusLabel1.Text = "Welcome, " + Environment.UserName;
            toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
            toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Right;

            toolStripStatusLabel2.Text = "";
            toolStripStatusLabel2.TextAlign = ContentAlignment.MiddleLeft;
            toolStripStatusLabel2.BorderSides = ToolStripStatusLabelBorderSides.Right;


            toolStripStatusLabel3.Text = "";
            toolStripStatusLabel3.TextAlign = ContentAlignment.MiddleLeft;
            toolStripStatusLabel3.BorderSides = ToolStripStatusLabelBorderSides.Right;

            
        }

        private void overdueChargesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (newOverdueChargesReport == null || newOverdueChargesReport.IsDisposed)
            {
                newOverdueChargesReport = new OverdueChargesReport(this);
                newOverdueChargesReport.Visible = true;

                // Toolstrip setup
                toolStripStatusLabel2.Text = "Loans Module";
                toolStripStatusLabel3.Text = "Overdue charges report";
            }

            if (tabControl1.Contains(newOverdueChargesReport))
            {
                tabControl1.TabPages[newOverdueChargesReport].Select();
                // Toolstrip setup
                toolStripStatusLabel2.Text = "Loans Module";
                toolStripStatusLabel3.Text = "Overdue charges report";
            }
            else
            {
                tabControl1.TabPages.Add(newOverdueChargesReport);
                // Toolstrip setup
                toolStripStatusLabel2.Text = "Loans Module";
                toolStripStatusLabel3.Text = "Overdue charges report";
            }
        }
    }
}
