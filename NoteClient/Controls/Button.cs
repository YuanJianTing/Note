using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NoteClient.Controls
{
    [ComVisibleAttribute(true)]
    [ToolboxItem(true), DefaultProperty("Text"), DefaultEvent("Click")]
    public partial class Button : Control, IButtonControl
    {
        #region Fields
        private DialogResult dialogResult = DialogResult.Cancel;

        private Color mouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
        private Color mouseDownBackColor = Color.FromArgb(40, 255, 255, 255);
        private Color backColor = Color.Black;
        private string text = string.Empty;
        private ContentAlignment textAlign = ContentAlignment.MiddleCenter;
        private Image? image = null;
        private ContentAlignment imageAlign = ContentAlignment.MiddleLeft;
        private int mourceState = -1;
        private StringFormat stringFormat;
        #endregion

        #region Constructors
        public Button()
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
            stringFormat = new StringFormat(StringFormat.GenericDefault);
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
        }
        #endregion

        #region Properties
        [Category("外观")]
        [Description("获取或设置控件背景图的方向")]
        [DefaultValue(typeof(ContentAlignment), "1")]
        public ContentAlignment ImageAlign { get { return imageAlign; } set { imageAlign = value; this.Invalidate(); } }

        [DefaultValue(null)]
        [Localizable(true)]
        [Category("外观")]
        [Description("获取或设置控件的背景图片")]
        public virtual Image? Image { get { return image; } set { image = value; this.Invalidate(); } }


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImeMode ImeMode { get { return base.ImeMode; } set { base.ImeMode = ImeMode.NoControl; } }


        [Category("外观")]
        [Description("获取或设置控件文本的方向")]
        [DefaultValue(typeof(ContentAlignment), "1")]
        public ContentAlignment TextAlign { get { return textAlign; } set { 
                textAlign = value;
                switch (textAlign)
                {
                    case ContentAlignment.TopLeft:
                        stringFormat.LineAlignment= StringAlignment.Near;
                        stringFormat.Alignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.TopCenter:
                        stringFormat.LineAlignment = StringAlignment.Near;
                        stringFormat.Alignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.TopRight:
                        stringFormat.LineAlignment = StringAlignment.Near;
                        stringFormat.Alignment = StringAlignment.Far;
                        break;
                    case ContentAlignment.MiddleLeft:
                        stringFormat.LineAlignment = StringAlignment.Center;
                        stringFormat.Alignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.MiddleCenter:
                        stringFormat.LineAlignment = StringAlignment.Center;
                        stringFormat.Alignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.MiddleRight:
                        stringFormat.LineAlignment = StringAlignment.Far;
                        stringFormat.Alignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.BottomLeft:
                        stringFormat.LineAlignment = StringAlignment.Far;
                        stringFormat.Alignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.BottomCenter:
                        stringFormat.LineAlignment = StringAlignment.Far;
                        stringFormat.Alignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.BottomRight:
                        stringFormat.LineAlignment = StringAlignment.Far;
                        stringFormat.Alignment = StringAlignment.Far;
                        break;
                    default:
                        break;
                }
                this.Invalidate();
            } }


        [Category("内容")]
        [Description("获取或设置控件的文本")]
        [DefaultValue(typeof(string), "")]
        public new string Text { get { return text; } set { text = value; this.Invalidate(); } }


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
            DrawText(g);
        }



        private void DrawImage(Graphics g)
        {
            if (image == null)
                return;
            int x = this.Padding.Left;
            int y = this.Padding.Top;
            switch (imageAlign)
            {
                case ContentAlignment.TopLeft:
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.TopCenter:
                    if (image.Width < this.Width)
                        x += this.Width / 2 - image.Width / 2;
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.TopRight:
                    if (image.Width < this.Width)
                        x += this.Width - image.Width;
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.MiddleLeft:
                    if (image.Height < this.Height)
                        y += this.Height / 2 - image.Height / 2;
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.MiddleCenter:
                    x += this.Width / 2 - image.Width / 2;
                    y += this.Height / 2 - image.Height / 2;
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.MiddleRight:
                    x += this.Width - image.Width;
                    y += this.Height / 2 - image.Height / 2;
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.BottomLeft:
                    y += this.Height - image.Height;
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.BottomCenter:
                    x += this.Width / 2 - image.Width / 2;
                    y += this.Height - image.Height;
                    g.DrawImage(image, x, y);
                    break;
                case ContentAlignment.BottomRight:
                    x += this.Width - image.Width;
                    y += this.Height - image.Height;
                    g.DrawImage(image, x, y);
                    break;
                default:
                    break;
            }
        }

        private void DrawText(Graphics g)
        {
            if (string.IsNullOrEmpty(text))
                return;
            Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
            using (SolidBrush solidBrush = new SolidBrush(this.ForeColor))
                g.DrawString(text,this.Font,solidBrush,rectangle, stringFormat);


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