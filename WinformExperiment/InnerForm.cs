using Compendium.Model.Filtering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Compendium
{
    public partial class InnerForm : Form
    {

        private Controller controller;
        private TabPage parent;
        public bool Locked { get => locked; }
        public bool Changed { get => controller.Changed; }

        private List<NoteWindow> openNotes = new List<NoteWindow>();

        private bool locked = true;

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
            controller.PropertyChanged += (object sender, PropertyChangedEventArgs args) =>
            {
                Console.WriteLine("Notified of change");
                if (args.PropertyName == "Results")
                {
                    Lock();
                    Task.Run(() =>
                    {
                        var items = controller.Results.Select(note => new ListViewItem( note.Split((char)31)[1])).ToArray();
                        Console.WriteLine("fetched titles");
                        while (resultList.Items.Count > 0)
                        {
                            resultList.Invoke((MethodInvoker)delegate
                            {
                                resultList.Items.RemoveAt(0);
                            });
                        }
                        Console.WriteLine("Cleared old results");
                        foreach (var item in items)
                        {
                            resultList.Invoke((MethodInvoker)delegate
                            {
                                resultList.Items.Add(item);
                                resultList.SelectedIndices.Clear();
                                currentNoteTags.TabPages.Clear();
                            });
                        }
                        Unlock();
                    });
                }
            };
            controller.Open();
        }

        private void Lock()
        {
            if (locked)
                return;
            Console.WriteLine("locking inner form");
            parent.Text = parent.Text.Split('*')[0] + "*busy";
            foreach(var note in openNotes)
            {
                note.LockWindow();
            }
            locked = true;
        }

        private void Unlock()
        {
            Console.WriteLine("unlocking inner form");
            parent.Invoke((MethodInvoker)delegate { parent.Text = controller.Title; });
            foreach (var note in openNotes)
            {
                note.Invoke((MethodInvoker)delegate { note.UnlockWindow(); });
            }
            locked = false;
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
            String dataString = controller.Results[resultList.SelectedIndices[0]];
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

        public void NewNote()
        {
            if (locked)
            {
                MessageBox.Show("Unable to add filter due to work in progress.", "Database busy");
                return;
            }
            String[] tags = { };
            NoteWindow note = new NoteWindow(true, controller.AddNote("Default title", "Default note body.", tags), controller);
            note.FormClosed += note_NoteClosed;
            openNotes.Add(note);
            note.Show();
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
                String item = controller.Results[resultList.SelectedIndices[0]];
                String[] tags = item.Split((char)31)[2].Split(';');
                foreach (String tag in tags)
                {
                    currentNoteTags.TabPages.Add(tag);
                }
                currentNoteTags.SelectedIndex = -1;
            }
            catch(Exception)
            {
                currentNoteTags.TabPages.Clear();
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
    }
}
