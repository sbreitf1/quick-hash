using QuickHash.Properties;
using System;
using System.Windows.Forms;

namespace QuickHash
{
    public partial class EnterStringForm : Form
    {
        MainForm mainForm;


        public EnterStringForm(MainForm mainForm)
        {
            InitializeComponent();
            this.Icon = Resources.quickhash;

            this.mainForm = mainForm;
            this.tbxString.Text = Settings.Default.EnteredString;
            this.mainForm.SetHashesFromText(this.tbxString.Text);
        }

        private void tbxString_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.SetHashesFromText(this.tbxString.Text);
        }

        private void tbxString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                this.tbxString.SelectAll();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void EnterStringForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.EnteredString = this.tbxString.Text;
            Settings.Default.Save();
        }
    }
}
