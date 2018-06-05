namespace Compendium
{
    partial class InnerForm
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
            this.filtersLabel = new System.Windows.Forms.Label();
            this.filterList = new System.Windows.Forms.TabControl();
            this.resultList = new System.Windows.Forms.ListView();
            this.currentNoteTags = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.prevPage = new System.Windows.Forms.Button();
            this.nextPage = new System.Windows.Forms.Button();
            this.resultCountLabel = new System.Windows.Forms.Label();
            this.currentPageEditable = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // filtersLabel
            // 
            this.filtersLabel.AutoSize = true;
            this.filtersLabel.Location = new System.Drawing.Point(12, 16);
            this.filtersLabel.Name = "filtersLabel";
            this.filtersLabel.Size = new System.Drawing.Size(37, 13);
            this.filtersLabel.TabIndex = 1;
            this.filtersLabel.Text = "Filters:";
            // 
            // filterList
            // 
            this.filterList.Location = new System.Drawing.Point(55, 12);
            this.filterList.Name = "filterList";
            this.filterList.SelectedIndex = 0;
            this.filterList.Size = new System.Drawing.Size(682, 20);
            this.filterList.TabIndex = 2;
            this.filterList.SelectedIndexChanged += new System.EventHandler(this.filterList_SelectedIndexChanged);
            this.filterList.Click += new System.EventHandler(this.filterList_Click);
            // 
            // resultList
            // 
            this.resultList.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.resultList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultList.GridLines = true;
            this.resultList.Location = new System.Drawing.Point(13, 45);
            this.resultList.Margin = new System.Windows.Forms.Padding(10);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(724, 368);
            this.resultList.TabIndex = 3;
            this.resultList.UseCompatibleStateImageBehavior = false;
            this.resultList.SelectedIndexChanged += new System.EventHandler(this.resultList_SelectedIndexChanged);
            this.resultList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.resultList_DoubleClick);
            // 
            // currentNoteTags
            // 
            this.currentNoteTags.Location = new System.Drawing.Point(55, 457);
            this.currentNoteTags.Name = "currentNoteTags";
            this.currentNoteTags.SelectedIndex = 0;
            this.currentNoteTags.Size = new System.Drawing.Size(682, 20);
            this.currentNoteTags.TabIndex = 4;
            this.currentNoteTags.Visible = false;
            this.currentNoteTags.SelectedIndexChanged += new System.EventHandler(this.currentNoteTags_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 457);
            this.label1.MinimumSize = new System.Drawing.Size(0, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tags:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prevPage
            // 
            this.prevPage.Enabled = false;
            this.prevPage.Location = new System.Drawing.Point(519, 425);
            this.prevPage.Name = "prevPage";
            this.prevPage.Size = new System.Drawing.Size(25, 25);
            this.prevPage.TabIndex = 6;
            this.prevPage.Text = "<";
            this.prevPage.UseVisualStyleBackColor = true;
            this.prevPage.Click += new System.EventHandler(this.prevPage_Click);
            // 
            // nextPage
            // 
            this.nextPage.Enabled = false;
            this.nextPage.Location = new System.Drawing.Point(656, 426);
            this.nextPage.Name = "nextPage";
            this.nextPage.Size = new System.Drawing.Size(25, 25);
            this.nextPage.TabIndex = 7;
            this.nextPage.Text = ">";
            this.nextPage.UseVisualStyleBackColor = true;
            this.nextPage.Click += new System.EventHandler(this.nextPage_Click);
            // 
            // resultCountLabel
            // 
            this.resultCountLabel.AutoSize = true;
            this.resultCountLabel.Location = new System.Drawing.Point(12, 425);
            this.resultCountLabel.MinimumSize = new System.Drawing.Size(300, 25);
            this.resultCountLabel.Name = "resultCountLabel";
            this.resultCountLabel.Size = new System.Drawing.Size(300, 25);
            this.resultCountLabel.TabIndex = 9;
            this.resultCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // currentPageEditable
            // 
            this.currentPageEditable.Location = new System.Drawing.Point(550, 428);
            this.currentPageEditable.MaxLength = 10;
            this.currentPageEditable.Name = "currentPageEditable";
            this.currentPageEditable.Size = new System.Drawing.Size(100, 20);
            this.currentPageEditable.TabIndex = 10;
            this.currentPageEditable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 425);
            this.label2.MinimumSize = new System.Drawing.Size(0, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Page";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InnerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(749, 489);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentPageEditable);
            this.Controls.Add(this.resultCountLabel);
            this.Controls.Add(this.nextPage);
            this.Controls.Add(this.prevPage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentNoteTags);
            this.Controls.Add(this.resultList);
            this.Controls.Add(this.filterList);
            this.Controls.Add(this.filtersLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InnerForm";
            this.Text = "InnerForm";
            this.Load += new System.EventHandler(this.InnerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label filtersLabel;
        private System.Windows.Forms.TabControl filterList;
        private System.Windows.Forms.ListView resultList;
        private System.Windows.Forms.TabControl currentNoteTags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button prevPage;
        private System.Windows.Forms.Button nextPage;
        private System.Windows.Forms.Label resultCountLabel;
        private System.Windows.Forms.TextBox currentPageEditable;
        private System.Windows.Forms.Label label2;
    }
}