namespace NoteClient
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnDelete = new Controls.Button();
            trackBar1 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(328, 55);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDelete.BackColor = Color.White;
            btnDelete.DialogResult = DialogResult.Cancel;
            btnDelete.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.FromArgb(233, 31, 0);
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(0, 103);
            btnDelete.Margin = new Padding(0);
            btnDelete.MourceState = -1;
            btnDelete.MouseDownBackColor = Color.FromArgb(40, 0, 0, 0);
            btnDelete.MouseOverBackColor = Color.FromArgb(30, 0, 0, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Padding = new Padding(6, 0, 0, 0);
            btnDelete.Size = new Size(328, 46);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "删除便签";
            btnDelete.TextAlign = ContentAlignment.MiddleCenter;
            btnDelete.Click += btnDelete_Click;
            // 
            // trackBar1
            // 
            trackBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBar1.LargeChange = 1;
            trackBar1.Location = new Point(0, 55);
            trackBar1.Margin = new Padding(0);
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 30;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(328, 45);
            trackBar1.TabIndex = 3;
            trackBar1.Value = 100;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(328, 150);
            Controls.Add(trackBar1);
            Controls.Add(btnDelete);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MenuForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "MenuForm";
            Load += MenuForm_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Controls.Button btnDelete;
        private TrackBar trackBar1;
    }
}