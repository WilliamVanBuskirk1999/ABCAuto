using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model.Entities;

namespace ABCAutoMotive
{
    public partial class OverdueChargesReport : Form
    {
        MainForm myMainForm;
        public OverdueChargesReport(MainForm p)
        {
            myMainForm = p;
            InitializeComponent();
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                OverDueChargeBLL bll = new OverDueChargeBLL();
                dgvCharges.DataSource = bll.GetOverDueCharges();
            }
            catch
            {
                MessageBox.Show("An unknown error has occured, please try again");
            }
        }

        private void btnChargeStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCharges.Rows.Count > 0)
                {
                    //Setting up the list of charges to send to the overdue charges report bll to charge the students
                    List<OverDueCharge> charges = new List<OverDueCharge>();
                    foreach (DataGridViewRow row in dgvCharges.Rows)
                    {
                        OverDueCharge charge = new OverDueCharge()
                        {
                            Price = Convert.ToDecimal(row.Cells["Price"].Value),
                            StudentId = Convert.ToInt32(row.Cells["StudentId"].Value),
                            ResourceId = Convert.ToInt32(row.Cells["ResourceId"].Value)
                        };

                        charges.Add(charge);
                    }

                    OverDueChargeBLL bll = new OverDueChargeBLL();

                    if (bll.ChargeStudent(charges))
                    {
                        MessageBox.Show("Successfully charged students with overdue loans");
                    }
                    else
                    {
                        MessageBox.Show("Failed to charge students with overdue loans");
                    }
                }
                else
                {
                    MessageBox.Show("There is no overdue charges to dispense");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to charge students. Contact an administrator");
            }

        }
    }
}
