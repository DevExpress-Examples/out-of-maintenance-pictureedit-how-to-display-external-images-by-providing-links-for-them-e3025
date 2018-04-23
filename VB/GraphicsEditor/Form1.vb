Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms


Namespace GraphicsEditor
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim dt As DataTable = FillDataTable()
			gridControl1.DataSource = dt

			Dim repItemGraphicsEdit As New RepositoryItemGraphicsEdit()
			repItemGraphicsEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
			gridView1.Columns("Image").ColumnEdit = repItemGraphicsEdit

			gridControl2.DataSource = dt
		End Sub

		Private Function FillDataTable() As DataTable
			Dim _dataTable As New DataTable()
			Dim col As DataColumn
			Dim row As DataRow

			_dataTable.TableName = "SomeTable"

			col = New DataColumn()
			col.ColumnName = "Image"
			col.DataType = System.Type.GetType("System.String")
			_dataTable.Columns.Add(col)

			row = _dataTable.NewRow()
			row("Image") = "c:\Users\Public\Documents\DevExpress 2010.2 Demos\Components\Data\1.jpg"
			_dataTable.Rows.Add(row)

			row = _dataTable.NewRow()
			row("Image") = "c:\Users\Public\Documents\DevExpress 2010.2 Demos\Components\Data\2.jpg"
			_dataTable.Rows.Add(row)

			row = _dataTable.NewRow()
			row("Image") = "Wrong path"
			_dataTable.Rows.Add(row)

			Return _dataTable
		End Function
	End Class
End Namespace
