using System.ComponentModel;

namespace NoteClient.Controls
{
    public class LineView : Control
    {
        private int lineWeight = 1;
        private Color lineColor= Color.FromArgb(220, 222, 224);
        #region Constructors
        public LineView()
        {
            SetStyle(
             ControlStyles.UserPaint |
             ControlStyles.AllPaintingInWmPaint |
             ControlStyles.OptimizedDoubleBuffer |
             ControlStyles.ResizeRedraw |
             ControlStyles.SupportsTransparentBackColor |
             ControlStyles.Selectable |
             ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();
            BackColor = Color.Transparent;
        }
        #endregion
        [Category("外观")]
        [Description("获取或设置控件的背景色")]
        public Color LineColor { get { return lineColor; } set { if (lineColor == value) return; lineColor = value; this.Invalidate(); } }

        [Category("外观")]
        public int LineWeight { get { return lineWeight; } set { if (lineWeight == value) return; lineWeight = value; this.Invalidate(); } }


        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            using (Pen p = new Pen(LineColor, lineWeight))
            {
                int y = this.Height / 2 - lineWeight;
                e.Graphics.DrawLine(p,0,y,this.Width,y);
            }

        }

    }
}
