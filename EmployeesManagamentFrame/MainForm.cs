using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesManagamentFrame
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Form getFormByName(string formName)
        {
            foreach (Form itemForm in this.MdiChildren)
            {
                if (itemForm.Name.Equals(formName)) return itemForm;
            }
            return null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getFormByName("Departments") == null)
            {
                Departments form = new Departments();
                form.Name = "Departments";
                form.MdiParent = this;
                form.Show();
                this.departmentsToolStripMenuItem.Enabled = false;
            }
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getFormByName("Employees") == null)
            {
                Employees form = new Employees();
                form.Name = "Employees";
                form.MdiParent = this;
                form.Show();
                this.employeesToolStripMenuItem.Enabled = false;
            }
        }

        private void mainMenuStrip_Paint(object sender, PaintEventArgs e)
        {
            if (getFormByName("Employees") == null)
                this.employeesToolStripMenuItem.Enabled = true;
            else
                this.employeesToolStripMenuItem.Enabled = false;

            if (getFormByName("Departments") == null)
                this.departmentsToolStripMenuItem.Enabled = true;
            else
                this.departmentsToolStripMenuItem.Enabled = false;
        }
    }
}
