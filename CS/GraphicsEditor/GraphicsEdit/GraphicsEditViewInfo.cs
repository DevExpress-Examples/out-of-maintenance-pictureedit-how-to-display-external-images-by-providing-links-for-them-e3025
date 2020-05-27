using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Repository;

namespace GraphicsEditor
{
    class GraphicsEditViewInfo : PictureEditViewInfo
    {
        public GraphicsEditViewInfo(RepositoryItem item) : base(item) { }
        Image oldImage = null;

        new RepositoryItemGraphicsEdit Item { get { return base.Item as RepositoryItemGraphicsEdit; } }

        public override object EditValue
        {
            get
            {
                return base.EditValue;
            }
            set
            {
                if(value != null && value.GetType() == typeof(System.String))
                    base.EditValue = Item.GetImage(value.ToString());
                else
                    base.EditValue = value;
            }
        }
    }
}
