using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
namespace GraphTheory
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Directory.CreateDirectory("Graphs");
            bm = new Bitmap(this.printPicture.Width, this.printPicture.Height); //tạo 1 cái bm để hiển thị ảnh theo kích thước của khung picturebox màu đen tên là "printPicture"
            graph = Graphics.FromImage(bm); //dùng graphics để chỉnh sửa rồi hiện thị lên picturebox
        }

        /********************************************************************************************
        * 
        *       TẠO CÁC BIẾN THEO CLASS
        * 
        ********************************************************************************************/

        Graphics graph;
        Draw draw;
        Matrix matrix;
        Vertex vertex;
        Bitmap bm;
        Check check;

        private void writeGr_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Replace(" ","") == string.Empty) //Thoát nếu rỗng
            {
                MessageBox.Show("Ma trận trống !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                StringReader sr = new StringReader(richTextBox1.Text);
                int vertexNumber = Convert.ToInt32(sr.ReadLine());
                if (vertexNumber < 2) //Thoát nếu < 2 dỉnh
                {
                    MessageBox.Show("Ma trận phải có ít nhất 2 dỉnh !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (vertexNumber > 100)
                {
                    MessageBox.Show("Ma trận tối đa 100 dỉnh !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Tạo đồ thị dựa trên richTextBox, tên đặt bằng thời gian tao.
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Graphs\\" + string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}.txt", DateTime.Now));
                sw.WriteLine(richTextBox1.Text.Trim('\r', '\n'));
                sw.Close();
                StatusLbl.Text = "Tạo Graph thành công !";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readGr_Click(object sender, EventArgs e)
        {
            try
            {
                //Đọc đồ thị và dán dữ liệu vào richTextBox.
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        StreamReader sr = new StreamReader(ofd.FileName);
                        int vertexNumber = Convert.ToInt32(sr.ReadLine());
                        if (vertexNumber <= 1)
                        {
                            MessageBox.Show("Ma trận phải có ít nhất 2 dỉnh !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (vertexNumber > 100)
                        {
                            MessageBox.Show("Ma trận tối đa 100 dỉnh !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        richTextBox1.Text = File.ReadAllText(ofd.FileName);
                        Graph.vertexNumber = vertexNumber;
                        string input = sr.ReadToEnd().Trim('\r', '\n');
                        int i = 0; int j = 0;
                        Graph.matrix = new int[Graph.vertexNumber, Graph.vertexNumber];
                        foreach (var row in input.Split('\n'))
                        {
                            j = 0;
                            foreach (var col in row.Trim().Split(' '))
                            {
                                Graph.matrix[i, j] = int.Parse(col.Trim());
                                j++;
                            }
                            i++;
                        }
                        dinh.Text = "Số Đỉnh: " + Graph.vertexNumber.ToString();
                        mat.Text = "Ma Trận: " + "\n" + input;
                        /********************************************************************************************
                        * 
                        *       HIỂN THỊ ĐỒ THỊ LÊN KHUNG PICTUREBOX
                        * 
                        ********************************************************************************************/
                        matrix = new Matrix();
                        matrix.inputMatrixFromGRAPHClass();
                        graph.Clear(Color.Black);
                        draw = new Draw(matrix);
                        draw.drawGraph(matrix._iMatrix, matrix._iNMatrix, graph);
                        printPicture.Image = bm;
                        printPicture.Show();
                        printPicture.Enabled = true;
                    }
                }
                StatusLbl.Text = "Đọc file thành công. ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
