namespace NoteClient.Controls
{
    partial class MenuControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            button1 = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(341, 55);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.White;
            button1.DialogResult = DialogResult.Cancel;
            button1.Image = Properties.Resources.delete;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 56);
            button1.Margin = new Padding(0);
            button1.MourceState = -1;
            button1.MouseDownBackColor = Color.FromArgb(40, 255, 255, 255);
            button1.MouseOverBackColor = Color.FromArgb(30, 255, 255, 255);
            button1.Name = "button1";
            button1.Size = new Size(341, 46);
            button1.TabIndex = 1;
            button1.Text = "删除便签";
            button1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MenuControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button1);
            Controls.Add(flowLayoutPanel1);
            Name = "MenuControl";
            Size = new Size(341, 111);
            Load += MenuControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
    }
}
