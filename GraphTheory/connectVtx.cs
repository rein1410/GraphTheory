using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTheory
{
    public partial class connectVtx : Form
    {
        Form1 frm;
        public connectVtx(Form1 frm)
        {
            InitializeComponent();
            this.frm = frm;
            for (int k = 0; k < Graph.vertexNumber; k++)
            {
                cbDHeadVertex.Items.Add(k); //thêm số vô đỉnh xuất phát
                cbDTailVertex.Items.Add(k); //thêm số vô đỉnh kết thúc
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Hãy nhập trọng số !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int i = Convert.ToInt32(cbDHeadVertex.SelectedItem);
            int j = Convert.ToInt32(cbDTailVertex.SelectedItem);
            if (i == j)
            {
                MessageBox.Show("Không thể nối với bản thân !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Graph.matrix[i, j] = Convert.ToInt32(textBox1.Text);
            Graph.matrix[j, i] = Convert.ToInt32(textBox1.Text);
            frm.generateGraph();
            this.Close();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) //EVENT XỬ LÝ SỐ
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
