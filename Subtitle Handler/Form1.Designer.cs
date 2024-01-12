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
            startTimeTextBox = new RichTextBox();
            extractBtn = new Button();
            contentTextBox = new RichTextBox();
            addRowBtn = new Button();
            dltRowBtn = new Button();
            lightBlueBtn = new Button();
            blueBtn = new Button();
            greenBtn = new Button();
            yellowBtn = new Button();
            brownBtn = new Button();
            orangeBtn = new Button();
            purpleBtn = new Button();
            pinkBtn = new Button();
            updateBtn = new Button();
            endTimeTextBox = new RichTextBox();
            panelStartTime = new Panel();
            panelEndTime = new Panel();
            panelMenu = new Panel();
            minBtn = new Button();
            maxBtn = new Button();
            closeWindowBtn = new Button();
            saveBtn = new Button();
            openFileBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panelStartTime.SuspendLayout();
            panelEndTime.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = Color.Thistle;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.GridColor = Color.IndianRed;
            dataGridView.Location = new Point(12, 49);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(650, 223);
            dataGridView.TabIndex = 0;
            dataGridView.RowPostPaint += dataGridView_RowPostPaint;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            // 
            // startTimeTextBox
            // 
            startTimeTextBox.BorderStyle = BorderStyle.None;
            startTimeTextBox.Location = new Point(3, 4);
            startTimeTextBox.Name = "startTimeTextBox";
            startTimeTextBox.Size = new Size(67, 18);
            startTimeTextBox.TabIndex = 3;
            startTimeTextBox.Text = "";
            // 
            // extractBtn
            // 
            extractBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            extractBtn.FlatAppearance.BorderSize = 0;
            extractBtn.FlatAppearance.MouseDownBackColor = SystemColors.GradientInactiveCaption;
            extractBtn.FlatAppearance.MouseOverBackColor = SystemColors.GradientInactiveCaption;
            extractBtn.FlatStyle = FlatStyle.Flat;
            extractBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            extractBtn.ForeColor = Color.FromArgb(64, 64, 64);
            extractBtn.Image = Properties.Resources.separate;
            extractBtn.ImageAlign = ContentAlignment.TopCenter;
            extractBtn.Location = new Point(609, 327);
            extractBtn.Margin = new Padding(0);
            extractBtn.Name = "extractBtn";
            extractBtn.Size = new Size(56, 55);
            extractBtn.TabIndex = 7;
            extractBtn.Text = "Extract";
            extractBtn.TextAlign = ContentAlignment.BottomCenter;
            extractBtn.UseVisualStyleBackColor = true;
            extractBtn.Click += extractBtn_Click;
            // 
            // contentTextBox
            // 
            contentTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            contentTextBox.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            contentTextBox.ForeColor = Color.FromArgb(64, 64, 64);
            contentTextBox.Location = new Point(104, 288);
            contentTextBox.Name = "contentTextBox";
            contentTextBox.Size = new Size(333, 62);
            contentTextBox.TabIndex = 9;
            contentTextBox.Text = "";
            // 
            // addRowBtn
            // 
            addRowBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addRowBtn.FlatAppearance.BorderSize = 0;
            addRowBtn.FlatAppearance.MouseDownBackColor = SystemColors.GradientInactiveCaption;
            addRowBtn.FlatAppearance.MouseOverBackColor = SystemColors.GradientInactiveCaption;
            addRowBtn.FlatStyle = FlatStyle.Flat;
            addRowBtn.ForeColor = SystemColors.ButtonFace;
            addRowBtn.Image = Properties.Resources.add_row_24;
            addRowBtn.ImageAlign = ContentAlignment.BottomRight;
            addRowBtn.Location = new Point(595, 282);
            addRowBtn.Margin = new Padding(0);
            addRowBtn.Name = "addRowBtn";
            addRowBtn.Size = new Size(30, 25);
            addRowBtn.TabIndex = 10;
            addRowBtn.TextAlign = ContentAlignment.MiddleLeft;
            addRowBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            addRowBtn.UseVisualStyleBackColor = true;
            addRowBtn.Click += addRowBtn_Click;
            // 
            // dltRowBtn
            // 
            dltRowBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            dltRowBtn.FlatAppearance.BorderSize = 0;
            dltRowBtn.FlatAppearance.MouseDownBackColor = SystemColors.GradientInactiveCaption;
            dltRowBtn.FlatAppearance.MouseOverBackColor = SystemColors.GradientInactiveCaption;
            dltRowBtn.FlatStyle = FlatStyle.Flat;
            dltRowBtn.ForeColor = SystemColors.ButtonFace;
            dltRowBtn.Image = Properties.Resources.dlt_row_24;
            dltRowBtn.ImageAlign = ContentAlignment.BottomRight;
            dltRowBtn.Location = new Point(631, 284);
            dltRowBtn.Margin = new Padding(0);
            dltRowBtn.Name = "dltRowBtn";
            dltRowBtn.Size = new Size(30, 25);
            dltRowBtn.TabIndex = 11;
            dltRowBtn.TextAlign = ContentAlignment.MiddleLeft;
            dltRowBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            dltRowBtn.UseVisualStyleBackColor = true;
            dltRowBtn.Click += dltRowBtn_Click;
            // 
            // lightBlueBtn
            // 
            lightBlueBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lightBlueBtn.FlatAppearance.BorderSize = 0;
            lightBlueBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(163, 214, 255);
            lightBlueBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(163, 214, 255);
            lightBlueBtn.FlatStyle = FlatStyle.Flat;
            lightBlueBtn.ForeColor = SystemColors.ButtonFace;
            lightBlueBtn.Image = Properties.Resources.light_blue_man;
            lightBlueBtn.Location = new Point(489, 288);
            lightBlueBtn.Margin = new Padding(0);
            lightBlueBtn.Name = "lightBlueBtn";
            lightBlueBtn.Size = new Size(29, 29);
            lightBlueBtn.TabIndex = 12;
            lightBlueBtn.TextAlign = ContentAlignment.TopLeft;
            lightBlueBtn.UseVisualStyleBackColor = true;
            lightBlueBtn.Click += lightBlueBtn_Click;
            // 
            // blueBtn
            // 
            blueBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            blueBtn.FlatAppearance.BorderSize = 0;
            blueBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(65, 160, 216);
            blueBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 160, 216);
            blueBtn.FlatStyle = FlatStyle.Flat;
            blueBtn.ForeColor = SystemColors.ButtonFace;
            blueBtn.Image = Properties.Resources.blue_man;
            blueBtn.Location = new Point(460, 288);
            blueBtn.Margin = new Padding(0);
            blueBtn.Name = "blueBtn";
            blueBtn.Size = new Size(29, 29);
            blueBtn.TabIndex = 13;
            blueBtn.TextAlign = ContentAlignment.TopLeft;
            blueBtn.UseVisualStyleBackColor = true;
            blueBtn.Click += blueBtn_Click;
            // 
            // greenBtn
            // 
            greenBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            greenBtn.FlatAppearance.BorderSize = 0;
            greenBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(161, 202, 114);
            greenBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(161, 202, 114);
            greenBtn.FlatStyle = FlatStyle.Flat;
            greenBtn.ForeColor = SystemColors.ButtonFace;
            greenBtn.Image = Properties.Resources.green_man;
            greenBtn.Location = new Point(518, 288);
            greenBtn.Margin = new Padding(0);
            greenBtn.Name = "greenBtn";
            greenBtn.Size = new Size(29, 29);
            greenBtn.TabIndex = 14;
            greenBtn.TextAlign = ContentAlignment.TopLeft;
            greenBtn.UseVisualStyleBackColor = true;
            greenBtn.Click += greenBtn_Click;
            // 
            // yellowBtn
            // 
            yellowBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            yellowBtn.FlatAppearance.BorderSize = 0;
            yellowBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 112);
            yellowBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 224, 112);
            yellowBtn.FlatStyle = FlatStyle.Flat;
            yellowBtn.ForeColor = SystemColors.ButtonFace;
            yellowBtn.Image = Properties.Resources.yellow_man;
            yellowBtn.Location = new Point(547, 288);
            yellowBtn.Margin = new Padding(0);
            yellowBtn.Name = "yellowBtn";
            yellowBtn.Size = new Size(29, 29);
            yellowBtn.TabIndex = 15;
            yellowBtn.TextAlign = ContentAlignment.TopLeft;
            yellowBtn.UseVisualStyleBackColor = true;
            yellowBtn.Click += yellowBtn_Click;
            // 
            // brownBtn
            // 
            brownBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            brownBtn.FlatAppearance.BorderSize = 0;
            brownBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(249, 123, 123);
            brownBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(249, 123, 123);
            brownBtn.FlatStyle = FlatStyle.Flat;
            brownBtn.ForeColor = SystemColors.ButtonFace;
            brownBtn.Image = Properties.Resources.brown_woman;
            brownBtn.Location = new Point(518, 321);
            brownBtn.Margin = new Padding(0);
            brownBtn.Name = "brownBtn";
            brownBtn.Size = new Size(29, 29);
            brownBtn.TabIndex = 16;
            brownBtn.TextAlign = ContentAlignment.TopLeft;
            brownBtn.UseVisualStyleBackColor = true;
            brownBtn.Click += brownBtn_Click;
            // 
            // orangeBtn
            // 
            orangeBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            orangeBtn.FlatAppearance.BorderSize = 0;
            orangeBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 171, 102);
            orangeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 171, 102);
            orangeBtn.FlatStyle = FlatStyle.Flat;
            orangeBtn.ForeColor = SystemColors.ButtonFace;
            orangeBtn.Image = Properties.Resources.orange_woman;
            orangeBtn.Location = new Point(547, 321);
            orangeBtn.Margin = new Padding(0);
            orangeBtn.Name = "orangeBtn";
            orangeBtn.Size = new Size(29, 29);
            orangeBtn.TabIndex = 17;
            orangeBtn.TextAlign = ContentAlignment.TopLeft;
            orangeBtn.UseVisualStyleBackColor = true;
            orangeBtn.Click += orangeBtn_Click;
            // 
            // purpleBtn
            // 
            purpleBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            purpleBtn.FlatAppearance.BorderSize = 0;
            purpleBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 147, 210);
            purpleBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 147, 210);
            purpleBtn.FlatStyle = FlatStyle.Flat;
            purpleBtn.ForeColor = SystemColors.ButtonFace;
            purpleBtn.Image = Properties.Resources.purple_woman;
            purpleBtn.Location = new Point(460, 321);
            purpleBtn.Margin = new Padding(0);
            purpleBtn.Name = "purpleBtn";
            purpleBtn.Size = new Size(29, 29);
            purpleBtn.TabIndex = 18;
            purpleBtn.TextAlign = ContentAlignment.TopLeft;
            purpleBtn.UseVisualStyleBackColor = true;
            purpleBtn.Click += purpleBtn_Click;
            // 
            // pinkBtn
            // 
            pinkBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pinkBtn.FlatAppearance.BorderSize = 0;
            pinkBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(225, 107, 150);
            pinkBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(225, 107, 150);
            pinkBtn.FlatStyle = FlatStyle.Flat;
            pinkBtn.ForeColor = SystemColors.ButtonFace;
            pinkBtn.Image = Properties.Resources.red_woman;
            pinkBtn.Location = new Point(489, 321);
            pinkBtn.Margin = new Padding(0);
            pinkBtn.Name = "pinkBtn";
            pinkBtn.Size = new Size(29, 29);
            pinkBtn.TabIndex = 19;
            pinkBtn.TextAlign = ContentAlignment.TopLeft;
            pinkBtn.UseVisualStyleBackColor = true;
            pinkBtn.Click += pinkBtn_Click;
            // 
            // updateBtn
            // 
            updateBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            updateBtn.BackColor = Color.LightSteelBlue;
            updateBtn.FlatAppearance.BorderColor = Color.Gray;
            updateBtn.FlatAppearance.BorderSize = 0;
            updateBtn.FlatAppearance.MouseDownBackColor = Color.LightSkyBlue;
            updateBtn.FlatAppearance.MouseOverBackColor = Color.LightSkyBlue;
            updateBtn.FlatStyle = FlatStyle.Flat;
            updateBtn.Font = new Font("Segoe UI", 9F);
            updateBtn.ForeColor = Color.FromArgb(64, 64, 64);
            updateBtn.Location = new Point(362, 355);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(75, 28);
            updateBtn.TabIndex = 20;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = false;
            updateBtn.Click += updateBtn_Click;
            // 
            // endTimeTextBox
            // 
            endTimeTextBox.BorderStyle = BorderStyle.None;
            endTimeTextBox.Location = new Point(3, 4);
            endTimeTextBox.Name = "endTimeTextBox";
            endTimeTextBox.Size = new Size(67, 18);
            endTimeTextBox.TabIndex = 21;
            endTimeTextBox.Text = "";
            // 
            // panelStartTime
            // 
            panelStartTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelStartTime.BackColor = Color.White;
            panelStartTime.Controls.Add(endTimeTextBox);
            panelStartTime.Location = new Point(12, 326);
            panelStartTime.Name = "panelStartTime";
            panelStartTime.Padding = new Padding(3);
            panelStartTime.Size = new Size(73, 24);
            panelStartTime.TabIndex = 22;
            // 
            // panelEndTime
            // 
            panelEndTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelEndTime.BackColor = Color.White;
            panelEndTime.Controls.Add(startTimeTextBox);
            panelEndTime.Location = new Point(12, 288);
            panelEndTime.Name = "panelEndTime";
            panelEndTime.Padding = new Padding(3);
            panelEndTime.Size = new Size(73, 24);
            panelEndTime.TabIndex = 23;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.Transparent;
            panelMenu.Controls.Add(minBtn);
            panelMenu.Controls.Add(maxBtn);
            panelMenu.Controls.Add(closeWindowBtn);
            panelMenu.Controls.Add(saveBtn);
            panelMenu.Controls.Add(openFileBtn);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(674, 47);
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
            minBtn.Location = new Point(594, 4);
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
            maxBtn.Location = new Point(616, 4);
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
            closeWindowBtn.Location = new Point(638, 4);
            closeWindowBtn.Margin = new Padding(0);
            closeWindowBtn.Name = "closeWindowBtn";
            closeWindowBtn.Size = new Size(19, 20);
            closeWindowBtn.TabIndex = 4;
            closeWindowBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            closeWindowBtn.UseVisualStyleBackColor = true;
            closeWindowBtn.Click += closeWindowBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.FlatAppearance.BorderSize = 0;
            saveBtn.FlatAppearance.MouseDownBackColor = SystemColors.GradientInactiveCaption;
            saveBtn.FlatAppearance.MouseOverBackColor = SystemColors.GradientInactiveCaption;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.ForeColor = SystemColors.ButtonFace;
            saveBtn.Image = Properties.Resources.save_32;
            saveBtn.Location = new Point(66, 8);
            saveBtn.Margin = new Padding(0);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(33, 33);
            saveBtn.TabIndex = 3;
            saveBtn.TextAlign = ContentAlignment.MiddleLeft;
            saveBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // openFileBtn
            // 
            openFileBtn.BackColor = Color.Transparent;
            openFileBtn.FlatAppearance.BorderSize = 0;
            openFileBtn.FlatAppearance.MouseDownBackColor = SystemColors.GradientInactiveCaption;
            openFileBtn.FlatAppearance.MouseOverBackColor = SystemColors.GradientInactiveCaption;
            openFileBtn.FlatStyle = FlatStyle.Flat;
            openFileBtn.ForeColor = Color.Transparent;
            openFileBtn.Image = Properties.Resources.open_files_32;
            openFileBtn.Location = new Point(13, 8);
            openFileBtn.Margin = new Padding(0);
            openFileBtn.Name = "openFileBtn";
            openFileBtn.Size = new Size(33, 33);
            openFileBtn.TabIndex = 2;
            openFileBtn.UseVisualStyleBackColor = false;
            openFileBtn.Click += openFileBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(674, 391);
            Controls.Add(panelEndTime);
            Controls.Add(panelStartTime);
            Controls.Add(updateBtn);
            Controls.Add(pinkBtn);
            Controls.Add(purpleBtn);
            Controls.Add(orangeBtn);
            Controls.Add(brownBtn);
            Controls.Add(yellowBtn);
            Controls.Add(greenBtn);
            Controls.Add(blueBtn);
            Controls.Add(lightBlueBtn);
            Controls.Add(dltRowBtn);
            Controls.Add(addRowBtn);
            Controls.Add(contentTextBox);
            Controls.Add(extractBtn);
            Controls.Add(panelMenu);
            Controls.Add(dataGridView);
            MinimumSize = new Size(500, 230);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panelStartTime.ResumeLayout(false);
            panelEndTime.ResumeLayout(false);
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private RichTextBox startTimeTextBox;
        private Button extractBtn;
        private RichTextBox contentTextBox;
        private Button addRowBtn;
        private Button dltRowBtn;
        private Button lightBlueBtn;
        private Button blueBtn;
        private Button greenBtn;
        private Button yellowBtn;
        private Button brownBtn;
        private Button orangeBtn;
        private Button purpleBtn;
        private Button pinkBtn;
        private Button updateBtn;
        private RichTextBox endTimeTextBox;
        private Panel panelStartTime;
        private Panel panelEndTime;
        private Button minBtn;
        private Button maxBtn;
        private Button closeWindowBtn;
        private Button saveBtn;
        private Button openFileBtn;
        private Panel panelMenu;
    }
}
