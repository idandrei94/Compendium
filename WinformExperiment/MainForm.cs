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
                    foreach(TabPage tab in databaseTabs.TabPages)
                    {
                        if((tab.Controls[0] as InnerForm).Controller.Changed)
                        {
                            if (MessageBox.Show("Save database before closing?", tab.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                (tab.Controls[0] as InnerForm).Controller.Save();
                            }
                        }
                    }
                };
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
                Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom
            };
            Form form = new InnerForm(filename, title);
            page.Controls.Add(form);
            databaseTabs.TabPages.Add(page);
            filterButton.Enabled = true;
            addNoteButton.Enabled = true;
            saveButton.Enabled = true;
            databaseTabs.SelectTab(page);
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

                        if ((tab.Controls[0] as InnerForm).Controller.Changed)
                        {
                            if (MessageBox.Show("Save database before closing?", tab.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                (tab.Controls[0] as InnerForm).Controller.Save();
                            }
                        }
                        (tab.Controls[0] as InnerForm).CloseNotes();
                        databaseTabs.TabPages.Remove(tab);
                        tab.Dispose();
                        if (databaseTabs.TabPages.Count == 0)
                        {
                            filterButton.Enabled = false;
                            addNoteButton.Enabled = false;
                            saveButton.Enabled = false;
                        }
                        return;
                    }
                }
            }
        }

        private void hasTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PromptBox dlg = new PromptBox("Tag:", "Add tag filter", "default"))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    (databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).AddFilter("tag-" + dlg.Data);
                    (databaseTabs.SelectedTab.Controls[0] as InnerForm).Controller.AddFilter(Compendium.Model.Filtering.NoteFilterFactory.FilterType.TAG, dlg.Data);
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    load_file(dialog.FileName, dialog.SafeFileName);
                }
            }
        }

        private void addNoteButton_Click(object sender, EventArgs e)
        {
            InnerForm page = databaseTabs.SelectedTab.Controls[0] as InnerForm;
            page.NewNote();
        }

        private void beforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DatePromptBox dlg = new DatePromptBox("Date Picker"))
            {
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    (databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).AddFilter("before-" + dlg.Data.ToShortDateString());
                    InnerForm page = databaseTabs.SelectedTab.Controls[0] as InnerForm;
                    page.Controller.AddFilter(Model.Filtering.NoteFilterFactory.FilterType.DATE_BEFORE, dlg.Data);
                }
            }
        }

        private void doesntHaveTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PromptBox dlg = new PromptBox("Tag:", "Add tag missing filter", "default"))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    (databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).AddFilter("notag-" + dlg.Data);
                    (databaseTabs.SelectedTab.Controls[0] as InnerForm).Controller.AddFilter(Compendium.Model.Filtering.NoteFilterFactory.FilterType.TAG_INVERTED, dlg.Data);
                }
            }
        }

        private void afterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DatePromptBox dlg = new DatePromptBox("Date Picker"))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    (databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).AddFilter("after-" + dlg.Data.ToShortDateString());
                    (databaseTabs.SelectedTab.Controls[0] as InnerForm).Controller.AddFilter(Model.Filtering.NoteFilterFactory.FilterType.DATE_AFTER, dlg.Data);
                }
            }
        }

        private void keywordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PromptBox dlg = new PromptBox("Keyword:", "Add keyword filter", "default"))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    (databaseTabs.TabPages[databaseTabs.SelectedIndex].Controls[0] as InnerForm).AddFilter("keyword-" + dlg.Data);
                    (databaseTabs.SelectedTab.Controls[0] as InnerForm).Controller.AddFilter(Compendium.Model.Filtering.NoteFilterFactory.FilterType.KEYWORD, dlg.Data);
                }
            }
        }
        
        private void saveCurrent_Click(object sender, EventArgs e) => (databaseTabs.SelectedTab.Controls[0] as InnerForm).Controller.Save();

        private void saveButton_ButtonClick(object sender, EventArgs e)
        {
            saveCurrent_Click(sender, e);
        }

        private void saveAll_Click(object sender, EventArgs e)
        {
            foreach(TabPage tab in databaseTabs.TabPages)
            {
                (tab.Controls[0] as InnerForm).Controller.Save();
            }
        }
    }
}