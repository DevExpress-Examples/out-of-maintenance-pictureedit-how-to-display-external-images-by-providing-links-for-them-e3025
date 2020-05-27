using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace GraphicsEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = FillDataTable();
            gridControl1.DataSource = dt;

            RepositoryItemGraphicsEdit repItemGraphicsEdit = new RepositoryItemGraphicsEdit();
            repItemGraphicsEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;

            gridControl1.RepositoryItems.Add(repItemGraphicsEdit);
            gridView1.Columns["Image"].ColumnEdit = repItemGraphicsEdit;

            gridControl2.DataSource = dt;
        }

        DataTable FillDataTable()
        {
            DataTable _dataTable = new DataTable();
            DataColumn col;
            DataRow row;

            _dataTable.TableName = "SomeTable";

            col = new DataColumn();
            col.ColumnName = "Image";
            col.DataType = System.Type.GetType("System.String");
            _dataTable.Columns.Add(col);

            row = _dataTable.NewRow();
            //insert your image file path here
            row["Image"] = @"c:\Users\Public\Documents\DevExpress 2010.2 Demos\Components\Data\1.jpg";
            _dataTable.Rows.Add(row);

            row = _dataTable.NewRow();
            //insert your image file path here
            row["Image"] = @"c:\Users\Public\Documents\DevExpress 2010.2 Demos\Components\Data\2.jpg";
            _dataTable.Rows.Add(row);

            row = _dataTable.NewRow();
            row["Image"] = @"Wrong path";
            _dataTable.Rows.Add(row);

            return _dataTable;
        }
    }
}
