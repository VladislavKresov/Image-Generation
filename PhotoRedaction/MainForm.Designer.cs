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
            this.checkBoxFrames = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_Apply = new System.Windows.Forms.Button();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.BTN_SaveAll = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.BTN_Prew = new System.Windows.Forms.Button();
            this.BTN_Next = new System.Windows.Forms.Button();
            this.BTN_ChooseOut = new System.Windows.Forms.Button();
            this.BTN_ChooseFile = new System.Windows.Forms.Button();
            this.BTN_SavePathToOut = new System.Windows.Forms.Button();
            this.BTN_SaveFile = new System.Windows.Forms.Button();
            this.trackBarRight = new System.Windows.Forms.TrackBar();
            this.trackBarLeft = new System.Windows.Forms.TrackBar();
            this.TB_PathToFile = new System.Windows.Forms.TextBox();
            this.TB_PathToSave = new System.Windows.Forms.TextBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.panelFormBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLeft)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFormBackground
            // 
            this.panelFormBackground.Controls.Add(this.checkBoxFrames);
            this.panelFormBackground.Controls.Add(this.label3);
            this.panelFormBackground.Controls.Add(this.label2);
            this.panelFormBackground.Controls.Add(this.BTN_Cancel);
            this.panelFormBackground.Controls.Add(this.label1);
            this.panelFormBackground.Controls.Add(this.BTN_Apply);
            this.panelFormBackground.Controls.Add(this.comboBoxMode);
            this.panelFormBackground.Controls.Add(this.BTN_SaveAll);
            this.panelFormBackground.Controls.Add(this.labelPath);
            this.panelFormBackground.Controls.Add(this.BTN_Prew);
            this.panelFormBackground.Controls.Add(this.BTN_Next);
            this.panelFormBackground.Controls.Add(this.BTN_ChooseOut);
            this.panelFormBackground.Controls.Add(this.BTN_ChooseFile);
            this.panelFormBackground.Controls.Add(this.BTN_SavePathToOut);
            this.panelFormBackground.Controls.Add(this.BTN_SaveFile);
            this.panelFormBackground.Controls.Add(this.trackBarRight);
            this.panelFormBackground.Controls.Add(this.trackBarLeft);
            this.panelFormBackground.Controls.Add(this.TB_PathToFile);
            this.panelFormBackground.Controls.Add(this.TB_PathToSave);
            this.panelFormBackground.Controls.Add(this.panelRight);
            this.panelFormBackground.Controls.Add(this.panelLeft);
            this.panelFormBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormBackground.Location = new System.Drawing.Point(0, 0);
            this.panelFormBackground.Name = "panelFormBackground";
            this.panelFormBackground.Size = new System.Drawing.Size(1343, 682);
            this.panelFormBackground.TabIndex = 0;
            // 
            // checkBoxFrames
            // 
            this.checkBoxFrames.AutoSize = true;
            this.checkBoxFrames.Location = new System.Drawing.Point(446, 553);
            this.checkBoxFrames.Name = "checkBoxFrames";
            this.checkBoxFrames.Size = new System.Drawing.Size(174, 21);
            this.checkBoxFrames.TabIndex = 14;
            this.checkBoxFrames.Text = "Показывать разметку";
            this.checkBoxFrames.UseVisualStyleBackColor = true;
            this.checkBoxFrames.CheckedChanged += new System.EventHandler(this.checkBoxFrames_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 628);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(361, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Путь к файлу записи (укажите, или оставьте пустым)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 584);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Путь к файлу разметки";
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Enabled = false;
            this.BTN_Cancel.Location = new System.Drawing.Point(982, 638);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(109, 32);
            this.BTN_Cancel.TabIndex = 11;
            this.BTN_Cancel.Text = "Отменить";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(629, 623);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Эффект";
            // 
            // BTN_Apply
            // 
            this.BTN_Apply.Enabled = false;
            this.BTN_Apply.Location = new System.Drawing.Point(874, 638);
            this.BTN_Apply.Name = "BTN_Apply";
            this.BTN_Apply.Size = new System.Drawing.Size(101, 32);
            this.BTN_Apply.TabIndex = 9;
            this.BTN_Apply.Text = "Применить";
            this.BTN_Apply.UseVisualStyleBackColor = true;
            this.BTN_Apply.Click += new System.EventHandler(this.BTN_Apply_Click);
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.Enabled = false;
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Items.AddRange(new object[] {
            "нет",
            "Размытие",
            "Осветление",
            "Затемнение",
            "оттенки серого",
            "Блики",
            "Поворот на 90",
            "Растяжение",
            "Сдвиг"});
            this.comboBoxMode.Location = new System.Drawing.Point(632, 643);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(236, 24);
            this.comboBoxMode.TabIndex = 8;
            this.comboBoxMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxMode_SelectedIndexChanged);
            // 
            // BTN_SaveAll
            // 
            this.BTN_SaveAll.Location = new System.Drawing.Point(1206, 638);
            this.BTN_SaveAll.Name = "BTN_SaveAll";
            this.BTN_SaveAll.Size = new System.Drawing.Size(123, 32);
            this.BTN_SaveAll.TabIndex = 7;
            this.BTN_SaveAll.Text = "Сохранить все";
            this.BTN_SaveAll.UseVisualStyleBackColor = true;
            this.BTN_SaveAll.Click += new System.EventHandler(this.BTN_SaveAll_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(12, 9);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(0, 17);
            this.labelPath.TabIndex = 6;
            // 
            // BTN_Prew
            // 
            this.BTN_Prew.Location = new System.Drawing.Point(1125, 545);
            this.BTN_Prew.Name = "BTN_Prew";
            this.BTN_Prew.Size = new System.Drawing.Size(101, 35);
            this.BTN_Prew.TabIndex = 5;
            this.BTN_Prew.Text = "Предыдущее";
            this.BTN_Prew.UseVisualStyleBackColor = true;
            this.BTN_Prew.Click += new System.EventHandler(this.BTN_Prew_Click);
            // 
            // BTN_Next
            // 
            this.BTN_Next.Location = new System.Drawing.Point(1232, 545);
            this.BTN_Next.Name = "BTN_Next";
            this.BTN_Next.Size = new System.Drawing.Size(97, 35);
            this.BTN_Next.TabIndex = 5;
            this.BTN_Next.Text = "Следующее";
            this.BTN_Next.UseVisualStyleBackColor = true;
            this.BTN_Next.Click += new System.EventHandler(this.BTN_Next_Click);
            // 
            // BTN_ChooseOut
            // 
            this.BTN_ChooseOut.Location = new System.Drawing.Point(542, 647);
            this.BTN_ChooseOut.Name = "BTN_ChooseOut";
            this.BTN_ChooseOut.Size = new System.Drawing.Size(62, 23);
            this.BTN_ChooseOut.TabIndex = 4;
            this.BTN_ChooseOut.Text = "Выбор";
            this.BTN_ChooseOut.UseVisualStyleBackColor = true;
            this.BTN_ChooseOut.Click += new System.EventHandler(this.BTN_ChooseOut_Click);
            // 
            // BTN_ChooseFile
            // 
            this.BTN_ChooseFile.Location = new System.Drawing.Point(542, 600);
            this.BTN_ChooseFile.Name = "BTN_ChooseFile";
            this.BTN_ChooseFile.Size = new System.Drawing.Size(62, 25);
            this.BTN_ChooseFile.TabIndex = 4;
            this.BTN_ChooseFile.Text = "Выбор";
            this.BTN_ChooseFile.UseVisualStyleBackColor = true;
            this.BTN_ChooseFile.Click += new System.EventHandler(this.BTN_ChooseFile_Click);
            // 
            // BTN_SavePathToOut
            // 
            this.BTN_SavePathToOut.Location = new System.Drawing.Point(446, 647);
            this.BTN_SavePathToOut.Name = "BTN_SavePathToOut";
            this.BTN_SavePathToOut.Size = new System.Drawing.Size(90, 23);
            this.BTN_SavePathToOut.TabIndex = 4;
            this.BTN_SavePathToOut.Text = "Сохранить";
            this.BTN_SavePathToOut.UseVisualStyleBackColor = true;
            this.BTN_SavePathToOut.Click += new System.EventHandler(this.BTN_SavePathToOut_Click);
            // 
            // BTN_SaveFile
            // 
            this.BTN_SaveFile.Location = new System.Drawing.Point(446, 600);
            this.BTN_SaveFile.Name = "BTN_SaveFile";
            this.BTN_SaveFile.Size = new System.Drawing.Size(90, 25);
            this.BTN_SaveFile.TabIndex = 4;
            this.BTN_SaveFile.Text = "Сохранить";
            this.BTN_SaveFile.UseVisualStyleBackColor = true;
            this.BTN_SaveFile.Click += new System.EventHandler(this.BTN_SaveFile_Click);
            // 
            // trackBarRight
            // 
            this.trackBarRight.Location = new System.Drawing.Point(679, 545);
            this.trackBarRight.Maximum = 100;
            this.trackBarRight.Name = "trackBarRight";
            this.trackBarRight.Size = new System.Drawing.Size(425, 56);
            this.trackBarRight.TabIndex = 3;
            this.trackBarRight.Scroll += new System.EventHandler(this.trackBarRight_Scroll);
            // 
            // trackBarLeft
            // 
            this.trackBarLeft.Location = new System.Drawing.Point(13, 545);
            this.trackBarLeft.Maximum = 100;
            this.trackBarLeft.Name = "trackBarLeft";
            this.trackBarLeft.Size = new System.Drawing.Size(425, 56);
            this.trackBarLeft.TabIndex = 3;
            this.trackBarLeft.Scroll += new System.EventHandler(this.trackBarLeft_Scroll);
            // 
            // TB_PathToFile
            // 
            this.TB_PathToFile.Location = new System.Drawing.Point(13, 602);
            this.TB_PathToFile.Name = "TB_PathToFile";
            this.TB_PathToFile.Size = new System.Drawing.Size(426, 22);
            this.TB_PathToFile.TabIndex = 2;
            // 
            // TB_PathToSave
            // 
            this.TB_PathToSave.Location = new System.Drawing.Point(13, 648);
            this.TB_PathToSave.Name = "TB_PathToSave";
            this.TB_PathToSave.Size = new System.Drawing.Size(426, 22);
            this.TB_PathToSave.TabIndex = 1;
            // 
            // panelRight
            // 
            this.panelRight.AutoScroll = true;
            this.panelRight.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelRight.Controls.Add(this.pictureBoxRight);
            this.panelRight.Location = new System.Drawing.Point(678, 42);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(651, 497);
            this.panelRight.TabIndex = 0;
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxRight.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(651, 497);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRight.TabIndex = 0;
            this.pictureBoxRight.TabStop = false;
            // 
            // panelLeft
            // 
            this.panelLeft.AutoScroll = true;
            this.panelLeft.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelLeft.Controls.Add(this.pictureBoxLeft);
            this.panelLeft.Location = new System.Drawing.Point(13, 42);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(651, 497);
            this.panelLeft.TabIndex = 0;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(651, 497);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLeft.TabIndex = 0;
            this.pictureBoxLeft.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 682);
            this.Controls.Add(this.panelFormBackground);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panelFormBackground.ResumeLayout(false);
            this.panelFormBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLeft)).EndInit();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFormBackground;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.Button BTN_Prew;
        private System.Windows.Forms.Button BTN_Next;
        private System.Windows.Forms.Button BTN_ChooseOut;
        private System.Windows.Forms.Button BTN_ChooseFile;
        private System.Windows.Forms.Button BTN_SavePathToOut;
        private System.Windows.Forms.Button BTN_SaveFile;
        private System.Windows.Forms.TrackBar trackBarRight;
        private System.Windows.Forms.TrackBar trackBarLeft;
        private System.Windows.Forms.TextBox TB_PathToFile;
        private System.Windows.Forms.TextBox TB_PathToSave;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button BTN_Apply;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Button BTN_SaveAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxFrames;
    }
}

