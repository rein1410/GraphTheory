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
    class Matrix
    {
        public int[,] _iMatrix;//ma trận trọng số
        public int _iNMatrix = 0; //số phần tử của ma trận

        //hàm nhập ma trận từ lớp tạm (graph)
        public void inputMatrixFromGRAPHClass()
        {
            _iNMatrix = Graph.vertexNumber;
            _iMatrix = new int[Graph.vertexNumber, Graph.vertexNumber];
            for (int i = 0; i < _iNMatrix; i++)
            {
                for (int j = 0; j < _iNMatrix; j++)
                {
                    _iMatrix[i, j] = Graph.matrix[i,j];
                }
            }
        }
        //hàm nhập ma trận từ string
        public void readGraph(string rtb, int vertexNumber, Form1 frm)
        {
            if (rtb.Replace(" ", "") == string.Empty) //Thoát nếu rỗng
            {
                MessageBox.Show("Ma trận trống !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                //Đọc đồ thị và dán dữ liệu vào richTextBox.
                using (StringReader sr = new StringReader(rtb))
                {
                    if (vertexNumber < 2)
                    {
                        MessageBox.Show("Ma trận phải có ít nhất 2 dỉnh !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (vertexNumber > 100)
                    {
                        MessageBox.Show("Ma trận tối đa 100 dỉnh !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
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
                    frm.enableControls();
                    frm.generateGraph();
                    frm.dinh.Text = "Số Đỉnh: " + Graph.vertexNumber.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string exportGraph(int[,] array2D) //HÀM DÙNG ĐỂ XUẤT GRAPH TỪ HÌNH VẼ
        {
            string result = "";
            result += Graph.vertexNumber + "\n";
            int i = 0;
            foreach (int n in array2D)
            {
                i++;
                result += n + " ";
                if (i == Graph.vertexNumber)
                {
                    result += "\n";
                    i = 0;
                }
            }
            return result;
        }
    }
}
