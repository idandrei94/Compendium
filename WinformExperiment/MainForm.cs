using System;
using System.IO;
using System.Windows.Forms;

namespace Compendium
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            databaseTabs.MouseClick += databaseTabs_MouseClick;
            FormClosing += (object sender, FormClosingEventArgs e) =>
            {
                foreach (TabPage tab in databaseTabs.TabPages)
                {
                    if ((tab.Controls[0] as InnerForm).Changed)
                    {
                        if (MessageBox.Show("Save database before closing?", tab.Text, MessageBoxButtons.YesNo) == DialogResult.OK)
                        {
                            (tab.Controls[0] as InnerForm).Save();
                        }
                    }
                }
            };
            databaseTabs.SelectedIndexChanged += databaseTabs_SelectedIndexChanged;
        }

        private void MainForm_Load(object sender, EventArgs e) { }

#pragma warning disable IDE1006 // Naming Styles
        private void newButton_Click(object sender, EventArgs e)
        {
            String defaultTitle = "new_db(" + databaseTabs.TabPages.Count + ")";
            using (PromptBox dlg = new PromptBox("New database name", "New database", defaultTitle))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    String title = dlg.Data;
                    Console.WriteLine(title);
                    if (File.Exists(title+".xml"))
                    {
                        MessageBox.Show("Unable to use this name, database already exists in Compendium's folder.", "Error");
                        return;
                    }
                    System.IO.Directory.CreateDirectory("databases");
                    title = title.Equals("") ? defaultTitle : title;
                    String filename = "databases\\" + title + ".xml";
                    title = checkTabTitle(title) + ".xml";
                    load_file(filename, title);
                }
            }
        }

        private void load_file(String filename, String title)
        {

            TabPage page = new TabPage(title)
            {
                Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom,
                Text = title + "*loading"
            };
            databaseTabs.TabPages.Add(page);
            databaseTabs.SelectTab(page);

            page.Controls.Add(new InnerForm(filename, title, page));
            filterButton.Enabled = true;
            addNoteButton.Enabled = true;
            saveButton.Enabled = true;

            GenerateSendToOptions();
        }

        private String checkTabTitle(string title)
        {
            int count = 0;
            bool found = true;
            String ret = title;
            while (found)
            {
                ret = title + (count > 0 ? "(" + count + ")" : "");
                found = false;
                foreach (TabPage tab in databaseTabs.TabPages)
                {
                    if (tab.Text.Equals(ret))
                    {
                        found = true;
                        ++count;
                    }
                }
            }
            return ret;
        }

        private void databaseTabs_MouseClick(object sender, MouseEventArgs e)
        {
            //TODO ask for name
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < databaseTabs.TabPages.Count; ++i)
                {
                    TabPage tab = databaseTabs.TabPages[i];
                    if (databaseTabs.GetTabRect(i).Contains(e.Location))
                    {
                        if ((tab.Controls[0] as InnerForm).Locked)
                        {
                            MessageBox.Show("Unable to close due to work in progress.", "Database busy");
                            return;
                        }
                        if ((tab.Controls[0] as InnerForm).Changed)
                        {
                            switch (MessageBox.Show("Save database before closing?", tab.Text, MessageBoxButtons.YesNoCancel))
                            {
                                case DialogResult.OK:
                                    (tab.Controls[0] as InnerForm).Save();
                                    break;
                                case DialogResult.Cancel:
                                    return;
                            }
                        }
                        (tab.Controls[0] as InnerForm).CloseNotes();
                        databaseTabs.TabPages.Remove(tab);

                        filterButton.Enabled = databaseTabs.TabPages.Count != 0;
                        addNoteButton.Enabled = databaseTabs.TabPages.Count != 0;
                        saveButton.Enabled = databaseTabs.TabPages.Count != 0;

                        GenerateSendToOptions();

                        return;
                    }
                }
            }
        }

        private void hasTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).Locked)
            {
                MessageBox.Show("Unable to add filter due to work in progress.", "Database busy");
                return;
            }
            using (PromptBox dlg = new PromptBox("Tag:", "Add tag filter", "default"))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    (databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).AddDisplayFilter("tag-" + dlg.Data);
                    (databaseTabs.SelectedTab.Controls[0] as InnerForm).AddFilter(Compendium.Model.Filtering.NoteFilterFactory.FilterType.TAG, dlg.Data);
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foreach(TabPage tab in databaseTabs.TabPages)
                    {
                        if ((tab.Controls[0] as InnerForm).File.Equals(dialog.FileName))
                        {
                            MessageBox.Show("Database already open.", "Database opened");
                            databaseTabs.SelectTab(tab);
                            return;
                        }
                    }
                    load_file(dialog.FileName, dialog.SafeFileName);
                }
            }
        }

        private void addNoteButton_Click(object sender, EventArgs e)
        {
            if ((databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).Locked)
            {
                MessageBox.Show("Unable to add filter due to work in progress.", "Database busy");
                return;
            }
            InnerForm page = databaseTabs.SelectedTab.Controls[0] as InnerForm;
            page.NewNote();
        }

        private void beforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).Locked)
            {
                MessageBox.Show("Unable to add filter due to work in progress.", "Database busy");
                return;
            }
            using (DatePromptBox dlg = new DatePromptBox("Date Picker"))
            {
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    (databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).AddDisplayFilter("before-" + dlg.Data.ToShortDateString());
                    InnerForm page = databaseTabs.SelectedTab.Controls[0] as InnerForm;
                    page.AddFilter(Model.Filtering.NoteFilterFactory.FilterType.DATE_BEFORE, dlg.Data);
                }
            }
        }

        private void doesntHaveTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).Locked)
            {
                MessageBox.Show("Unable to add filter due to work in progress.", "Error");
                return;
            }
            using (PromptBox dlg = new PromptBox("Tag:", "Add tag missing filter", "default"))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    (databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).AddDisplayFilter("notag-" + dlg.Data);
                    (databaseTabs.SelectedTab.Controls[0] as InnerForm).AddFilter(Compendium.Model.Filtering.NoteFilterFactory.FilterType.TAG_INVERTED, dlg.Data);
                }
            }
        }

        private void afterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).Locked)
            {
                MessageBox.Show("Unable to add filter due to work in progress.", "Database busy");
                return;
            }
            using (DatePromptBox dlg = new DatePromptBox("Date Picker"))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    (databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).AddDisplayFilter("after-" + dlg.Data.ToShortDateString());
                    (databaseTabs.SelectedTab.Controls[0] as InnerForm).AddFilter(Model.Filtering.NoteFilterFactory.FilterType.DATE_AFTER, dlg.Data);
                }
            }
        }

        private void keywordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).Locked)
            {
                MessageBox.Show("Unable to add filter due to work in progress.", "Error");
                return;
            }
            using (PromptBox dlg = new PromptBox("Keyword:", "Add keyword filter", "default"))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    (databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).AddDisplayFilter("keyword-" + dlg.Data);
                    (databaseTabs.SelectedTab.Controls[0] as InnerForm).AddFilter(Compendium.Model.Filtering.NoteFilterFactory.FilterType.KEYWORD, dlg.Data);
                }
            }
        }

        private void saveCurrent_Click(object sender, EventArgs e)
        {
            if ((databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).Locked)
            {
                MessageBox.Show("Unable to save due to work in progress.", "Database busy");
                return;
            }
            (databaseTabs.SelectedTab.Controls[0] as InnerForm).Save();
        }

        private void saveButton_ButtonClick(object sender, EventArgs e) => saveCurrent_Click(sender, e);

        private void saveAll_Click(object sender, EventArgs e)
        {
            foreach(TabPage tab in databaseTabs.TabPages)
            {
                if ((tab.Controls[0] as InnerForm).Locked)
                {
                    MessageBox.Show("Unable to save due to work in progress.", "Database busy");
                    return;
                }
            }
            foreach(TabPage tab in databaseTabs.TabPages)
            {
                (tab.Controls[0] as InnerForm).Save();
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            if ((databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).Locked)
            {
                MessageBox.Show("Unable to add filter due to work in progress.", "Error");
                return;
            }
        }

        private void databaseTabs_SelectedIndexChanged(object sender, EventArgs args)
        {
            Console.WriteLine("changed tab");

            filterButton.Enabled = databaseTabs.TabPages.Count != 0;
            addNoteButton.Enabled = databaseTabs.TabPages.Count != 0;
            saveButton.Enabled = databaseTabs.TabPages.Count != 0;
            GenerateSendToOptions();
        }

        private void GenerateSendToOptions()
        {
            sendToButton.DropDownItems.Clear();
            foreach (TabPage page in databaseTabs.TabPages)
            {
                if (!page.Equals(databaseTabs.SelectedTab))
                {
                    ToolStripMenuItem db_item = new ToolStripMenuItem(page.Text)
                    {
                        Tag = (page.Controls[0] as InnerForm).File
                    };
                    db_item.Click += (object sender, EventArgs args) =>
                    {
                        int count = (databaseTabs.SelectedTab.Controls[0] as InnerForm).SelectedItems.Length;
                        if (count < 1)
                            return;
                        TabPage destination = null;
                        foreach(TabPage tab in databaseTabs.TabPages)
                        {
                            if((tab.Controls[0] as InnerForm).File.Equals((sender as ToolStripMenuItem).Tag))
                            {
                                destination = tab;
                            }
                        }
                        if(destination == null)
                        {
                            Console.WriteLine("tab not found?!");
                        }
                        if (MessageBox.Show("Send " + count + (count != 1 ? " items to " : " item to ") + destination?.Text + "?", "Confirm" ) == DialogResult.OK)
                        {
                            //Console.WriteLine("Sending items to {0}:", dbname);
                            foreach (String item in (databaseTabs.SelectedTab.Controls[0] as InnerForm).SelectedItems)
                            {
                                Console.WriteLine("      {0}", item);
                                (destination.Controls[0] as InnerForm).NewNote(item);
                            }
                        }
                    };
                    sendToButton.DropDownItems.Add(db_item);
                }
            }
        }
    }
}