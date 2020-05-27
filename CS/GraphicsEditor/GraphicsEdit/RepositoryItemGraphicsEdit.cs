using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using System.Drawing;

namespace GraphicsEditor {
    //The attribute that points to the registration method 
    [UserRepositoryItem("RegisterGraphicsEditor")]
    class RepositoryItemGraphicsEdit : RepositoryItemPictureEdit {
        // Static constructor should call registration method
        static RepositoryItemGraphicsEdit() { RegisterGraphicsEditor(); }

        Dictionary<string, Image> images = new Dictionary<string, Image>();
        public const string GraphicsEditorName = "GraphicsEdit";

        internal Image GetImage(string filePath) {
            if(!images.ContainsKey(filePath)) {
                try {
                    var image = Image.FromFile(filePath);
                    images[filePath] = image;
                }
                catch {
                    images[filePath] = ErrorImage;
                }
            }
            return images[filePath];
        }

        public override string EditorTypeName { get { return GraphicsEditorName; } }

        public static void RegisterGraphicsEditor() {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(
                GraphicsEditorName, typeof(GraphicsEdit), typeof(RepositoryItemGraphicsEdit),
                typeof(GraphicsEditViewInfo), new PictureEditPainter(), true));
        }
        public override void Assign(RepositoryItem item) {
            base.Assign(item);
            RepositoryItemGraphicsEdit source = item as RepositoryItemGraphicsEdit;
            if(source != null)
                images = source.images;
        }
    }
}
