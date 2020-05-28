Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports System.Drawing

Namespace GraphicsEditor
	'The attribute that points to the registration method 
	<UserRepositoryItem("RegisterGraphicsEditor")>
	Friend Class RepositoryItemGraphicsEdit
		Inherits RepositoryItemPictureEdit

		' Static constructor should call registration method
		Shared Sub New()
			RegisterGraphicsEditor()
		End Sub

		Private images As New Dictionary(Of String, Image)()
		Public Const GraphicsEditorName As String = "GraphicsEdit"

		Friend Function GetImage(ByVal filePath As String) As Image
			If Not images.ContainsKey(filePath) Then
				Try
					Dim image As System.Drawing.Image = System.Drawing.Image.FromFile(filePath)
					images(filePath) = image
				Catch
					images(filePath) = ErrorImage
				End Try
			End If
			Return images(filePath)
		End Function

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return GraphicsEditorName
			End Get
		End Property

		Public Shared Sub RegisterGraphicsEditor()
			EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(GraphicsEditorName, GetType(GraphicsEdit), GetType(RepositoryItemGraphicsEdit), GetType(GraphicsEditViewInfo), New PictureEditPainter(), True))
		End Sub
		Public Overrides Sub Assign(ByVal item As RepositoryItem)
			MyBase.Assign(item)
			Dim source As RepositoryItemGraphicsEdit = TryCast(item, RepositoryItemGraphicsEdit)
			If source IsNot Nothing Then
				images = source.images
			End If
		End Sub
	End Class
End Namespace
