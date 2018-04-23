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

        public override object EditValue
        {
            get
            {
                return base.EditValue;
            }
            set
            {
                if (value != null && value.GetType() == typeof(System.String))
                {
                    try { base.EditValue = new Bitmap(value.ToString()); }
                    catch { base.EditValue = Item.ErrorImage; }
                }
                else
                    base.EditValue = value;
            }
        }
    }
}
