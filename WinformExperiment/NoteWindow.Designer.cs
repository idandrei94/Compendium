namespace Compendium
{
    partial class NoteWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteWindow));
            this.bodyBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.added = new System.Windows.Forms.Label();
            this.dateAddedLabel = new System.Windows.Forms.Label();
            this.tagsEditable = new System.Windows.Forms.TextBox();
            this.tagLabel = new System.Windows.Forms.Label();
            this.tagsUneditable = new System.Windows.Forms.TabControl();
            this.updatedLabel = new System.Windows.Forms.Label();
            this.dateUpdatedLabel = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.Label();
            this.titleEditableBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bodyBox
            // 
            this.bodyBox.Location = new System.Drawing.Point(12, 139);
            this.bodyBox.MaxLength = 1500;
            this.bodyBox.Multiline = true;
            this.bodyBox.Name = "bodyBox";
            this.bodyBox.ReadOnly = true;
            this.bodyBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.bodyBox.Size = new System.Drawing.Size(460, 410);
            this.bodyBox.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(344, 76);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 25);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(344, 76);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 25);
            this.editButton.TabIndex = 5;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // added
            // 
            this.added.AutoSize = true;
            this.added.Location = new System.Drawing.Point(13, 90);
            this.added.Name = "added";
            this.added.Size = new System.Drawing.Size(41, 13);
            this.added.TabIndex = 6;
            this.added.Text = "Added:";
            // 
            // dateAddedLabel
            // 
            this.dateAddedLabel.AutoSize = true;
            this.dateAddedLabel.Location = new System.Drawing.Point(67, 90);
            this.dateAddedLabel.MinimumSize = new System.Drawing.Size(150, 0);
            this.dateAddedLabel.Name = "dateAddedLabel";
            this.dateAddedLabel.Size = new System.Drawing.Size(150, 13);
            this.dateAddedLabel.TabIndex = 7;
            // 
            // tagsEditable
            // 
            this.tagsEditable.Location = new System.Drawing.Point(46, 50);
            this.tagsEditable.Name = "tagsEditable";
            this.tagsEditable.Size = new System.Drawing.Size(426, 20);
            this.tagsEditable.TabIndex = 9;
            this.tagsEditable.Visible = false;
            // 
            // tagLabel
            // 
            this.tagLabel.AutoSize = true;
            this.tagLabel.Location = new System.Drawing.Point(9, 53);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(31, 13);
            this.tagLabel.TabIndex = 11;
            this.tagLabel.Text = "Tags";
            // 
            // tagsUneditable
            // 
            this.tagsUneditable.Location = new System.Drawing.Point(46, 50);
            this.tagsUneditable.Name = "tagsUneditable";
            this.tagsUneditable.SelectedIndex = 0;
            this.tagsUneditable.Size = new System.Drawing.Size(426, 20);
            this.tagsUneditable.TabIndex = 12;
            this.tagsUneditable.SelectedIndexChanged += new System.EventHandler(this.tagsUneditable_SelectedIndexChanged);
            // 
            // updatedLabel
            // 
            this.updatedLabel.AutoSize = true;
            this.updatedLabel.Location = new System.Drawing.Point(13, 115);
            this.updatedLabel.Name = "updatedLabel";
            this.updatedLabel.Size = new System.Drawing.Size(48, 13);
            this.updatedLabel.TabIndex = 13;
            this.updatedLabel.Text = "Updated";
            // 
            // dateUpdatedLabel
            // 
            this.dateUpdatedLabel.AutoSize = true;
            this.dateUpdatedLabel.Location = new System.Drawing.Point(67, 115);
            this.dateUpdatedLabel.MinimumSize = new System.Drawing.Size(150, 0);
            this.dateUpdatedLabel.Name = "dateUpdatedLabel";
            this.dateUpdatedLabel.Size = new System.Drawing.Size(150, 13);
            this.dateUpdatedLabel.TabIndex = 14;
            // 
            // titleBox
            // 
            this.titleBox.AutoSize = true;
            this.titleBox.Location = new System.Drawing.Point(13, 13);
            this.titleBox.MinimumSize = new System.Drawing.Size(460, 20);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(460, 20);
            this.titleBox.TabIndex = 15;
            this.titleBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleEditableBox
            // 
            this.titleEditableBox.Location = new System.Drawing.Point(12, 13);
            this.titleEditableBox.MaxLength = 70;
            this.titleEditableBox.Name = "titleEditableBox";
            this.titleEditableBox.Size = new System.Drawing.Size(460, 20);
            this.titleEditableBox.TabIndex = 16;
            this.titleEditableBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.titleEditableBox.Visible = false;
            // 
            // deleteButton
            // 
            this.deleteButton.ForeColor = System.Drawing.Color.Red;
            this.deleteButton.Location = new System.Drawing.Point(344, 103);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 25);
            this.deleteButton.TabIndex = 17;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // NoteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.titleEditableBox);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.dateUpdatedLabel);
            this.Controls.Add(this.updatedLabel);
            this.Controls.Add(this.tagsUneditable);
            this.Controls.Add(this.tagLabel);
            this.Controls.Add(this.tagsEditable);
            this.Controls.Add(this.dateAddedLabel);
            this.Controls.Add(this.added);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.bodyBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NoteWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NoteWindow";
            this.Load += new System.EventHandler(this.NoteWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox bodyBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label added;
        private System.Windows.Forms.Label dateAddedLabel;
        private System.Windows.Forms.TextBox tagsEditable;
        private System.Windows.Forms.Label tagLabel;
        private System.Windows.Forms.TabControl tagsUneditable;
        private System.Windows.Forms.Label updatedLabel;
        private System.Windows.Forms.Label dateUpdatedLabel;
        private System.Windows.Forms.Label titleBox;
        private System.Windows.Forms.TextBox titleEditableBox;
        private System.Windows.Forms.Button deleteButton;
    }
}