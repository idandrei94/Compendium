﻿using Compendium.Model.Filtering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compendium
{
    public partial class InnerForm : Form
    {

        private Controller controller;
        private TabPage parent;

        private static readonly int RESULTS_PER_PAGE = 100;

        private int pageCount = 0;
        private int currentPage = 0;

        public bool Locked { get => locked; }
        public bool Changed { get => controller.Changed; }
        public String File { get => controller.Filepath; }
        public String[] SelectedItems { get => (from int item in resultList.SelectedIndices select resultStrings[item]).ToArray(); }

        private List<NoteWindow> openNotes = new List<NoteWindow>();

        private bool locked = true;

        private String[] resultStrings = new String[0];

        public InnerForm(String filepath, String title, TabPage parent)
        {
            this.parent = parent;

            InitializeComponent();
            TopLevel = false;
            Visible = true;
            FormBorderStyle = FormBorderStyle.None;
            Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            filterList.SelectedIndex = -1;
            filterList.Visible = false;
            currentNoteTags.SelectedIndex = -1;
            controller = new Controller(filepath, title);

            currentPageEditable.KeyDown += (object sender, KeyEventArgs args) =>
            {
                if (!Locked && args.KeyCode == Keys.Enter)
                {
                    if (Int32.TryParse(currentPageEditable.Text, out int number))
                    {
                        if (number >= 1 && number <= pageCount + 1)
                        {
                            currentPage = number - 1;
                            DisplayCurrentPage();
                        }
                        else
                            currentPageEditable.Text = (currentPage + 1).ToString();
                    }
                    else
                        currentPageEditable.Text = (currentPage + 1).ToString();
                }
            };

            controller.PropertyChanged += (object sender, PropertyChangedEventArgs args) =>
            {
                if (args.PropertyName == "Results")
                {
                    int resultCount = controller.ResultCount;
                    pageCount = (int)Math.Ceiling(resultCount / (double)RESULTS_PER_PAGE);
                    if (pageCount <= currentPage)
                        currentPage = 0;
                    DisplayCurrentPage();
                }
            };
            Lock();
            controller.Open( () =>
            {
                Invoke((MethodInvoker)delegate {
                    MessageBox.Show("Unable to load Compendium database from " + controller.Filepath, "Invalid file");
                    (parent.Parent as TabControl).TabPages.Remove(parent);
                });


            });
        }

        private void DisplayCurrentPage()
        {
            Lock();
            Console.WriteLine("Clearing current page");
            resultList.BeginInvoke((MethodInvoker)delegate
            {
                resultList.Items.Clear();
            });
            int resultCount = controller.ResultCount;
            int resultsToShow = Math.Min(RESULTS_PER_PAGE, resultCount - currentPage * RESULTS_PER_PAGE);
            Console.WriteLine("Page cleared, generating {0} items ({1} - {2})", resultsToShow, currentPage * RESULTS_PER_PAGE, currentPage * RESULTS_PER_PAGE+resultsToShow - 1);
            ListViewItem[] items = new ListViewItem[resultsToShow];
            resultStrings = controller.ResultRange(currentPage * RESULTS_PER_PAGE, currentPage * RESULTS_PER_PAGE+resultsToShow);
            for (int i = 0; i < resultsToShow; ++i)
            {
                items[i] = new ListViewItem(resultStrings[i].Split((char)31)[1]);
            }
            Console.WriteLine("Items generated, adding them to the view");
            resultList.BeginInvoke((MethodInvoker)delegate
            {
                resultList.Items.AddRange(items);
            });
            Console.WriteLine("ListView populated, updating labels and stuff");
            BeginInvoke((MethodInvoker)delegate 
            {
                currentPageEditable.Text = (currentPage + 1).ToString();
                currentNoteTags.TabPages.Clear();
                currentNoteTags.Visible = false;
            });
            resultCountLabel.BeginInvoke((MethodInvoker)delegate
            {
                resultCountLabel.Text = controller.ResultCount > 0 ?
                                            "Showing results " +
                                            (currentPage * RESULTS_PER_PAGE + 1) +
                                            "-" +
                                            (currentPage * RESULTS_PER_PAGE + resultsToShow) +
                                            "/" +
                                            controller.ResultCount +
                                            "(" + pageCount +
                                            " page" +
                                            (pageCount != 1 ? "s)" : ")")
                                        : "No results";
            });
            Console.WriteLine("Displaying complete, unlocking...");
            Unlock();
        }

        private void Lock()
        {
            Console.WriteLine("locking inner form");
            parent.BeginInvoke((MethodInvoker)delegate 
            {
                parent.Text = parent.Text.Split('*')[0] + "*busy";
                nextPage.Enabled = false;
                prevPage.Enabled = false;
                currentPageEditable.ReadOnly = true;
            });
            
            foreach(var note in openNotes)
            {
                note.LockWindow();
            }
            locked = true;
            Console.WriteLine("inner form locked");
        }

        private void Unlock()
        {
            Console.WriteLine("unlocking inner form");
            parent.BeginInvoke((MethodInvoker)delegate 
            {
                parent.Text = controller.Title;
                nextPage.Enabled = (currentPage+1) < pageCount;
                prevPage.Enabled = currentPage > 0;
                currentPageEditable.ReadOnly = false;
            });
            foreach (var note in openNotes)
            {
                if (!note.IsDisposed)
                    note.Invoke((MethodInvoker)delegate { note.UnlockWindow(); });
            }
            locked = false;
            Console.WriteLine("inner form unlocked");
        }

        public void CloseNotes()
        {
            foreach(var note in openNotes)
            {
                note.Dispose();
            }
        }

        private void InnerForm_Load(object sender, EventArgs e)
        {

        }

        public void AddDisplayFilter(String str)
        {
            filterList.TabPages.Add(new TabPage(str));
            filterList.SelectedIndex = -1;
            filterList.Visible = true;
        }

        public void AddFilter(NoteFilterFactory.FilterType type, String arg)
        {
            controller.AddFilter(type, arg);
        }

        public void AddFilter(NoteFilterFactory.FilterType type, DateTime arg)
        {
            controller.AddFilter(type, arg);
        }

        public void Save()
        {
            Lock();
            Task.Run(() =>
            {
                controller.Save();
                Unlock();
            });
        }

#pragma warning disable IDE1006 // Naming Styles
        private void filterList_Click(object sender, EventArgs e)
        #pragma warning restore IDE1006 // Naming Styles
        {
            if (locked)
            {
                return;
            }
            if ((e as MouseEventArgs).Button == MouseButtons.Left)
            {
                int index = filterList.SelectedIndex;
                filterList.TabPages.Remove(filterList.SelectedTab);
                filterList.SelectedIndex = -1;
                filterList.Visible = filterList.TabPages.Count > 0;
                controller.RemoveFilter(index);
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        private void resultList_DoubleClick(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            if (locked)
            {
                return;
            }
            String dataString = resultStrings[resultList.SelectedIndices[0]];
            foreach(NoteWindow noteW in openNotes)
            {
                if (noteW.Data.Equals(dataString))
                {
                    noteW.BringToFront();
                    return;
                }
            }
            NoteWindow note = new NoteWindow(false, dataString, controller);
            note.FormClosed += note_NoteClosed;
            openNotes.Add(note);
            note.Show();
        }

        public void NewNote(String noteString = null)
        {
            if (locked)
            {
                MessageBox.Show("Unable to add note due to work in progress.", "Database busy");
                return;
            }
            if(noteString == null)
            {
                String[] tags = { };
                NoteWindow note = new NoteWindow(true, controller.AddNote("Default title", "Default note body.", tags), controller);
                note.FormClosed += note_NoteClosed;
                openNotes.Add(note);
                note.Show();
            }
            else
            {
                String[] elements = noteString.Split((char)31);
                String ID = elements[0];
                String title = elements[1];
                String tags = elements[2];
                String added = elements[3];
                String body = elements[4];
                String updated = elements[5];
                controller.AddNote(title, body, tags.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        private void resultList_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            if (locked)
            {
                return;
            }
            try
            {
                List<string> allTags = new List<string>();

                foreach (int chosenIndex in resultList.SelectedIndices)
                {
                    (allTags as List<string>).AddRange(resultStrings[chosenIndex].Split((char)31)[2].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
                }

                List<string> commonTags = new List<string>(
                    allTags.Distinct().Where(
                        (tag) =>
                        {
                            foreach (int chosenIndex in resultList.SelectedIndices)
                            {
                                if (!resultStrings[chosenIndex].Split((char)31)[2].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Any(tag.Contains))
                                    return false;
                            }
                            return true;
                        }));
                currentNoteTags.TabPages.Clear();
                foreach (String tag in commonTags)
                {
                    currentNoteTags.TabPages.Add(tag);
                }
                currentNoteTags.SelectedIndex = -1;
                    currentNoteTags.Visible = currentNoteTags.TabPages.Count > 0;
            }
            catch(Exception)
            {
                currentNoteTags.TabPages.Clear();
                currentNoteTags.Visible = false;
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        private void currentNoteTags_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            currentNoteTags.SelectedIndex = -1;
        }

#pragma warning disable IDE1006 // Naming Styles
        private void note_NoteClosed(object sender, FormClosedEventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            var closingNote = sender as NoteWindow;
            openNotes.Remove(closingNote);
        }

#pragma warning disable IDE1006 // Naming Styles
        private void prevPage_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            --currentPage;
            DisplayCurrentPage();
        }

#pragma warning disable IDE1006 // Naming Styles
        private void nextPage_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            ++currentPage;
            DisplayCurrentPage();
        }

        private void filterList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
