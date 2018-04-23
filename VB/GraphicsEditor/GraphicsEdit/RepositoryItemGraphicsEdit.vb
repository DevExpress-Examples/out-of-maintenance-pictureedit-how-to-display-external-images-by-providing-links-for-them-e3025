Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing

Namespace GraphicsEditor
	'The attribute that points to the registration method 
	<UserRepositoryItem("RegisterGraphicsEditor")> _
	Friend Class RepositoryItemGraphicsEdit
		Inherits RepositoryItemPictureEdit
		' Static constructor should call registration method
		Shared Sub New()
			RegisterGraphicsEditor()
		End Sub

		Public Const GraphicsEditorName As String = "GraphicsEdit"
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return GraphicsEditorName
			End Get
		End Property

		Public Shared Sub RegisterGraphicsEditor()
			EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(GraphicsEditorName, GetType(GraphicsEdit), GetType(RepositoryItemGraphicsEdit), GetType(GraphicsEditViewInfo), New PictureEditPainter(), True))
		End Sub
	End Class
End Namespace
