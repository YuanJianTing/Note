using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace NoteClient.Controls
{
    [ComVisibleAttribute(true)]
    [ToolboxItem(true), DefaultProperty("Image"), DefaultEvent("Click")]
    public class ImageButton : Control, IButtonControl
    {
        #region Fields
        private DialogResult dialogResult = DialogResult.Cancel;
        private Color mouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
        private Color mouseDownBackColor = Color.FromArgb(40, 255, 255, 255);

        private Color backColor = Color.Black;
        private Image? image = null;
        private int mourceState = -1;

        #endregion

        #region Constructors
        public ImageButton()
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

            base.BackColor = Color.Transparent;
            base.AutoSize = false;
            base.Height = 25;
        }
        #endregion

        #region Properties

        [DefaultValue(null)]
        [Localizable(true)]
        [Category("外观")]
        [Description("获取或设置控件的背景图片")]
        public virtual Image Image { get { return image; } set { image = value; this.Invalidate(); } }


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImeMode ImeMode { get { return base.ImeMode; } set { base.ImeMode = ImeMode.NoControl; } }


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AutoSize { get { return base.AutoSize; } set { base.AutoSize = false; } }

        [Category("外观")]
        [Description("获取或设置控件的背景色")]
        public new Color BackColor { get { return backColor; } set { if (backColor == value) return; backColor = value; this.Invalidate(); } }


        [Category("外观")]
        [Description("获取或设置当鼠标指针位于控件边框内时按钮工作区的颜色")]
        [DefaultValue(typeof(Color), "215, 210, 206")]
        public Color MouseOverBackColor { get { return mouseOverBackColor; } set { mouseOverBackColor = value; } }

        [Category("外观")]
        [Description("获取或设置当鼠标指针位于控件边框内时按钮工作区的颜色")]
        [DefaultValue(typeof(Color), "215, 210, 206")]
        public Color MouseDownBackColor { get { return mouseDownBackColor; } set { mouseDownBackColor = value; } }

        [Category("行为")]
        [Description("获取或设置窗体产生的结果")]
        [DefaultValue(typeof(DialogResult), "0")]
        public DialogResult DialogResult { get { return dialogResult; } set { dialogResult = value; } }

        [Browsable(false)]
        public int MourceState { get { return mourceState; } set { if (mourceState == value) return; mourceState = value; this.Invalidate(); } }
        #endregion


        #region Draw
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush solidBrush = new SolidBrush(backColor))
            {
                if (mourceState == 1)
                    solidBrush.Color = MouseDownBackColor;
                else if (mourceState == 2) //抬起
                    solidBrush.Color = MouseOverBackColor;
                else if (mourceState == 3)
                    solidBrush.Color = MouseOverBackColor;
                g.FillRectangle(solidBrush, new Rectangle(0, 0, this.Width, this.Height));
            }
            DrawImage(g);
        }



        private void DrawImage(Graphics g)
        {
            if (image == null)
                return;
            int x = this.Padding.Left + this.Width / 2 - image.Width / 2;
            int y = this.Padding.Top + this.Height / 2 - image.Height / 2;
            g.DrawImage(image, x, y);
        }

        #endregion

        protected override void OnMouseDown(MouseEventArgs e)
        {

            base.OnMouseDown(e);
            if (DesignMode)
                return;
            if (e.Button == MouseButtons.Left)
            {
                MourceState = 1;//按下
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            //base.OnMouseLeave(e);
            if (DesignMode) return;
            MourceState = -1;//离开
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (DesignMode) return;
            if (e.Button == MouseButtons.Left)
                MourceState = 1;//按下
            else
                MourceState = 3;//移动
        }


        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (DesignMode)
                return;
            MourceState = 2;//抬起
        }

        public void NotifyDefault(bool value)
        {
        }

        public void PerformClick()
        {
            if (this.Enabled)
                OnClick(EventArgs.Empty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (image != null)
                {
                    image.Dispose();
                    image = null;
                }
                base.Dispose(disposing);
            }
        }
    }
}
