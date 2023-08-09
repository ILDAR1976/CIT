using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

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

        private int getDepartmentIdByName(string name)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            int ret = 0;

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("",connection);

                SqlCommand command = new SqlCommand("SELECT " +
                  "ID " +
                  "FROM dbo.Departments " +
                  "WHERE Name = @Name",
                  connection);
                
                command.Parameters.AddWithValue("@Name", name);
                dataAdapter.SelectCommand = command;
                connection.Open();
                SqlDataReader result = command.ExecuteReader();
                
                if (result.Read())
                    ret = int.Parse(result["ID"].ToString());
                else
                    ret = 0;
                dataAdapter.SelectCommand.Connection.Close();
            }
            return ret;
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

            if (getFormByName("BaseReport") == null)
                this.mainToolStripMenuItem.Enabled = true;
            else
                this.mainToolStripMenuItem.Enabled = false;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            dataOpenFileDialog.Filter = "Text files (*.xlsx)|*.xlsx";
            dataOpenFileDialog.Title = "Open .xlsx file";
            if (dataOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                XSSFWorkbook wb;
                XSSFSheet sh;
                String Sheet_name_1;
                String Sheet_name_2;
                String Path = dataOpenFileDialog.FileName;
                int DATATYPE = 14;


                using (var fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    wb = new XSSFWorkbook(fs);

                    Sheet_name_1 = wb.GetSheetAt(0).SheetName;
                    Sheet_name_2 = wb.GetSheetAt(1).SheetName;
                }
 
                sh = (XSSFSheet)wb.GetSheet(Sheet_name_2);
                
                using (SqlConnection connection =
                           new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("", connection);

                    int i = 0;
                    while (sh.GetRow(i) != null)
                    {
                        

                        SqlCommand command = new SqlCommand(
                           "INSERT INTO dbo.Departments (Name, ParentDepartmentID, ManagerID, Status) VALUES " +
                           "(@Name, NULLIF(@ParentDepartmentID, ''), NULL, @Status);"
                          , connection);

                        for (int j = 0; j < sh.GetRow(i).Cells.Count; j++)
                        {
                            var cell = sh.GetRow(i).GetCell(j);

                            if (cell != null && i != 0)
                            {
                                switch (cell.CellType)
                                {
                                    case NPOI.SS.UserModel.CellType.Blank:
                                        switch (j)
                                        {
                                            case 2:
                                                command.Parameters.AddWithValue("@ParentDepartmentID", "");
                                                break;
                                        }
                                        break;
                                   
                                    case NPOI.SS.UserModel.CellType.String:
                                        switch (j)
                                        {
                                            case 1:
                                                command.Parameters.AddWithValue("@Name", sh.GetRow(i).GetCell(j).StringCellValue);
                                                break;
                                            case 2:
                                                command.Parameters.AddWithValue("@ParentDepartmentID", getDepartmentIdByName(sh.GetRow(i).GetCell(j).StringCellValue));
                                                break;
                                        }
                                        break;
                                }
                            }
                        }

                        if (i != 0)
                        {
                            command.Parameters.AddWithValue("@Status", "Active");
                            dataAdapter.InsertCommand = command;
                            dataAdapter.InsertCommand.Connection.Open();
                            dataAdapter.InsertCommand.ExecuteNonQuery();
                            dataAdapter.InsertCommand.Connection.Close();
                        }
                        i++;
                    }

                    sh = (XSSFSheet)wb.GetSheet(Sheet_name_1);

                    i = 0;
                    while (sh.GetRow(i) != null)
                    {
                        
                        
                        SqlCommand command = new SqlCommand(
                           "INSERT INTO dbo.Employees (Name, EmployeeNumber, Position, DepartmentID, Email, Phone, HireDate, TerminationDate, Status) VALUES " +
                           "(@Name, @EmployeeNumber, @Position, @DepartmentID, @Email, @Phone, @HireDate, @TerminationDate, @Status);"
                          , connection);

                        for (int j = 0; j < sh.GetRow(i).Cells.Count; j++)
                        {
                            var cell = sh.GetRow(i).GetCell(j);

                            if (cell != null && i != 0)
                            {
                                switch (cell.CellType)
                                {
                                    case NPOI.SS.UserModel.CellType.Blank:
                                        switch (j)
                                        {
                                            case 7:
                                                command.Parameters.AddWithValue("@HireDate", "");
                                                break;
                                            case 8:
                                                command.Parameters.AddWithValue("@TerminationDate", "");
                                                break;
                                        }
                                        break;

                                    case NPOI.SS.UserModel.CellType.Numeric:
                                        if (cell.CellStyle.DataFormat == DATATYPE)
                                        {
                                            switch (j)
                                            {
                                                case 7:
                                                    command.Parameters.AddWithValue("@HireDate", sh.GetRow(i).GetCell(j).DateCellValue);
                                                    break;
                                                case 8:
                                                    command.Parameters.AddWithValue("@TerminationDate", sh.GetRow(i).GetCell(j).DateCellValue);
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                           
                                            switch (j)
                                            {
                                                case 2:
                                                    command.Parameters.AddWithValue("@EmployeeNumber", sh.GetRow(i).GetCell(j).NumericCellValue);
                                                    break;
                                               
                                            }
                                        }
                                        break;
                                    case NPOI.SS.UserModel.CellType.String:
                                        
                                        switch (j)
                                        {
                                            case 1:
                                                command.Parameters.AddWithValue("@Name", sh.GetRow(i).GetCell(j).StringCellValue); 
                                                break;
                                            case 3:
                                                command.Parameters.AddWithValue("@Position", sh.GetRow(i).GetCell(j).StringCellValue);
                                                break;
                                            case 4:
                                                command.Parameters.AddWithValue("@DepartmentID", getDepartmentIdByName(sh.GetRow(i).GetCell(j).StringCellValue));
                                                break;
                                            case 5:
                                                command.Parameters.AddWithValue("@Email", sh.GetRow(i).GetCell(j).StringCellValue);
                                                break;
                                            case 6:
                                                command.Parameters.AddWithValue("@Phone", sh.GetRow(i).GetCell(j).StringCellValue);
                                                break;
                                        }
                                        break;

                                }

                                
                            }
                        }

                        if (i != 0) {
                            command.Parameters.AddWithValue("@Status", "Active");
                            dataAdapter.InsertCommand = command;
                            dataAdapter.InsertCommand.Connection.Open();
                            dataAdapter.InsertCommand.ExecuteNonQuery();
                            dataAdapter.InsertCommand.Connection.Close();
                        }
                        i++;
                    }
                }
            }

            MessageBox.Show("The data loaded", "Result message");
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getFormByName("BaseReport") == null)
            {
                BaseReport form = new BaseReport();
                form.Name = "BaseReport";
                form.MdiParent = this;
                form.Show();
                this.mainToolStripMenuItem.Enabled = false;
            }
        }
    }
}
