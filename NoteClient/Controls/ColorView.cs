using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteClient.Controls
{
    public class ColorView : Control
    {
        private Color color =Color.Blue;
        #region Constructors
        public ColorView()
        {
           
        }
        #endregion
        [Category("外观")]
        [Description("获取或设置控件的背景色")]
        public Color Color { get { return color; } set { if (color == value) return; color = value; this.Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            e.Graphics.Clear(color);
        }
    }
}
