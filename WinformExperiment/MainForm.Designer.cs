namespace Compendium
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newButton = new System.Windows.Forms.ToolStripButton();
            this.loadButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripSplitButton();
            this.saveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.filterButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.tagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hasTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doesntHaveTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beforeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keywordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.addNoteButton = new System.Windows.Forms.ToolStripButton();
            this.databaseTabs = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.loadButton,
            this.saveButton,
            this.filterButton,
            this.sendToButton,
            this.addNoteButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newButton
            // 
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newButton.Image = ((System.Drawing.Image)(resources.GetObject("newButton.Image")));
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(35, 22);
            this.newButton.Text = "New";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loadButton.Image = ((System.Drawing.Image)(resources.GetObject("loadButton.Image")));
            this.loadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(37, 22);
            this.loadButton.Text = "Load";
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAll,
            this.saveCurrent});
            this.saveButton.Enabled = false;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(47, 22);
            this.saveButton.Text = "Save";
            this.saveButton.ButtonClick += new System.EventHandler(this.saveButton_ButtonClick);
            // 
            // saveAll
            // 
            this.saveAll.Name = "saveAll";
            this.saveAll.Size = new System.Drawing.Size(114, 22);
            this.saveAll.Text = "All";
            this.saveAll.Click += new System.EventHandler(this.saveAll_Click);
            // 
            // saveCurrent
            // 
            this.saveCurrent.Name = "saveCurrent";
            this.saveCurrent.Size = new System.Drawing.Size(114, 22);
            this.saveCurrent.Text = "Current";
            this.saveCurrent.Click += new System.EventHandler(this.saveCurrent_Click);
            // 
            // filterButton
            // 
            this.filterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.filterButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tagToolStripMenuItem,
            this.dateToolStripMenuItem,
            this.keywordToolStripMenuItem});
            this.filterButton.Enabled = false;
            this.filterButton.Image = ((System.Drawing.Image)(resources.GetObject("filterButton.Image")));
            this.filterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(71, 22);
            this.filterButton.Text = "Add Filter";
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // tagToolStripMenuItem
            // 
            this.tagToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hasTagToolStripMenuItem,
            this.doesntHaveTagToolStripMenuItem});
            this.tagToolStripMenuItem.Name = "tagToolStripMenuItem";
            this.tagToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.tagToolStripMenuItem.Text = "Tag";
            // 
            // hasTagToolStripMenuItem
            // 
            this.hasTagToolStripMenuItem.Name = "hasTagToolStripMenuItem";
            this.hasTagToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.hasTagToolStripMenuItem.Text = "With";
            this.hasTagToolStripMenuItem.Click += new System.EventHandler(this.hasTagToolStripMenuItem_Click);
            // 
            // doesntHaveTagToolStripMenuItem
            // 
            this.doesntHaveTagToolStripMenuItem.Name = "doesntHaveTagToolStripMenuItem";
            this.doesntHaveTagToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.doesntHaveTagToolStripMenuItem.Text = "Without";
            this.doesntHaveTagToolStripMenuItem.Click += new System.EventHandler(this.doesntHaveTagToolStripMenuItem_Click);
            // 
            // dateToolStripMenuItem
            // 
            this.dateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beforeToolStripMenuItem,
            this.afterToolStripMenuItem});
            this.dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            this.dateToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.dateToolStripMenuItem.Text = "Date";
            // 
            // beforeToolStripMenuItem
            // 
            this.beforeToolStripMenuItem.Name = "beforeToolStripMenuItem";
            this.beforeToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.beforeToolStripMenuItem.Text = "Before";
            this.beforeToolStripMenuItem.Click += new System.EventHandler(this.beforeToolStripMenuItem_Click);
            // 
            // afterToolStripMenuItem
            // 
            this.afterToolStripMenuItem.Name = "afterToolStripMenuItem";
            this.afterToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.afterToolStripMenuItem.Text = "After";
            this.afterToolStripMenuItem.Click += new System.EventHandler(this.afterToolStripMenuItem_Click);
            // 
            // keywordToolStripMenuItem
            // 
            this.keywordToolStripMenuItem.Name = "keywordToolStripMenuItem";
            this.keywordToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.keywordToolStripMenuItem.Text = "Keyword";
            this.keywordToolStripMenuItem.Click += new System.EventHandler(this.keywordToolStripMenuItem_Click);
            // 
            // sendToButton
            // 
            this.sendToButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sendToButton.Image = ((System.Drawing.Image)(resources.GetObject("sendToButton.Image")));
            this.sendToButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sendToButton.Name = "sendToButton";
            this.sendToButton.Size = new System.Drawing.Size(60, 22);
            this.sendToButton.Text = "Send to";
            // 
            // addNoteButton
            // 
            this.addNoteButton.AutoSize = false;
            this.addNoteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addNoteButton.Enabled = false;
            this.addNoteButton.Image = ((System.Drawing.Image)(resources.GetObject("addNoteButton.Image")));
            this.addNoteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addNoteButton.Name = "addNoteButton";
            this.addNoteButton.Size = new System.Drawing.Size(23, 22);
            this.addNoteButton.Text = "Add Note";
            this.addNoteButton.Click += new System.EventHandler(this.addNoteButton_Click);
            // 
            // databaseTabs
            // 
            this.databaseTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.databaseTabs.HotTrack = true;
            this.databaseTabs.Location = new System.Drawing.Point(13, 28);
            this.databaseTabs.Name = "databaseTabs";
            this.databaseTabs.Padding = new System.Drawing.Point(8, 6);
            this.databaseTabs.SelectedIndex = 0;
            this.databaseTabs.ShowToolTips = true;
            this.databaseTabs.Size = new System.Drawing.Size(759, 521);
            this.databaseTabs.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.databaseTabs.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.databaseTabs);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Compendium";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newButton;
        private System.Windows.Forms.ToolStripButton loadButton;
        private System.Windows.Forms.ToolStripSplitButton saveButton;
        private System.Windows.Forms.ToolStripMenuItem saveAll;
        private System.Windows.Forms.ToolStripMenuItem saveCurrent;
        private System.Windows.Forms.TabControl databaseTabs;
        private System.Windows.Forms.ToolStripDropDownButton filterButton;
        private System.Windows.Forms.ToolStripMenuItem tagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hasTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doesntHaveTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beforeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keywordToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton addNoteButton;
        private System.Windows.Forms.ToolStripDropDownButton sendToButton;
    }
}