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

'INSTANT VB NOTE: The variable item was renamed since Visual Basic does not handle local variables named the same as class members well:
		Public Sub New(ByVal item_Conflict As RepositoryItem)
			MyBase.New(item_Conflict)
		End Sub
		Private oldImage As Image = Nothing

		Private Shadows ReadOnly Property Item() As RepositoryItemGraphicsEdit
			Get
				Return TryCast(MyBase.Item, RepositoryItemGraphicsEdit)
			End Get
		End Property

		Public Overrides Property EditValue() As Object
			Get
				Return MyBase.EditValue
			End Get
			Set(ByVal value As Object)
				If value IsNot Nothing AndAlso value.GetType() Is GetType(System.String) Then
					MyBase.EditValue = Item.GetImage(value.ToString())
				Else
					MyBase.EditValue = value
				End If
			End Set
		End Property
	End Class
End Namespace
