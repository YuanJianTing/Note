using NoteClient.Controls;
using NoteClient.Extension;
using NoteClient.Repository;
using System.Drawing;

namespace NoteClient
{
    public partial class MainForm : Form
    {
        private IRepository? Repository;
        private readonly string PageName;
        private readonly SynchronizationContext? _synchronizationContext;

        private readonly SharedPreference SharedPreference;
        private MenuForm? MenuForm;

        public MainForm(string pageName)
        {
            InitializeComponent();
            _synchronizationContext = WindowsFormsSynchronizationContext.Current;
            PageName = pageName;
            SharedPreference = new SharedPreference(PageName);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            new DropShadow().ApplyShadows(this);
            int x = SharedPreference.GetIntValue("LocationX");
            int y = SharedPreference.GetIntValue("LocationY");
            double opacity=SharedPreference.GetDoubleValue("Opacity",1);
            if (x == 0 && y == 0)
            {
                int xWidth1 = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;//获取显示器屏幕宽度
                int yHeight1 = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;//高度
                x = xWidth1 / 2 - this.Width / 2;
                y = yHeight1 / 2 - this.Height / 2;
            }
            this.Opacity = opacity;
            this.Location = new Point(x, y);
            string hexColor= SharedPreference.GetStringValue("ThemeColor");
            if (!string.IsNullOrEmpty(hexColor))
            {
                UpdateColor(System.Drawing.ColorTranslator.FromHtml(hexColor));
            }
            Repository = new LocalFileRepository();

            Repository.GetAsync(PageName).ContinueWith(o =>
            {
                if (o.Status == TaskStatus.RanToCompletion)
                    _synchronizationContext?.Post<string>(SetRTFContent, o.Result);
            });

        }


        private void SetRTFContent(string state)
        {
            this.rtxContent.Rtf = state;
        }

        #region Style
        private void btnBold_Click(object sender, EventArgs e)
        {
            if (GetFontStyle().HasFlag(FontStyle.Bold))
                this.rtxContent.SelectionFont = new Font(GetSelectionFont(), RemoveFontStyle(FontStyle.Bold));
            else
                this.rtxContent.SelectionFont = new Font(GetSelectionFont(), GetFontStyle() | FontStyle.Bold);
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (GetFontStyle().HasFlag(FontStyle.Italic))
                this.rtxContent.SelectionFont = new Font(GetSelectionFont(), RemoveFontStyle(FontStyle.Italic));
            else
                this.rtxContent.SelectionFont = new Font(GetSelectionFont(), GetFontStyle() | FontStyle.Italic);
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            if (GetFontStyle().HasFlag(FontStyle.Underline))
                this.rtxContent.SelectionFont = new Font(GetSelectionFont(), RemoveFontStyle(FontStyle.Underline));
            else
                this.rtxContent.SelectionFont = new Font(GetSelectionFont(), GetFontStyle() | FontStyle.Underline);
        }

        private void btnStrikethrough_Click(object sender, EventArgs e)
        {
            if (GetFontStyle().HasFlag(FontStyle.Strikeout))
                this.rtxContent.SelectionFont = new Font(GetSelectionFont(), RemoveFontStyle(FontStyle.Strikeout));
            else
                this.rtxContent.SelectionFont = new Font(GetSelectionFont(), GetFontStyle() | FontStyle.Strikeout);
        }

        private FontStyle GetFontStyle()
        {
            return GetSelectionFont().Style;
        }

        private Font GetSelectionFont()
        {
            if (this.rtxContent.SelectionFont == null)
                return this.rtxContent.Font;
            return this.rtxContent.SelectionFont;
        }

        private FontStyle RemoveFontStyle(FontStyle fontStyle)
        {
            return this.rtxContent.SelectionFont.Style & ~fontStyle;
        }
        #endregion

        private void btnAddForm_Click(object sender, EventArgs e)
        {
            PageManager.Instance.ShowForm();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (MenuForm != null)
            {
                MenuForm.Close();
                MenuForm=null;
                SharedPreference.Add("Opacity", this.Opacity);
            }

            if (!this.panel1.Visible)
                AnimationManager.AnimIn(this.panel1);
            //this.panel1.Visible = true;
            flowLayoutPanel1.Visible = true;
            this.lineView1.Visible = true;
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            AnimationManager.AnimOut(this.panel1);
            //this.panel1.Visible = false;
            flowLayoutPanel1.Visible = false;
            this.lineView1.Visible = false;
            if (string.IsNullOrEmpty(this.rtxContent.Text))
                return;
            string rtf = this.rtxContent.Rtf;
            Repository?.Save(PageName, rtf);
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            MenuForm = new MenuForm();
            MenuForm.Location = new Point(this.Left, this.Top);
            MenuForm.Width=this.Width;
            //MenuForm.Size = new Size(this.Width, MenuForm.Height);
            MenuForm.Show(this);
        }

        public void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //释放鼠标焦点捕获
            Win32.ReleaseCapture();
            ////向当前窗体发送拖动消息
            Win32.SendMessage(this.Handle, 0x0112, 0xF011, 0);
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (DesignMode) return;
            //释放鼠标焦点捕获
            Win32.ReleaseCapture();
            ////向当前窗体发送拖动消息
            Win32.SendMessage(this.Handle, 0x0112, 0xF011, 0);
            base.OnMouseDown(e);
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            SharedPreference.Add("LocationX", this.Location.X);
            SharedPreference.Add("LocationY", this.Location.Y);
        }

        public void UpdateColor(Color themeColor)
        {
            this.panel1.BackColor = themeColor;

            var argb = Color.FromArgb(60, themeColor);
            var rgbData = Color.FromArgb(
                (int)((argb.R) * (argb.A / 255.0) + 255 - argb.A),
                (int)((argb.G) * (argb.A / 255.0) + 255 - argb.A),
                (int)((argb.B) * (argb.A / 255.0) + 255 - argb.A));
            this.BackColor = rgbData;
            this.rtxContent.BackColor = rgbData;
            flowLayoutPanel1.BackColor = rgbData;
            string str= String.Format("#{0:X2}{1:X2}{2:X2}", themeColor.R, themeColor.G, themeColor.B);
            SharedPreference.Add("ThemeColor", str);
        }

        public void Delete()
        {
            Repository?.Delete(PageName);
            SharedPreference.RemovePreference();
            if ("default" == PageName)
            {
                this.rtxContent.Rtf = null;
                return;
            }
            this.Close();
        }

    }
}
