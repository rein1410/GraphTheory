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
        public bool readGraph(string rtb, int vertexNumber, Form1 frm) //HÀM DÙNG ĐỀ ĐỌC ĐỒ THỊ
        {
            if (rtb.Replace(" ", "") == string.Empty) //Thoát nếu rỗng
            {
                MessageBox.Show("Ma trận trống !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                using (StringReader sr = new StringReader(rtb))
                {
                    if (vertexNumber < 2)
                    {
                        MessageBox.Show("Ma trận phải có ít nhất 2 dỉnh !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (vertexNumber > 100)
                    {
                        MessageBox.Show("Ma trận tối đa 100 dỉnh !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    Graph.vertexNumber = vertexNumber;
                    string input = sr.ReadToEnd().Trim('\r', '\n');
                    int i = 0; int j = 0;
                    Graph.matrix = new int[Graph.vertexNumber, Graph.vertexNumber]; 
                    foreach (var row in input.Split('\n')) //VÒNG LẶP GÁN DỮ LIỆU TỪNG CON SỐ TRONG MA TRẬN
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
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public string exportGraph(int[,] array2D) //HÀM DÙNG ĐỂ GHI MẢNG MA TRẬN RA DẠNG STRING
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
