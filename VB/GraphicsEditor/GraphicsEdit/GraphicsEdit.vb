Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel
Imports DevExpress.XtraEditors

Namespace GraphicsEditor
	Friend Class GraphicsEdit
		Inherits PictureEdit

		Shared Sub New()
			RepositoryItemGraphicsEdit.RegisterGraphicsEditor()
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemGraphicsEdit.GraphicsEditorName
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
		Public Shadows ReadOnly Property Properties() As RepositoryItemGraphicsEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemGraphicsEdit)
			End Get
		End Property

		Protected Overrides ReadOnly Property Menu() As DevExpress.XtraEditors.Controls.PictureMenu
			Get
				Return Nothing
			End Get
		End Property
	End Class
End Namespace
