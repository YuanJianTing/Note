using NoteClient.Controls;

namespace NoteClient
{
    public partial class MenuForm : Form
    {
        private Color[] colors = {Color.FromArgb(238, 215, 103), Color.FromArgb(161, 239, 155), Color.FromArgb(255, 175, 223),
            Color.FromArgb(215,175,255), Color.FromArgb(154,217,248) , Color.FromArgb(223,223,223), Color.FromArgb(118,118,118)};


        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            new DropShadow().ApplyShadows(this);

            btnDelete.Image = Properties.Resources.delete;
            LoadColor();
            this.trackBar1.Value=(int)(Owner.Opacity*100);
        }

        private void LoadColor()
        {
            int itemWidth = this.Width / colors.Length;
            foreach (var item in colors)
            {
                ColorView colorView = new ColorView();
                colorView.Margin = new Padding(0, 0, 0, 0);
                colorView.Color = item;
                colorView.Size = new Size(itemWidth, this.Height);
                colorView.Click += ColorView_Click;
                this.flowLayoutPanel1.Controls.Add(colorView);
            }
        }

        private void ColorView_Click(object? sender, EventArgs e)
        {
            ColorView colorView = sender as ColorView;
            ((MainForm)Owner).UpdateColor(colorView.Color);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ((MainForm)Owner).Delete();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Owner.Opacity = this.trackBar1.Value / 100.0d;
        }
    }
}
