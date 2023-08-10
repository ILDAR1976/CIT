
namespace EmployeesManagamentFrame
{
    partial class BaseReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.ComboBox();
            this.mainReprotDataSet = new EmployeesManagamentFrame.DataSet();
            this.create = new System.Windows.Forms.Button();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.mainReportSheet = new System.Windows.Forms.RichTextBox();
            this.bindingSourceForReport = new System.Windows.Forms.BindingSource(this.components);
            this.departmentsTableAdapter = new EmployeesManagamentFrame.DataSetTableAdapters.DepartmentsTableAdapter();
            this.depInc = new System.Windows.Forms.CheckBox();
            this.exactDate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainReprotDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceForReport)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.exactDate);
            this.splitContainer1.Panel1.Controls.Add(this.depInc);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.department);
            this.splitContainer1.Panel1.Controls.Add(this.create);
            this.splitContainer1.Panel1.Controls.Add(this.dateTo);
            this.splitContainer1.Panel1.Controls.Add(this.dateFrom);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mainReportSheet);
            this.splitContainer1.Size = new System.Drawing.Size(936, 533);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Department:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "to:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Begin from:";
            // 
            // department
            // 
            this.department.DataSource = this.bindingSourceForReport;
            this.department.DisplayMember = "Name";
            this.department.FormattingEnabled = true;
            this.department.Location = new System.Drawing.Point(24, 144);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(140, 21);
            this.department.TabIndex = 3;
            this.department.ValueMember = "ID";
            // 
            // mainReprotDataSet
            // 
            this.mainReprotDataSet.DataSetName = "DataSet";
            this.mainReprotDataSet.Locale = new System.Globalization.CultureInfo("ru");
            this.mainReprotDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(24, 12);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(75, 23);
            this.create.TabIndex = 2;
            this.create.Text = "Create";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "dd.MM.yyyy";
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(24, 101);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(140, 20);
            this.dateTo.TabIndex = 1;
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "dd.MM.yyyy";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(24, 62);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(140, 20);
            this.dateFrom.TabIndex = 0;
            // 
            // mainReportSheet
            // 
            this.mainReportSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainReportSheet.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainReportSheet.Location = new System.Drawing.Point(0, 0);
            this.mainReportSheet.Name = "mainReportSheet";
            this.mainReportSheet.Size = new System.Drawing.Size(688, 533);
            this.mainReportSheet.TabIndex = 0;
            this.mainReportSheet.Text = "";
            // 
            // bindingSourceForReport
            // 
            this.bindingSourceForReport.DataMember = "Departments";
            this.bindingSourceForReport.DataSource = this.mainReprotDataSet;
            // 
            // departmentsTableAdapter
            // 
            this.departmentsTableAdapter.ClearBeforeFill = true;
            // 
            // depInc
            // 
            this.depInc.AutoSize = true;
            this.depInc.Location = new System.Drawing.Point(24, 171);
            this.depInc.Name = "depInc";
            this.depInc.Size = new System.Drawing.Size(116, 17);
            this.depInc.TabIndex = 1;
            this.depInc.Text = "department include";
            this.depInc.UseVisualStyleBackColor = true;
            // 
            // exactDate
            // 
            this.exactDate.AutoSize = true;
            this.exactDate.Location = new System.Drawing.Point(24, 195);
            this.exactDate.Name = "exactDate";
            this.exactDate.Size = new System.Drawing.Size(182, 17);
            this.exactDate.TabIndex = 7;
            this.exactDate.Text = "with the exact date of termination";
            this.exactDate.UseVisualStyleBackColor = true;
            // 
            // BaseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 533);
            this.Controls.Add(this.splitContainer1);
            this.Name = "BaseReport";
            this.Text = "Basic employee report";
            this.Load += new System.EventHandler(this.BaseReport_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainReprotDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceForReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox department;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.RichTextBox mainReportSheet;
        private DataSet mainReprotDataSet;
        private System.Windows.Forms.BindingSource bindingSourceForReport;
        private DataSetTableAdapters.DepartmentsTableAdapter departmentsTableAdapter;
        private System.Windows.Forms.CheckBox depInc;
        private System.Windows.Forms.CheckBox exactDate;
    }
}