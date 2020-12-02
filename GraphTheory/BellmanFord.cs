using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace GraphTheory
{
    class BellmanFord
    {
        const int MAX = 3200; //gán MAX là vô cùng
        private int[] before; //mảng chứa biến trước
        private int[] D; //mảng chứa khoảng cách
        private int[,] matrixN; //ma trận trọng số
        private int _vertexNumber; //tạo biến thay cho số đỉnh

        //tạo tham số cho class BellmanFord
        public BellmanFord(int vertexNum, int[,] matrix)
        {
            this._vertexNumber = vertexNum; //gán số đỉnh
            this.matrixN = matrix; //gán ma trận

            before = new int[vertexNum]; //khởi tạo cho mảng before chứa số lượng đỉnh
            D = new int[vertexNum]; //khởi tạo khoảng cách
            for (int i = 0; i < vertexNum; i++)
            {
                for (int j = 0; j < vertexNum; j++)
                {
                    if (matrixN[i, j] == 0) //kiểm tra nếu ma trận = 0 
                    {
                        matrixN[i, j] = MAX; //thì gán bằng vô cùng
                    }
                }
            }
        }
        //hàm fordbellman
        public void FordBellman(Matrix matrix, RichTextBox rtb, int x, int y, Graphics graph, Draw draw, Bitmap bm, Vertex vertex, Form1 f)
        {
            for (int i = 0; i < matrix._iNMatrix; i++)
            {
                D[i] = matrixN[x, i]; //khoảng cách từ điểm đầu đến i.
                before[i] = x; //trước đỉnh i là đỉnh đầu.
            }
            D[x] = 0;
            for (int k = 0; k < matrix._iNMatrix - 2; k++) //chạy k từ 0 đến khi k < đỉnh - 2
            {
                for (int i = 0; i < matrix._iNMatrix; i++) //tiếp tục chạy i
                {
                    for (int j = 0; j < matrix._iNMatrix; j++) //chạy j
                    {
                        int temp = D[i] + matrixN[i, j]; //gán tổng khoảng cách của i với ma trận i j = temp
                        if (D[j] > temp) //nếu khoảng cách từ j > temp
                        {
                            D[j] = temp; //thì gán lại
                            before[j] = i; //gán biến trước j = i
                        }
                    }
                }
            }
            rtb.Text = "";
            move(D, before, x, y, rtb, matrix, graph, draw, bm, vertex, f); //thực hiện vẽ đường đi
        }

        //hàm vẽ đường đi
        private void move(int[] d, int[] before, int m, int n, RichTextBox rtb, Matrix matrix, Graphics graph, Draw draw, Bitmap bm, Vertex vertex, Form1 f)
        {
            int[] A = new int[matrix._iNMatrix]; //tạo 1 mảng A độ rộng là số đỉnh
            int k = n, i = 0; //tạo 2 biên k và i với k là đỉnh cuối và i = 0
            A[i++] = n; //gán mảng A[i tăng 1] = n

            if (d[m] == MAX) //nếu không có đường đi thì kết thúc
            {
                rtb.Text += "Không có đường đi từ " + m.ToString() + " đến " + n.ToString() + " .\n";
                return;
            }
            while (m != k) //trong khi đỉnh đầu khác đỉnh cuối
            {
                if (d[k] == MAX) //nếu không có đường đi thì kết thúc
                {
                    rtb.Text += "Không có đường đi từ " + m.ToString() + " đến " + n.ToString() + " .\n";
                    return;
                }
                A[i++] = before[k]; //tăng i lên 1 thì sẽ gán đỉnh trước của đỉnh cuối mà nó duyệt
                k = before[k]; //rồi gán k sẽ là đỉnh trước đó, cứ như thế đến khi m == k thì ngưng
            }
            rtb.Text += "Đường đi ngắn nhất từ " + m.ToString() + " đến " + n.ToString() + " với các đỉnh " + "là:";

            draw.drawGraph(matrix._iMatrix, matrix._iNMatrix, graph); //vẽ đồ thị ra
            Thread.Sleep(500); //điều chỉnh tốc độ xuất hiện

            for (int j = i - 1; j >= 0; j--)
            {
                rtb.Text += " " + A[j].ToString();
                Thread.Sleep(500); //điều chỉnh tốc độ xuất hiện
                if (j != i - 1)
                {
                    draw.drawChoseEdge(graph, A[j + 1], A[j], matrix); //vẽ cạnh được chọn
                    draw.drawCheckingVertex(graph, A[j + 1]); //vẽ đỉnh được duyệt
                }

                draw.drawCheckingVertex(graph, A[j]); //vẽ đỉnh đang được chuyệt
                Thread.Sleep(500); //điều chỉnh tốc độ xuất hiện
                f.printPicture.Image = bm; //vẽ lại trên màn hình
                Application.DoEvents(); //bỏ qua cái việc vẽ ban đầu để xử lý việc vẽ lại đỉnh và cạnh
            }
            rtb.Text += "\n";
            Thread.Sleep(500);
        }
    }
}
