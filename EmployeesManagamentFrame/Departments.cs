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
    public partial class Departments : Form
    {
        public Departments()
        {
            InitializeComponent();
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.dataSet.Employees);
            // TODO: This line of code loads data into the 'dataSet.Departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.dataSet.Departments);

        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                // Save changes with the Inventory table back to the database.    
                departmentsTableAdapter.Update(this.dataSet.Departments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // Get fresh copy for grid.
            departmentsTableAdapter.Fill(this.dataSet.Departments);
        }
    }
}
