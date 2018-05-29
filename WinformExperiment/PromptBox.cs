using System;
using System.Windows.Forms;

namespace Compendium
{
    class PromptBox : Form
    {
        public String Data;

        public PromptBox(string text, string caption, string defaultTitle)
        {
            InitializeComponent();
            Width = 400;
            Height = 200;
            Text = caption;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 300 };
            TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 300, Height = 200, Text = defaultTitle };
            Button confirmation = new Button() { Text = "Ok", Left = 150, Width = 100, Top = 100 };
            confirmation.DialogResult = DialogResult.OK;
            AcceptButton = confirmation;
            confirmation.Click += (sender, e) => { Data = inputBox.Text; };
            Controls.Add(textLabel);
            Controls.Add(inputBox);
            Controls.Add(confirmation);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromptBox));
            this.SuspendLayout();
            // 
            // PromptBox
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PromptBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.PromptBox_Load);
            this.ResumeLayout(false);

        }

        private void PromptBox_Load(object sender, EventArgs e)
        {

        }
    }
}
