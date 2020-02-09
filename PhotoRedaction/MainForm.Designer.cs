namespace PhotoRedaction
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelFormBackground = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxFrames = new System.Windows.Forms.CheckBox();
            this.trackBarLeft = new System.Windows.Forms.TrackBar();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.trackBarRight = new System.Windows.Forms.TrackBar();
            this.BTN_Prev = new System.Windows.Forms.Button();
            this.BTN_Next = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTN_SaveAll = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.BTN_Apply = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelPath = new System.Windows.Forms.Label();
            this.panelFormBackground.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLeft)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRight)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFormBackground
            // 
            this.panelFormBackground.Controls.Add(this.tableLayoutPanel1);
            this.panelFormBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormBackground.Location = new System.Drawing.Point(0, 0);
            this.panelFormBackground.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelFormBackground.Name = "panelFormBackground";
            this.panelFormBackground.Size = new System.Drawing.Size(1399, 641);
            this.panelFormBackground.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.328605F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.67139F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1399, 641);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel3, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panelRight, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelLeft, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 46);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.12872F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.87129F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1391, 531);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.checkBoxFrames);
            this.flowLayoutPanel2.Controls.Add(this.trackBarLeft);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 466);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(687, 61);
            this.flowLayoutPanel2.TabIndex = 18;
            // 
            // checkBoxFrames
            // 
            this.checkBoxFrames.AutoSize = true;
            this.checkBoxFrames.Location = new System.Drawing.Point(3, 2);
            this.checkBoxFrames.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxFrames.Name = "checkBoxFrames";
            this.checkBoxFrames.Size = new System.Drawing.Size(106, 21);
            this.checkBoxFrames.TabIndex = 14;
            this.checkBoxFrames.Text = "Show marks";
            this.checkBoxFrames.UseVisualStyleBackColor = true;
            this.checkBoxFrames.CheckedChanged += new System.EventHandler(this.checkBoxFrames_CheckedChanged);
            // 
            // trackBarLeft
            // 
            this.trackBarLeft.Location = new System.Drawing.Point(115, 2);
            this.trackBarLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBarLeft.Name = "trackBarLeft";
            this.trackBarLeft.Size = new System.Drawing.Size(425, 56);
            this.trackBarLeft.TabIndex = 3;
            this.trackBarLeft.Scroll += new System.EventHandler(this.trackBarLeft_Scroll);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.trackBarRight);
            this.flowLayoutPanel3.Controls.Add(this.BTN_Prev);
            this.flowLayoutPanel3.Controls.Add(this.BTN_Next);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(699, 466);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(688, 61);
            this.flowLayoutPanel3.TabIndex = 19;
            // 
            // trackBarRight
            // 
            this.trackBarRight.Location = new System.Drawing.Point(3, 2);
            this.trackBarRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBarRight.Name = "trackBarRight";
            this.trackBarRight.Size = new System.Drawing.Size(425, 56);
            this.trackBarRight.TabIndex = 3;
            this.trackBarRight.Scroll += new System.EventHandler(this.trackBarRight_Scroll);
            // 
            // BTN_Prev
            // 
            this.BTN_Prev.Location = new System.Drawing.Point(452, 2);
            this.BTN_Prev.Margin = new System.Windows.Forms.Padding(21, 2, 3, 2);
            this.BTN_Prev.Name = "BTN_Prev";
            this.BTN_Prev.Size = new System.Drawing.Size(101, 34);
            this.BTN_Prev.TabIndex = 5;
            this.BTN_Prev.Text = "Previous";
            this.BTN_Prev.UseVisualStyleBackColor = true;
            this.BTN_Prev.Click += new System.EventHandler(this.BTN_Prew_Click);
            // 
            // BTN_Next
            // 
            this.BTN_Next.Location = new System.Drawing.Point(559, 2);
            this.BTN_Next.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Next.Name = "BTN_Next";
            this.BTN_Next.Size = new System.Drawing.Size(97, 34);
            this.BTN_Next.TabIndex = 5;
            this.BTN_Next.Text = "Next";
            this.BTN_Next.UseVisualStyleBackColor = true;
            this.BTN_Next.Click += new System.EventHandler(this.BTN_Next_Click);
            // 
            // panelRight
            // 
            this.panelRight.AutoScroll = true;
            this.panelRight.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelRight.Controls.Add(this.pictureBoxRight);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(698, 2);
            this.panelRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(690, 458);
            this.panelRight.TabIndex = 0;
            this.panelRight.SizeChanged += new System.EventHandler(this.panelRight_SizeChanged);
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxRight.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(691, 455);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRight.TabIndex = 0;
            this.pictureBoxRight.TabStop = false;
            // 
            // panelLeft
            // 
            this.panelLeft.AutoScroll = true;
            this.panelLeft.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelLeft.Controls.Add(this.pictureBoxLeft);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(3, 2);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(689, 458);
            this.panelLeft.TabIndex = 0;
            this.panelLeft.SizeChanged += new System.EventHandler(this.panelLeft_SizeChanged);
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(687, 455);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLeft.TabIndex = 0;
            this.pictureBoxLeft.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BTN_SaveAll);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Cancel);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Apply);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 585);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1391, 52);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // BTN_SaveAll
            // 
            this.BTN_SaveAll.Location = new System.Drawing.Point(1265, 2);
            this.BTN_SaveAll.Margin = new System.Windows.Forms.Padding(21, 2, 3, 2);
            this.BTN_SaveAll.Name = "BTN_SaveAll";
            this.BTN_SaveAll.Size = new System.Drawing.Size(123, 32);
            this.BTN_SaveAll.TabIndex = 7;
            this.BTN_SaveAll.Text = "Create all";
            this.BTN_SaveAll.UseVisualStyleBackColor = true;
            this.BTN_SaveAll.Click += new System.EventHandler(this.BTN_SaveAll_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Enabled = false;
            this.BTN_Cancel.Location = new System.Drawing.Point(1132, 2);
            this.BTN_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(109, 32);
            this.BTN_Cancel.TabIndex = 11;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // BTN_Apply
            // 
            this.BTN_Apply.Enabled = false;
            this.BTN_Apply.Location = new System.Drawing.Point(1025, 2);
            this.BTN_Apply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Apply.Name = "BTN_Apply";
            this.BTN_Apply.Size = new System.Drawing.Size(101, 32);
            this.BTN_Apply.TabIndex = 9;
            this.BTN_Apply.Text = "Apply";
            this.BTN_Apply.UseVisualStyleBackColor = true;
            this.BTN_Apply.Click += new System.EventHandler(this.BTN_Apply_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxMode);
            this.panel1.Location = new System.Drawing.Point(778, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 48);
            this.panel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Effect";
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.Enabled = false;
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Items.AddRange(new object[] {
            "No effects",
            "Blur",
            "Lightening",
            "Blackout",
            "Grayscale",
            "Glare",
            "Rotate 90",
            "Stretch",
            "Shift"});
            this.comboBoxMode.Location = new System.Drawing.Point(3, 4);
            this.comboBoxMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(236, 24);
            this.comboBoxMode.TabIndex = 8;
            this.comboBoxMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxMode_SelectedIndexChanged);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.menuStrip1);
            this.flowLayoutPanel4.Controls.Add(this.labelPath);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(1391, 34);
            this.flowLayoutPanel4.TabIndex = 19;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(56, 28);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelPath.Location = new System.Drawing.Point(59, 11);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(0, 17);
            this.labelPath.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1399, 641);
            this.Controls.Add(this.panelFormBackground);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1321, 640);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panelFormBackground.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLeft)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRight)).EndInit();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFormBackground;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.Button BTN_Prev;
        private System.Windows.Forms.Button BTN_Next;
        private System.Windows.Forms.TrackBar trackBarRight;
        private System.Windows.Forms.TrackBar trackBarLeft;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button BTN_Apply;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Button BTN_SaveAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.CheckBox checkBoxFrames;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    }
}

