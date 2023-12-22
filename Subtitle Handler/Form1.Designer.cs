namespace Subtitle_Handler
{
    partial class Form1
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
            dataGridView = new DataGridView();
            panelMenu = new Panel();
            minBtn = new Button();
            maxBtn = new Button();
            closeWindowBtn = new Button();
            syncBtn = new Button();
            saveBtn = new Button();
            openFileBtn = new Button();
            timeTextBox = new RichTextBox();
            extractBtn = new Button();
            contentTextBox = new RichTextBox();
            addRowBtn = new Button();
            dltRowBtn = new Button();
            lightBlueBtn = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 45);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(538, 237);
            dataGridView.TabIndex = 0;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.Transparent;
            panelMenu.Controls.Add(minBtn);
            panelMenu.Controls.Add(maxBtn);
            panelMenu.Controls.Add(closeWindowBtn);
            panelMenu.Controls.Add(syncBtn);
            panelMenu.Controls.Add(saveBtn);
            panelMenu.Controls.Add(openFileBtn);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(562, 39);
            panelMenu.TabIndex = 1;
            panelMenu.MouseDown += panelMenu_MouseDown;
            // 
            // minBtn
            // 
            minBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            minBtn.FlatAppearance.BorderSize = 0;
            minBtn.FlatStyle = FlatStyle.Flat;
            minBtn.ForeColor = SystemColors.ButtonFace;
            minBtn.Image = Properties.Resources.min_24;
            minBtn.Location = new Point(484, 4);
            minBtn.Margin = new Padding(0);
            minBtn.Name = "minBtn";
            minBtn.Size = new Size(19, 20);
            minBtn.TabIndex = 6;
            minBtn.TextAlign = ContentAlignment.MiddleLeft;
            minBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            minBtn.UseVisualStyleBackColor = true;
            minBtn.Click += minBtn_Click;
            // 
            // maxBtn
            // 
            maxBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            maxBtn.FlatAppearance.BorderSize = 0;
            maxBtn.FlatStyle = FlatStyle.Flat;
            maxBtn.ForeColor = SystemColors.ButtonFace;
            maxBtn.Image = Properties.Resources.max_24;
            maxBtn.Location = new Point(506, 4);
            maxBtn.Margin = new Padding(0);
            maxBtn.Name = "maxBtn";
            maxBtn.Size = new Size(19, 20);
            maxBtn.TabIndex = 5;
            maxBtn.TextAlign = ContentAlignment.MiddleLeft;
            maxBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            maxBtn.UseVisualStyleBackColor = true;
            maxBtn.Click += maxBtn_Click;
            // 
            // closeWindowBtn
            // 
            closeWindowBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeWindowBtn.FlatAppearance.BorderSize = 0;
            closeWindowBtn.FlatStyle = FlatStyle.Flat;
            closeWindowBtn.ForeColor = SystemColors.ButtonFace;
            closeWindowBtn.Image = Properties.Resources.close_24;
            closeWindowBtn.Location = new Point(528, 4);
            closeWindowBtn.Margin = new Padding(0);
            closeWindowBtn.Name = "closeWindowBtn";
            closeWindowBtn.Size = new Size(19, 20);
            closeWindowBtn.TabIndex = 4;
            closeWindowBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            closeWindowBtn.UseVisualStyleBackColor = true;
            closeWindowBtn.Click += closeWindowBtn_Click;
            // 
            // syncBtn
            // 
            syncBtn.FlatAppearance.BorderSize = 0;
            syncBtn.FlatStyle = FlatStyle.Flat;
            syncBtn.ForeColor = SystemColors.ActiveCaptionText;
            syncBtn.Image = Properties.Resources.sync;
            syncBtn.ImageAlign = ContentAlignment.MiddleLeft;
            syncBtn.Location = new Point(138, 3);
            syncBtn.Margin = new Padding(0);
            syncBtn.Name = "syncBtn";
            syncBtn.Size = new Size(74, 33);
            syncBtn.TabIndex = 8;
            syncBtn.Text = "Sync";
            syncBtn.TextAlign = ContentAlignment.MiddleRight;
            syncBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            saveBtn.FlatAppearance.BorderSize = 0;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.ForeColor = SystemColors.ButtonFace;
            saveBtn.Image = Properties.Resources.save_32;
            saveBtn.Location = new Point(66, 4);
            saveBtn.Margin = new Padding(0);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(33, 33);
            saveBtn.TabIndex = 3;
            saveBtn.TextAlign = ContentAlignment.MiddleLeft;
            saveBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // openFileBtn
            // 
            openFileBtn.FlatAppearance.BorderSize = 0;
            openFileBtn.FlatStyle = FlatStyle.Flat;
            openFileBtn.ForeColor = SystemColors.ButtonFace;
            openFileBtn.Image = Properties.Resources.open_files_32;
            openFileBtn.Location = new Point(12, 3);
            openFileBtn.Margin = new Padding(0);
            openFileBtn.Name = "openFileBtn";
            openFileBtn.Size = new Size(33, 33);
            openFileBtn.TabIndex = 2;
            openFileBtn.UseVisualStyleBackColor = true;
            // 
            // timeTextBox
            // 
            timeTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            timeTextBox.Location = new Point(12, 288);
            timeTextBox.Name = "timeTextBox";
            timeTextBox.Size = new Size(145, 29);
            timeTextBox.TabIndex = 3;
            timeTextBox.Text = "";
            // 
            // extractBtn
            // 
            extractBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            extractBtn.FlatAppearance.BorderSize = 0;
            extractBtn.FlatStyle = FlatStyle.Flat;
            extractBtn.ForeColor = SystemColors.ActiveCaptionText;
            extractBtn.Image = Properties.Resources.separate;
            extractBtn.ImageAlign = ContentAlignment.TopCenter;
            extractBtn.Location = new Point(506, 357);
            extractBtn.Margin = new Padding(0);
            extractBtn.Name = "extractBtn";
            extractBtn.Size = new Size(56, 55);
            extractBtn.TabIndex = 7;
            extractBtn.Text = "Extract";
            extractBtn.TextAlign = ContentAlignment.BottomCenter;
            extractBtn.UseVisualStyleBackColor = true;
            // 
            // contentTextBox
            // 
            contentTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            contentTextBox.Location = new Point(12, 328);
            contentTextBox.Name = "contentTextBox";
            contentTextBox.Size = new Size(200, 71);
            contentTextBox.TabIndex = 9;
            contentTextBox.Text = "";
            // 
            // addRowBtn
            // 
            addRowBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addRowBtn.FlatAppearance.BorderSize = 0;
            addRowBtn.FlatStyle = FlatStyle.Flat;
            addRowBtn.ForeColor = SystemColors.ButtonFace;
            addRowBtn.Image = Properties.Resources.add_row_24;
            addRowBtn.ImageAlign = ContentAlignment.BottomRight;
            addRowBtn.Location = new Point(484, 286);
            addRowBtn.Margin = new Padding(0);
            addRowBtn.Name = "addRowBtn";
            addRowBtn.Size = new Size(30, 25);
            addRowBtn.TabIndex = 10;
            addRowBtn.TextAlign = ContentAlignment.MiddleLeft;
            addRowBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            addRowBtn.UseVisualStyleBackColor = true;
            // 
            // dltRowBtn
            // 
            dltRowBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            dltRowBtn.FlatAppearance.BorderSize = 0;
            dltRowBtn.FlatStyle = FlatStyle.Flat;
            dltRowBtn.ForeColor = SystemColors.ButtonFace;
            dltRowBtn.Image = Properties.Resources.dlt_row_24;
            dltRowBtn.ImageAlign = ContentAlignment.BottomRight;
            dltRowBtn.Location = new Point(520, 288);
            dltRowBtn.Margin = new Padding(0);
            dltRowBtn.Name = "dltRowBtn";
            dltRowBtn.Size = new Size(30, 25);
            dltRowBtn.TabIndex = 11;
            dltRowBtn.TextAlign = ContentAlignment.MiddleLeft;
            dltRowBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            dltRowBtn.UseVisualStyleBackColor = true;
            // 
            // lightBlueBtn
            // 
            lightBlueBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lightBlueBtn.FlatAppearance.BorderSize = 0;
            lightBlueBtn.FlatStyle = FlatStyle.Flat;
            lightBlueBtn.ForeColor = SystemColors.ButtonFace;
            lightBlueBtn.Image = Properties.Resources.light_blue_man;
            lightBlueBtn.Location = new Point(233, 317);
            lightBlueBtn.Margin = new Padding(0);
            lightBlueBtn.Name = "lightBlueBtn";
            lightBlueBtn.Size = new Size(29, 29);
            lightBlueBtn.TabIndex = 12;
            lightBlueBtn.TextAlign = ContentAlignment.TopLeft;
            lightBlueBtn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Image = Properties.Resources.blue_man;
            button1.Location = new Point(233, 288);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(29, 29);
            button1.TabIndex = 13;
            button1.TextAlign = ContentAlignment.TopLeft;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Image = Properties.Resources.green_man;
            button2.Location = new Point(233, 346);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(29, 29);
            button2.TabIndex = 14;
            button2.TextAlign = ContentAlignment.TopLeft;
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = SystemColors.ButtonFace;
            button3.Image = Properties.Resources.yellow_man;
            button3.Location = new Point(233, 375);
            button3.Margin = new Padding(0);
            button3.Name = "button3";
            button3.Size = new Size(29, 29);
            button3.TabIndex = 15;
            button3.TextAlign = ContentAlignment.TopLeft;
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = SystemColors.ButtonFace;
            button4.Image = Properties.Resources.brown_woman;
            button4.Location = new Point(272, 346);
            button4.Margin = new Padding(0);
            button4.Name = "button4";
            button4.Size = new Size(29, 29);
            button4.TabIndex = 16;
            button4.TextAlign = ContentAlignment.TopLeft;
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = SystemColors.ButtonFace;
            button5.Image = Properties.Resources.orange_woman;
            button5.Location = new Point(272, 375);
            button5.Margin = new Padding(0);
            button5.Name = "button5";
            button5.Size = new Size(29, 29);
            button5.TabIndex = 17;
            button5.TextAlign = ContentAlignment.TopLeft;
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = SystemColors.ButtonFace;
            button6.Image = Properties.Resources.purple_woman;
            button6.Location = new Point(272, 288);
            button6.Margin = new Padding(0);
            button6.Name = "button6";
            button6.Size = new Size(29, 29);
            button6.TabIndex = 18;
            button6.TextAlign = ContentAlignment.TopLeft;
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = SystemColors.ButtonFace;
            button7.Image = Properties.Resources.red_woman;
            button7.Location = new Point(272, 317);
            button7.Margin = new Padding(0);
            button7.Name = "button7";
            button7.Size = new Size(29, 29);
            button7.TabIndex = 19;
            button7.TextAlign = ContentAlignment.TopLeft;
            button7.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 411);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lightBlueBtn);
            Controls.Add(dltRowBtn);
            Controls.Add(addRowBtn);
            Controls.Add(contentTextBox);
            Controls.Add(timeTextBox);
            Controls.Add(extractBtn);
            Controls.Add(panelMenu);
            Controls.Add(dataGridView);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private Panel panelMenu;
        private Button openFileBtn;
        private Button saveBtn;
        private Button minBtn;
        private Button maxBtn;
        private Button closeWindowBtn;
        private RichTextBox timeTextBox;
        private Button extractBtn;
        private Button syncBtn;
        private RichTextBox contentTextBox;
        private Button addRowBtn;
        private Button dltRowBtn;
        private Button lightBlueBtn;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}
