Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Repository

Namespace GraphicsEditor
	Friend Class GraphicsEditViewInfo
		Inherits PictureEditViewInfo
		Public Sub New(ByVal item As RepositoryItem)
			MyBase.New(item)
		End Sub

		Public Overrides Property EditValue() As Object
			Get
				Return MyBase.EditValue
			End Get
			Set(ByVal value As Object)
				If value IsNot Nothing AndAlso value.GetType() Is GetType(System.String) Then
					Try
						MyBase.EditValue = New Bitmap(value.ToString())
					Catch
						MyBase.EditValue = Item.ErrorImage
					End Try
				Else
					MyBase.EditValue = value
				End If
			End Set
		End Property
	End Class
End Namespace
