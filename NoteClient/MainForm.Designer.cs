namespace NoteClient
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            rtxContent = new RichTextBox();
            panel1 = new Panel();
            btnMore = new Controls.ImageButton();
            btnClose = new Controls.ImageButton();
            btnAddForm = new Controls.ImageButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnBold = new Controls.ImageButton();
            btnItalic = new Controls.ImageButton();
            btnUnderline = new Controls.ImageButton();
            btnStrikethrough = new Controls.ImageButton();
            lineView1 = new Controls.LineView();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // rtxContent
            // 
            rtxContent.BackColor = Color.FromArgb(255, 247, 209);
            rtxContent.BorderStyle = BorderStyle.None;
            rtxContent.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point);
            rtxContent.ForeColor = SystemColors.ActiveCaptionText;
            rtxContent.Location = new Point(5, 43);
            rtxContent.Name = "rtxContent";
            rtxContent.Size = new Size(308, 279);
            rtxContent.TabIndex = 0;
            rtxContent.Text = "";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(255, 242, 171);
            panel1.Controls.Add(btnMore);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(btnAddForm);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(315, 40);
            panel1.TabIndex = 1;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // btnMore
            // 
            btnMore.BackColor = Color.Transparent;
            btnMore.DialogResult = DialogResult.Cancel;
            btnMore.Image = Properties.Resources.more;
            btnMore.Location = new Point(244, 0);
            btnMore.Margin = new Padding(0);
            btnMore.MourceState = -1;
            btnMore.MouseDownBackColor = Color.FromArgb(50, 0, 0, 0);
            btnMore.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0);
            btnMore.Name = "btnMore";
            btnMore.Size = new Size(36, 40);
            btnMore.TabIndex = 4;
            btnMore.Click += btnMore_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Dock = DockStyle.Right;
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(279, 0);
            btnClose.Margin = new Padding(0);
            btnClose.MourceState = -1;
            btnClose.MouseDownBackColor = Color.FromArgb(50, 0, 0, 0);
            btnClose.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(36, 40);
            btnClose.TabIndex = 3;
            btnClose.Click += btnClose_Click;
            // 
            // btnAddForm
            // 
            btnAddForm.BackColor = Color.Transparent;
            btnAddForm.DialogResult = DialogResult.Cancel;
            btnAddForm.Image = Properties.Resources.add;
            btnAddForm.Location = new Point(0, 0);
            btnAddForm.Margin = new Padding(0);
            btnAddForm.MourceState = -1;
            btnAddForm.MouseDownBackColor = Color.FromArgb(50, 0, 0, 0);
            btnAddForm.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0);
            btnAddForm.Name = "btnAddForm";
            btnAddForm.Size = new Size(36, 40);
            btnAddForm.TabIndex = 2;
            btnAddForm.Click += btnAddForm_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(btnBold);
            flowLayoutPanel1.Controls.Add(btnItalic);
            flowLayoutPanel1.Controls.Add(btnUnderline);
            flowLayoutPanel1.Controls.Add(btnStrikethrough);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 330);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(6, 0, 0, 0);
            flowLayoutPanel1.Size = new Size(315, 40);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.MouseDown += panel1_MouseDown;
            // 
            // btnBold
            // 
            btnBold.BackColor = Color.Transparent;
            btnBold.DialogResult = DialogResult.Cancel;
            btnBold.Image = Properties.Resources.粗体;
            btnBold.Location = new Point(6, 0);
            btnBold.Margin = new Padding(0);
            btnBold.MourceState = -1;
            btnBold.MouseDownBackColor = Color.FromArgb(50, 0, 0, 0);
            btnBold.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0);
            btnBold.Name = "btnBold";
            btnBold.Size = new Size(36, 35);
            btnBold.TabIndex = 3;
            btnBold.Click += btnBold_Click;
            // 
            // btnItalic
            // 
            btnItalic.BackColor = Color.Transparent;
            btnItalic.DialogResult = DialogResult.Cancel;
            btnItalic.Image = Properties.Resources.斜体;
            btnItalic.Location = new Point(42, 0);
            btnItalic.Margin = new Padding(0);
            btnItalic.MourceState = -1;
            btnItalic.MouseDownBackColor = Color.FromArgb(50, 0, 0, 0);
            btnItalic.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0);
            btnItalic.Name = "btnItalic";
            btnItalic.Size = new Size(36, 35);
            btnItalic.TabIndex = 4;
            btnItalic.Click += btnItalic_Click;
            // 
            // btnUnderline
            // 
            btnUnderline.BackColor = Color.Transparent;
            btnUnderline.DialogResult = DialogResult.Cancel;
            btnUnderline.Image = Properties.Resources.字体下划线;
            btnUnderline.Location = new Point(78, 0);
            btnUnderline.Margin = new Padding(0);
            btnUnderline.MourceState = -1;
            btnUnderline.MouseDownBackColor = Color.FromArgb(50, 0, 0, 0);
            btnUnderline.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0);
            btnUnderline.Name = "btnUnderline";
            btnUnderline.Size = new Size(36, 35);
            btnUnderline.TabIndex = 5;
            btnUnderline.Click += btnUnderline_Click;
            // 
            // btnStrikethrough
            // 
            btnStrikethrough.BackColor = Color.Transparent;
            btnStrikethrough.DialogResult = DialogResult.Cancel;
            btnStrikethrough.Image = Properties.Resources.字体删除线;
            btnStrikethrough.Location = new Point(114, 0);
            btnStrikethrough.Margin = new Padding(0);
            btnStrikethrough.MourceState = -1;
            btnStrikethrough.MouseDownBackColor = Color.FromArgb(50, 0, 0, 0);
            btnStrikethrough.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0);
            btnStrikethrough.Name = "btnStrikethrough";
            btnStrikethrough.Size = new Size(36, 35);
            btnStrikethrough.TabIndex = 6;
            btnStrikethrough.Click += btnStrikethrough_Click;
            // 
            // lineView1
            // 
            lineView1.BackColor = Color.Transparent;
            lineView1.LineColor = SystemColors.ControlLight;
            lineView1.LineWeight = 1;
            lineView1.Location = new Point(0, 327);
            lineView1.Margin = new Padding(0);
            lineView1.Name = "lineView1";
            lineView1.Size = new Size(320, 2);
            lineView1.TabIndex = 3;
            lineView1.Text = "lineView1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 247, 209);
            ClientSize = new Size(315, 370);
            Controls.Add(lineView1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(rtxContent);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "便签";
            Activated += MainForm_Activated;
            Deactivate += MainForm_Deactivate;
            Load += MainForm_Load;
            LocationChanged += MainForm_LocationChanged;
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtxContent;
        private Panel panel1;
        private Controls.ImageButton btnAddForm;
        private Controls.ImageButton btnClose;
        private Controls.ImageButton btnMore;
        private FlowLayoutPanel flowLayoutPanel1;
        private Controls.ImageButton btnBold;
        private Controls.ImageButton btnItalic;
        private Controls.ImageButton btnUnderline;
        private Controls.ImageButton btnStrikethrough;
        private Controls.LineView lineView1;
    }
}
