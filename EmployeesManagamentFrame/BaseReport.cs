using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesManagamentFrame
{
    public partial class BaseReport : Form
    {
        public BaseReport()
        {
            InitializeComponent();
        }

        private void BaseReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mainReprotDataSet.Departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.mainReprotDataSet.Departments);

        }
        
        private string encoder(string inp)
        {
            string outStr = @"\f1\lang1049";
            for (int i = 0; i < inp.Length; ++i)
            {
                switch (inp[i])
                {
                    case 'а': //c0 - df
                        outStr += @"\'e0";
                        break;
                    case 'б':
                        outStr += @"\'e1";
                        break;
                    case 'в':
                        outStr += @"\'e2";
                        break;
                    case 'г':
                        outStr += @"\'e3";
                        break;
                    case 'д':
                        outStr += @"\'e4";
                        break;
                    case 'е':
                        outStr += @"\'e5";
                        break;
                    case 'ё':
                        outStr += @"\'b8";
                        break;
                    case 'ж':
                        outStr += @"\'e6";
                        break;
                    case 'з':
                        outStr += @"\'e7";
                        break;
                    case 'и':
                        outStr += @"\'e8";
                        break;
                    case 'й':
                        outStr += @"\'e9";
                        break;
                    case 'к':
                        outStr += @"\'ea";
                        break;
                    case 'л':
                        outStr += @"\'eb";
                        break;
                    case 'м':
                        outStr += @"\'ec";
                        break;
                    case 'н':
                        outStr += @"\'ed";
                        break;
                    case 'о':
                        outStr += @"\'ee";
                        break;
                    case 'п':
                        outStr += @"\'ef";
                        break;
                    case 'р':
                        outStr += @"\'f0";
                        break;
                    case 'с':
                        outStr += @"\'f1";
                        break;
                    case 'т':
                        outStr += @"\'f2";
                        break;
                    case 'у':
                        outStr += @"\'f3";
                        break;
                    case 'ф':
                        outStr += @"\'f4";
                        break;
                    case 'х':
                        outStr += @"\'f5";
                        break;
                    case 'ц':
                        outStr += @"\'f6";
                        break;
                    case 'ч':
                        outStr += @"\'f7";
                        break;
                    case 'ш':
                        outStr += @"\'f8";
                        break;
                    case 'щ':
                        outStr += @"\'f9";
                        break;
                    case 'ь':
                        outStr += @"\'fc";
                        break;
                    case 'ы':
                        outStr += @"\'fb";
                        break;
                    case 'ъ':
                        outStr += @"\'fa";
                        break;
                    case 'э':
                        outStr += @"\'fd";
                        break;
                    case 'ю':
                        outStr += @"\'fe";
                        break;
                    case 'я':
                        outStr += @"\'ff";
                        break;
                    case 'А': //e0 - ff
                        outStr += @"\'c0";
                        break;
                    case 'Б':
                        outStr += @"\'c1";
                        break;
                    case 'В':
                        outStr += @"\'c2";
                        break;
                    case 'Г':
                        outStr += @"\'c3";
                        break;
                    case 'Д':
                        outStr += @"\'c4";
                        break;
                    case 'Е':
                        outStr += @"\'c5";
                        break;
                    case 'Ё':
                        outStr += @"\'a8";
                        break;
                    case 'Ж':
                        outStr += @"\'c6";
                        break;
                    case 'З':
                        outStr += @"\'c7";
                        break;
                    case 'И':
                        outStr += @"\'c8";
                        break;
                    case 'Й':
                        outStr += @"\'c9";
                        break;
                    case 'К':
                        outStr += @"\'ca";
                        break;
                    case 'Л':
                        outStr += @"\'cb";
                        break;
                    case 'М':
                        outStr += @"\'cc";
                        break;
                    case 'Н':
                        outStr += @"\'cd";
                        break;
                    case 'О':
                        outStr += @"\'ce";
                        break;
                    case 'П':
                        outStr += @"\'cf";
                        break;
                    case 'Р':
                        outStr += @"\'d0";
                        break;
                    case 'С':
                        outStr += @"\'d1";
                        break;
                    case 'Т':
                        outStr += @"\'d2";
                        break;
                    case 'У':
                        outStr += @"\'d3";
                        break;
                    case 'Ф':
                        outStr += @"\'d4";
                        break;
                    case 'Х':
                        outStr += @"\'d5";
                        break;
                    case 'Ц':
                        outStr += @"\'d6";
                        break;
                    case 'Ч':
                        outStr += @"\'d7";
                        break;
                    case 'Ш':
                        outStr += @"\'d8";
                        break;
                    case 'Щ':
                        outStr += @"\'d9";
                        break;
                    case 'Ь':
                        outStr += @"\'dc";
                        break;
                    case 'Ы':
                        outStr += @"\'db";
                        break;
                    case 'Ъ':
                        outStr += @"\'da";
                        break;
                    case 'Э':
                        outStr += @"\'dd";
                        break;
                    case 'Ю':
                        outStr += @"\'de";
                        break;
                    case 'Я':
                        outStr += @"\'df";
                        break;
                    default:
                        outStr += inp[i];
                        break;
                }
            }

            outStr +=  @"\f2\fs17\lang1033";

            return outStr;
        }

        private void createReport(string dateFromLoc, string dateToLoc, string departmentLoc)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            CultureInfo ci = CultureInfo.InvariantCulture;
            int ret = 0;

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("", connection);

                string queryString = "";

                string queryStringBase = "SELECT " +
                  "e.Name, " +
                  "e.Position, " +
                  "e.HireDate, " +
                  "COALESCE(e.TerminationDate,'') TerminationDate, " +
                  "d.Name Department " +
                  "FROM dbo.Employees as e" +
                  " LEFT JOIN dbo.Departments as d ON e.departmentID = d.id WHERE ";

               string queryStringWithDate =  " ( HireDate between @DateFrom AND @DateTo AND " +
                  "TerminationDate between @DateFrom AND @DateTo ) ";

                string queryStringWithNullTerminationDate = " (TerminationDate = '01/01/1900' OR TerminationDate = NULL) ";

                string queryStringDepartment = " AND DepartmentID = @Department";

                if (depInc.Checked)
                    if (exactDate.Checked)
                        queryString += queryStringBase + "(" + queryStringWithDate + " OR " + queryStringWithNullTerminationDate + ")" + queryStringDepartment;
                    else
                        queryString += queryStringBase + queryStringWithDate + queryStringDepartment;
                else
                    if (exactDate.Checked)
                    queryString += queryStringBase + "(" + queryStringWithDate + " OR " + queryStringWithNullTerminationDate + ")";
                else
                    queryString += queryStringBase + queryStringWithDate;

                queryString += " ORDER BY d.Name, e.Name, e.HireDate ASC ";

                SqlCommand command = new SqlCommand(queryString, connection);

                if (depInc.Checked) { 
                    command.Parameters.AddWithValue("@DateFrom", dateFromLoc);
                    command.Parameters.AddWithValue("@DateTo", dateToLoc);
                    command.Parameters.AddWithValue("@Department", int.Parse(departmentLoc));
                }
                else
                { 
                    command.Parameters.AddWithValue("@DateFrom", dateFromLoc);
                    command.Parameters.AddWithValue("@DateTo", dateToLoc);
                }
                
                dataAdapter.SelectCommand = command;
                connection.Open();
                SqlDataReader result = command.ExecuteReader();
                
                mainReportSheet.AppendText("\n");
                
                int counter = 1;

                string table = @"";

               
                while (result.Read())
                {
                    mainReportSheet.SelectionFont = new Font("Lucida Sans Unicode", 12);
                    mainReportSheet.SelectionColor = Color.Black;

                    string beginDateStr = result["HireDate"].ToString();
                    string endDateStr = result["TerminationDate"].ToString();

                    DateTime beginDate = DateTime.Parse(beginDateStr);
                    DateTime endDate = DateTime.Parse(endDateStr);
;
                    table += @"\trowd" +
                       @"\cellx1000" +
                       @"\cellx5000" +
                       @"\cellx8000" +
                       @"\cellx10000" +
                       @"\cellx11000" +
                       @"\cellx12000" +
                       @"\intbl " + counter.ToString() + @" \cell" +
                       @"\intbl " + encoder((String)result["Name"]) + @" \cell" +
                       @"\intbl " + encoder((String)result["Position"]) + @" \cell" +
                       @"\intbl " + encoder((String)result["Department"]) + @" \cell" +
                       @"\intbl " + beginDate.ToString("dd.MM.yyyy", ci) + @" \cell" +
                       @"\intbl " + (endDate.ToString("dd.MM.yyyy", ci).Equals(@"01.01.1900") ?"": endDate.ToString("dd.MM.yyyy", ci)) + @" \cell" +
                       @"\row";
                    counter++;
                }

                int index = mainReportSheet.Rtf.LastIndexOf("}");
                mainReportSheet.Rtf = mainReportSheet.Rtf.Substring(0, index) + table + "}";
                dataAdapter.SelectCommand.Connection.Close();
            }
        }

        private void create_Click(object sender, EventArgs e)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;

            mainReportSheet.Clear();
            mainReportSheet.SelectionFont = new Font("Arial", 18);
            mainReportSheet.SelectionColor = Color.Black;
            mainReportSheet.SelectedText = "              Главный отчет по сотрудникам              " + "\n";
            mainReportSheet.AppendText("\n");
            mainReportSheet.SelectionFont = new Font("Arial", 18);
            mainReportSheet.SelectionColor = Color.Black;

            mainReportSheet.SelectedText = "       за период с " + dateFrom.Value.ToString("dd.MM.yyyy", ci) + 
                  " по " + dateTo.Value.ToString("dd.MM.yyyy", ci) + "\n";
            mainReportSheet.AppendText("\n");

            createReport(dateFrom.Value.ToString("dd.MM.yyyy", ci), dateTo.Value.ToString("dd.MM.yyyy", ci), department.SelectedValue.ToString());
        }
    }
}
