namespace SPZLab7Var1
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
            this.teacherCreateButton = new System.Windows.Forms.Button();
            this.teacherEditButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.teacherDeleteButton = new System.Windows.Forms.Button();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teachersDataGridView = new System.Windows.Forms.DataGridView();
            this.SubjectNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectFacultyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.subjectCreateButton = new System.Windows.Forms.Button();
            this.subjectEditButton = new System.Windows.Forms.Button();
            this.subjectDeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.teachersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // teacherCreateButton
            // 
            this.teacherCreateButton.Location = new System.Drawing.Point(12, 37);
            this.teacherCreateButton.Name = "teacherCreateButton";
            this.teacherCreateButton.Size = new System.Drawing.Size(75, 23);
            this.teacherCreateButton.TabIndex = 1;
            this.teacherCreateButton.Text = "Создать";
            this.teacherCreateButton.UseVisualStyleBackColor = true;
            this.teacherCreateButton.Click += new System.EventHandler(this.teacherCreateButton_Click);
            // 
            // teacherEditButton
            // 
            this.teacherEditButton.Location = new System.Drawing.Point(93, 37);
            this.teacherEditButton.Name = "teacherEditButton";
            this.teacherEditButton.Size = new System.Drawing.Size(104, 23);
            this.teacherEditButton.TabIndex = 2;
            this.teacherEditButton.Text = "Редактировать";
            this.teacherEditButton.UseVisualStyleBackColor = true;
            this.teacherEditButton.Click += new System.EventHandler(this.teacherEditButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Учителя";
            // 
            // teacherDeleteButton
            // 
            this.teacherDeleteButton.Location = new System.Drawing.Point(203, 37);
            this.teacherDeleteButton.Name = "teacherDeleteButton";
            this.teacherDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.teacherDeleteButton.TabIndex = 4;
            this.teacherDeleteButton.Text = "Удалить";
            this.teacherDeleteButton.UseVisualStyleBackColor = true;
            this.teacherDeleteButton.Click += new System.EventHandler(this.teacherDeleteButton_Click);
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Имя";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // AgeColumn
            // 
            this.AgeColumn.HeaderText = "Возраст";
            this.AgeColumn.Name = "AgeColumn";
            this.AgeColumn.ReadOnly = true;
            // 
            // teachersDataGridView
            // 
            this.teachersDataGridView.AllowUserToAddRows = false;
            this.teachersDataGridView.AllowUserToDeleteRows = false;
            this.teachersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.teachersDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.teachersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teachersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.AgeColumn});
            this.teachersDataGridView.Location = new System.Drawing.Point(12, 66);
            this.teachersDataGridView.Name = "teachersDataGridView";
            this.teachersDataGridView.ReadOnly = true;
            this.teachersDataGridView.Size = new System.Drawing.Size(357, 188);
            this.teachersDataGridView.TabIndex = 0;
            this.teachersDataGridView.Text = "dataGridView1";
            // 
            // SubjectNameColumn
            // 
            this.SubjectNameColumn.HeaderText = "Имя";
            this.SubjectNameColumn.Name = "SubjectNameColumn";
            this.SubjectNameColumn.ReadOnly = true;
            this.SubjectNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SubjectFacultyColumn
            // 
            this.SubjectFacultyColumn.HeaderText = "Факультет";
            this.SubjectFacultyColumn.Name = "SubjectFacultyColumn";
            this.SubjectFacultyColumn.ReadOnly = true;
            // 
            // subjectDataGridView
            // 
            this.subjectDataGridView.AllowUserToAddRows = false;
            this.subjectDataGridView.AllowUserToDeleteRows = false;
            this.subjectDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.subjectDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.subjectDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectNameColumn,
            this.SubjectFacultyColumn});
            this.subjectDataGridView.Location = new System.Drawing.Point(375, 66);
            this.subjectDataGridView.Name = "subjectDataGridView";
            this.subjectDataGridView.ReadOnly = true;
            this.subjectDataGridView.Size = new System.Drawing.Size(357, 188);
            this.subjectDataGridView.TabIndex = 5;
            this.subjectDataGridView.Text = "dataGridView1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(631, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Предметы";
            // 
            // subjectCreateButton
            // 
            this.subjectCreateButton.Location = new System.Drawing.Point(657, 37);
            this.subjectCreateButton.Name = "subjectCreateButton";
            this.subjectCreateButton.Size = new System.Drawing.Size(75, 23);
            this.subjectCreateButton.TabIndex = 7;
            this.subjectCreateButton.Text = "Создать";
            this.subjectCreateButton.UseVisualStyleBackColor = true;
            this.subjectCreateButton.Click += new System.EventHandler(this.subjectCreateButton_Click);
            // 
            // subjectEditButton
            // 
            this.subjectEditButton.Location = new System.Drawing.Point(554, 37);
            this.subjectEditButton.Name = "subjectEditButton";
            this.subjectEditButton.Size = new System.Drawing.Size(97, 23);
            this.subjectEditButton.TabIndex = 8;
            this.subjectEditButton.Text = "Редактировать";
            this.subjectEditButton.UseVisualStyleBackColor = true;
            this.subjectEditButton.Click += new System.EventHandler(this.subjectEditButton_Click);
            // 
            // subjectDeleteButton
            // 
            this.subjectDeleteButton.Location = new System.Drawing.Point(473, 37);
            this.subjectDeleteButton.Name = "subjectDeleteButton";
            this.subjectDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.subjectDeleteButton.TabIndex = 9;
            this.subjectDeleteButton.Text = "Удалить";
            this.subjectDeleteButton.UseVisualStyleBackColor = true;
            this.subjectDeleteButton.Click += new System.EventHandler(this.subjectDeleteButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(744, 264);
            this.Controls.Add(this.subjectDeleteButton);
            this.Controls.Add(this.subjectEditButton);
            this.Controls.Add(this.subjectCreateButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subjectDataGridView);
            this.Controls.Add(this.teacherDeleteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.teacherEditButton);
            this.Controls.Add(this.teacherCreateButton);
            this.Controls.Add(this.teachersDataGridView);
            this.Name = "MainForm";
            this.Text = "SPZ";
            ((System.ComponentModel.ISupportInitialize)(this.teachersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button teacherCreateButton;
        private System.Windows.Forms.Button teacherEditButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView teachersDataGridView;
        private System.Windows.Forms.Button teacherDeleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgeColumn;
        private System.Windows.Forms.DataGridView subjectDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectFacultyColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button subjectCreateButton;
        private System.Windows.Forms.Button subjectEditButton;
        private System.Windows.Forms.Button subjectDeleteButton;
    }
}

