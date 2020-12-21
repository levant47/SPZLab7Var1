namespace SPZLab7Var1
{
    partial class DetailedSubjectForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.facultyLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.facultyTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.teacherListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(44, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(31, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Имя";
            // 
            // facultyLabel
            // 
            this.facultyLabel.AutoSize = true;
            this.facultyLabel.Location = new System.Drawing.Point(12, 44);
            this.facultyLabel.Name = "facultyLabel";
            this.facultyLabel.Size = new System.Drawing.Size(63, 15);
            this.facultyLabel.TabIndex = 1;
            this.facultyLabel.Text = "Факультет";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(81, 178);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // facultyTextBox
            // 
            this.facultyTextBox.Location = new System.Drawing.Point(81, 41);
            this.facultyTextBox.Name = "facultyTextBox";
            this.facultyTextBox.Size = new System.Drawing.Size(120, 23);
            this.facultyTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(81, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(120, 23);
            this.nameTextBox.TabIndex = 1;
            // 
            // teacherListBox
            // 
            this.teacherListBox.FormattingEnabled = true;
            this.teacherListBox.ItemHeight = 15;
            this.teacherListBox.Location = new System.Drawing.Point(81, 78);
            this.teacherListBox.Name = "teacherListBox";
            this.teacherListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.teacherListBox.Size = new System.Drawing.Size(120, 94);
            this.teacherListBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Учителя";
            // 
            // DetailedSubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 209);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.teacherListBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.facultyTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.facultyLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "DetailedSubjectForm";
            this.Text = "DetailedSubjectForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label facultyLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox facultyTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ListBox teacherListBox;
        private System.Windows.Forms.Label label1;
    }
}