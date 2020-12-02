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
        Matrix matrix = new Matrix();
        Vertex vertex;
        Bitmap bm;
        Check check;
        public bool mouseLeft = true; //BIẾN KIỂM TRA XEM BẠN ĐÃ "THẢ" CHUỘT RA CHƯA HAY VẪN CÒN NHẤP GIỮ CHUỘT.
        string checkMatch;
        public void enableControls()
        {
            /********************************************************************************************
            * 
            *       MỞ ĐIỀU KHIỂN DUYỆT MA TRẬN
            * 
            ********************************************************************************************/
            cbDHeadVertex.Enabled = cbDTailVertex.Enabled = start.Enabled = true; //Mở điều khiển duyệt ma trận
            cbDHeadVertex.Items.Clear();
            cbDTailVertex.Items.Clear();
            for (int k = 0; k < Graph.vertexNumber; k++)
            {
                cbDHeadVertex.Items.Add(k); //thêm số vô đỉnh xuất phát
                cbDTailVertex.Items.Add(k); //thêm số vô đỉnh kết thúc
            }
            cbDHeadVertex.SelectedIndex = cbDTailVertex.SelectedIndex = 0;
        }
        public void generateGraph()
        {
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
                        richTextBox1.Text = File.ReadAllText(ofd.FileName);
                    }
                    matrix.readGraph(richTextBox1.Text.Replace(",",""), this); //Đọc ma trận từ richtextbox
                    checkMatch = richTextBox1.Text; //tránh reload lại đồ thị nếu trùng
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void printPicture_MouseMove(object sender, MouseEventArgs e) //tạo sự kiện di chuyển chuột
        {
            if (draw != null)
            {
                if (e.Button == MouseButtons.None)
                {
                    draw.resetUsingPoint(); //xóa toàn bộ các điểm hoạt động của chuột trên hình vẽ
                    mouseLeft = false; //tắt chuột trái
                }
                else if (e.Button == MouseButtons.Left && e.X >= 0 && e.Y >= 0 && (e.X <= printPicture.Width) && (e.Y <= printPicture.Height)) //event chuột trái chỉ được phép nằm trong khung printPicture
                {
                    draw.Drag(e.Location, e, matrix, graph); //dùng drag để vẽ lại các vị trí của event
                    mouseLeft = true;
                    printPicture.Image = bm;
                    printPicture.Show(); //gán ra màn hình
                }
                if (mouseLeft) //nếu mouseLeft = true
                {
                    printPicture.Image = bm;
                    printPicture.Show(); //hiển thị ra
                }
            }
        }
        private void start_Click(object sender, EventArgs e)
        {

            graph.Clear(Color.Black);
            draw.drawGraph(matrix._iMatrix, matrix._iNMatrix, graph);
            printPicture.Image = bm;
            check = new Check(matrix);
            check.checkingConnection(matrix, draw, graph, bm, this);
            Thread.Sleep(500);
            BellmanFord FB = new BellmanFord(Graph.vertexNumber, Graph.matrix);
            int head = Convert.ToInt32(cbDHeadVertex.Text); //tạo biến nhận điểm đầu từ combobox
            int tail = Convert.ToInt32(cbDTailVertex.Text); //tạo biến nhận điểm cuối từ combobox
            FB.FordBellman(matrix, rtbLog, head, tail, graph, draw, bm, vertex, this);
            MessageBox.Show("Đã duyệt xong!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void loadGr_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.Text != checkMatch)
                {
                    matrix.readGraph(richTextBox1.Text.Replace(",",""), this);
                    checkMatch = richTextBox1.Text; //tránh reload lại đồ thị nếu trùng
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
