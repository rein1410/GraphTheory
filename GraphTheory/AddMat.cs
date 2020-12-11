using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GraphTheory
{
    public partial class AddMat : Form
    {
        Form1 frm;
        Matrix matrix = new Matrix();
        public AddMat(Form1 frm)
        {
            InitializeComponent();
            this.frm = frm;
            this.ActiveControl = textBox1;
        }
        private void loadGr_Click(object sender, EventArgs e)
        {
            try
            {
                if (matrix.readGraph(richTextBox1.Text.Replace(",", ""), Convert.ToInt32(textBox1.Text), frm))
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = richTextBox1;
                e.SuppressKeyPress = true;
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Enter)
            {
                loadGr_Click(sender, new EventArgs());
            }
        }
    }
}
