using System;
using System.Windows.Forms;

namespace Compendium
{
    public partial class NoteWindow : Form
    {
        private String data;
        private Controller controller;

        public String Data { get => data; }

        private readonly char DELIMITATOR = (char)31;

        public NoteWindow(bool editable, String data, Controller controller)
        {
            InitializeComponent();
            TopLevel = true;
            Visible = true;

            this.data = data;
            this.controller = controller;
            ParseData();

            if (editable)
                EnableEditing();
        }

        private void NoteWindow_Load(object sender, EventArgs e)
        {

        }

        public void LockWindow()
        {
            Console.WriteLine("Locking note window");
            // disable the edit button and prevent saving/deleting
            saveButton.Enabled = false;
            editButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        public void UnlockWindow()
        {
            Console.WriteLine("Unlocking note window");
            if (!bodyBox.ReadOnly) // means edit mode 
            {
                saveButton.Enabled = true;
            }
            else
            {
                editButton.Enabled = true;
            }
            deleteButton.Enabled = true;
        }

        private void ParseData()
        {
            String[] elements = data.Split(DELIMITATOR);
            String ID = elements[0];
            String title = elements[1];
            String tags = elements[2];
            String added = elements[3];
            String body = elements[4];
            String updated = elements[5];

            this.Text = title + " {" + ID + "}";
            titleBox.Text = title;
            titleEditableBox.Text = title;
            bodyBox.Text = body;
            dateAddedLabel.Text = added;
            dateUpdatedLabel.Text = updated;
            String[] tagList = tags.Split(';');
            tagsEditable.Text = tags;
            tagsUneditable.TabPages.Clear();
            foreach(String tag in tagList)
            {
                tagsUneditable.TabPages.Add(new TabPage(tag));
                tagsUneditable.SelectedIndex = -1;
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        private void tagsUneditable_SelectedIndexChanged(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            tagsUneditable.SelectedIndex = -1;
        }

#pragma warning disable IDE1006 // Naming Styles
        private void editButton_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            EnableEditing();
        }

#pragma warning disable IDE1006 // Naming Styles
        private void saveButton_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            Console.WriteLine(bodyBox.Text);
            DisableEditing();
            data = controller.AlterNote(data);
        }

        private void EnableEditing()
        {
            saveButton.Enabled = true;
            saveButton.Visible = true;
            editButton.Enabled = false;
            editButton.Visible = false;
            sendToButton.Enabled = false;

            tagsUneditable.Visible = false;
            tagsEditable.Visible = true;
            bodyBox.ReadOnly = false;
            titleBox.Visible = false;
            titleEditableBox.Visible = true;
        }

        private void DisableEditing()
        {
            dateUpdatedLabel.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

            data = data.Split(DELIMITATOR)[0] + DELIMITATOR + titleEditableBox.Text + DELIMITATOR + tagsEditable.Text.Trim(';') + DELIMITATOR + dateAddedLabel.Text + DELIMITATOR + bodyBox.Text + DELIMITATOR + dateUpdatedLabel.Text;
            ParseData();
            
            saveButton.Enabled = false;
            saveButton.Visible = false;
            editButton.Enabled = true;
            editButton.Visible = true;
            sendToButton.Enabled = true;

            tagsUneditable.Visible = true;
            tagsEditable.Visible = false;
            bodyBox.ReadOnly = true;
            titleBox.Visible = true;
            titleEditableBox.Visible = false;
        }

#pragma warning disable IDE1006 // Naming Styles
        private void deleteButton_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            if (MessageBox.Show("Are you sure you want to delete this note? (This cannot be undone)", "Confirm delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                controller.RemoveNote(long.Parse(data.Split(DELIMITATOR)[0]));
                Console.WriteLine("Deleting this note");
                Close();
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        private void sendToButton_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            MessageBox.Show("Sorry, ain't implemented yet :)", "Not Implemented");
        }
    }
}
