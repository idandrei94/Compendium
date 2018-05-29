using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Compendium
{
    public partial class InnerForm : Form
    {

        private Controller controller;
        public Controller Controller { get => controller; }

        private List<NoteWindow> openNotes = new List<NoteWindow>();

        public InnerForm(String filepath, String title)
        {
            InitializeComponent();
            TopLevel = false;
            Visible = true;
            FormBorderStyle = FormBorderStyle.None;
            Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            filterList.SelectedIndex = -1;
            filterList.Visible = false;
            Console.WriteLine("opening database from {0} named {1}", filepath, title);
            controller = new Controller(filepath, title);
            DisplayItems(controller.Results.Select(note => note.Split((char)31)[1]).ToArray());
            currentNoteTags.SelectedIndex = -1;

            controller.PropertyChanged += (object sender, PropertyChangedEventArgs args) =>
            {
                Console.WriteLine("updating data");
                if (args.PropertyName == "Results")
                {
                    resultList.Invoke((MethodInvoker)delegate
                    {
                        var titles = controller.Results.Select(note => note.Split((char)31)[1]).ToArray();
                        foreach (string q in titles)
                        {
                            Console.WriteLine(q);
                        }
                        resultList.Items.Clear();
                        resultList.Items.AddRange((from item in titles select new ListViewItem(item)).ToArray());
                        resultList.SelectedIndices.Clear();
                        currentNoteTags.TabPages.Clear();
                    });
                }
            };
        }

        public void CloseNotes()
        {
            foreach(var note in openNotes)
            {
                note.Dispose();
            }
        }

        private void DisplayItems(String[] items)
        {
            resultList.Items.Clear();
            resultList.Items.AddRange((from item in items select new ListViewItem(item)).ToArray());
            resultList.SelectedIndices.Clear();
            currentNoteTags.TabPages.Clear();
        }

        private void InnerForm_Load(object sender, EventArgs e)
        {

        }

        public void AddFilter(String str)
        {
            filterList.TabPages.Add(new TabPage(str));
            filterList.SelectedIndex = -1;
            filterList.Visible = true;
        }

        #pragma warning disable IDE1006 // Naming Styles
        private void filterList_Click(object sender, EventArgs e)
        #pragma warning restore IDE1006 // Naming Styles
        {
            if((e as MouseEventArgs).Button == MouseButtons.Left)
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
            String[] tags = { };
            NoteWindow note = new NoteWindow(true, Controller.AddNote("Default title", "Default note body.", tags), controller);
            note.FormClosed += note_NoteClosed;
            openNotes.Add(note);
            note.Show();
        }

#pragma warning disable IDE1006 // Naming Styles
        private void resultList_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
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
