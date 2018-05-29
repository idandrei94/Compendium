using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compendium
{
    public partial class DatePromptBox : Form
    {
        public DateTime Data { get => dateTimePicker1.Value; }

        public DatePromptBox(String caption)
        {
            InitializeComponent();

            confirmation.DialogResult = DialogResult.OK;
            AcceptButton = confirmation;
            Text = caption;
        }

        private void DatePromptBox_Load(object sender, EventArgs e)
        {

        }
    }
}
