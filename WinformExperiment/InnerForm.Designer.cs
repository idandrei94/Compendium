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
            this.resultList.MultiSelect = false;
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(724, 398);
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
            // InnerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(749, 489);
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
    }
}