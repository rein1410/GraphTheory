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
            bm = new Bitmap(this.printPicture.Width, this.printPicture.Height); //tạo 1 bm hiển thị ảnh theo kích thước của khung picturebox
            graph = Graphics.FromImage(bm); //tạo 1 graphics trên ảnh được chọn
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
        public void enableControls()
        {
            /********************************************************************************************
            * 
            *       MỞ ĐIỀU KHIỂN DUYỆT MA TRẬN
            * 
            ********************************************************************************************/
            cbDHeadVertex.Enabled = cbDTailVertex.Enabled = start.Enabled = addVtx.Enabled = deleteVtx.Enabled = addEdge.Enabled = true; //Mở điều khiển duyệt ma trận
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
            matrix.inputMatrixFromGRAPHClass();
            graph.Clear(Color.Black);
            draw = new Draw(matrix);
            draw.drawGraph(matrix._iMatrix, matrix._iNMatrix, graph);
            printPicture.Image = bm;
        }
        private void writeGr_Click(object sender, EventArgs e) //event click lưu đồ thị
        {
            if (Graph.matrix == null)
            {
                MessageBox.Show("Không có gì để lưu! Bạn đã load đồ thị chưa?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog()) //mở savefiledialog
                {
                    sfd.InitialDirectory = Application.StartupPath + "\\Graphs\\";
                    sfd.Filter = "Text Document|*.txt";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        Stream fs = sfd.OpenFile();
                        StreamWriter sw = new StreamWriter(fs);
                        sw.Write(matrix.exportGraph(Graph.matrix)); //lệnh viết ra đồ thị từ mảng
                        sw.Close();
                        fs.Close();
                    }    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readGr_Click(object sender, EventArgs e) //HÀM MỞ ĐỒ THỊ TỪ FILE
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    string input;
                    int vertexNumber;
                    string Mat;
                    ofd.InitialDirectory = Application.StartupPath + "\\Graphs\\";
                    ofd.Filter = "Text Files (*.txt)|*.txt";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        StreamReader sr = new StreamReader(ofd.FileName);
                        input = File.ReadAllText(ofd.FileName); //đọc input
                        StringReader str = new StringReader(input); //khai biến stringreader
                        vertexNumber = Convert.ToInt32(sr.ReadLine()); //đọc số đỉnh
                        Mat = sr.ReadToEnd().Trim('\r', '\n'); //đọc ma trận
                    }
                    else return;
                    matrix.readGraph(Mat.Replace(",",""), vertexNumber, this);
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
            rtbLog.Text = string.Empty; //Xoá log cũ
            check = new Check(matrix);
            check.checkingConnection(matrix, draw, graph, bm, this);
            //Thread.Sleep(200);
            BellmanFord FB = new BellmanFord(Graph.vertexNumber, Graph.matrix);
            int head = Convert.ToInt32(cbDHeadVertex.Text); //tạo biến nhận điểm đầu từ combobox
            int tail = Convert.ToInt32(cbDTailVertex.Text); //tạo biến nhận điểm cuối từ combobox
            FB.FordBellman(matrix, rtbLog, head, tail, graph, draw, bm, vertex, this); //thuật toán fb
            MessageBox.Show("Đã duyệt xong!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void NewGraph(object sender, EventArgs e)
        {
            using (AddMat am = new AddMat(this))
                am.ShowDialog();
        }

        private void Form1_Resize(object sender, EventArgs e) //sự kiện resize kích cỡ màn hình
        {
            if (WindowState == FormWindowState.Maximized)
            {
                bm = new Bitmap(this.printPicture.Width, this.printPicture.Height); //tạo bitmap với size mới
                graph = Graphics.FromImage(bm); //load graphics từ bitmap
            }
            this.Resize -= Form1_Resize; //loại event này khỏi Form 1
        }

        private void addVtx_Click(object sender, EventArgs e) //tạo ma trận mới N+1xN+1
        {
            if (Graph.vertexNumber == 100) //thoát nếu đã đạt 100 đỉnh
            {
                MessageBox.Show("Ma trận tối đa 100 dỉnh !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int[,] temp = new int[Graph.vertexNumber+1,Graph.vertexNumber+1];
            for (int i = 0; i < Graph.vertexNumber; ++i)
            {
                for (int j = 0; j < Graph.vertexNumber; ++j)
                {
                    temp[i, j] = Graph.matrix[i, j];
                }
            }
            for (int i = 0; i < Graph.vertexNumber+1; i++)
            {
                temp[i, Graph.vertexNumber] = 0;
            }
            for (int i = 0; i < Graph.vertexNumber + 1; i++)
            {
                temp[Graph.vertexNumber, i] = 0;
            }
            Graph.vertexNumber++;
            Graph.matrix = temp;
            enableControls();
            generateGraph();
            dinh.Text = "Số Đỉnh: " + Graph.vertexNumber.ToString();
        }

        private void deleteVtx_Click(object sender, EventArgs e) //tạo ma trận mới N-1xN-1
        {
            if (Graph.vertexNumber < 2)
            {
                MessageBox.Show("Không thể xoá thêm nữa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int[,] temp = new int[Graph.vertexNumber - 1, Graph.vertexNumber - 1];
            for (int i = 0; i < Graph.vertexNumber - 1; ++i)
            {
                for (int j = 0; j < Graph.vertexNumber - 1; ++j)
                {
                    temp[i, j] = Graph.matrix[i, j];
                }
            }
            Graph.vertexNumber--;
            Graph.matrix = temp;
            enableControls();
            generateGraph();
            dinh.Text = "Số Đỉnh: " + Graph.vertexNumber.ToString();
        }

        private void addEdge_Click(object sender, EventArgs e) //mở form thêm cạnh
        {
            using (connectVtx frm = new connectVtx(this))
                frm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(About frm = new About())
                frm.ShowDialog();
        }
    }
}
