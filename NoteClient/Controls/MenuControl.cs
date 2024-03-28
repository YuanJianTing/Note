using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteClient.Controls
{
    public partial class MenuControl : UserControl
    {
        private Color[] colors = {Color.FromArgb(238, 215, 103), Color.FromArgb(161, 239, 155), Color.FromArgb(255, 175, 223),
            Color.FromArgb(215,175,255), Color.FromArgb(154,217,248) , Color.FromArgb(223,223,223), Color.FromArgb(118,118,118)};

        public MenuControl()
        {
            InitializeComponent();
        }

        private void MenuControl_Load(object sender, EventArgs e)
        {
            LoadColor();
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
                this.flowLayoutPanel1.Controls.Add(colorView);
            }
        }

     
    }
}
