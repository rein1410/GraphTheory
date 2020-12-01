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

        string str; //biến chuỗi kí tự đọc từ hàm readline
        string[] S; //biến mảng chuỗi mà mỗi phần tử cách nhau bởi ' '

        //hàm nhập ma trận từ tệp
        public void inputMatrixFromFile(string path)
        {
            FileStream f = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(f);
            _iNMatrix = Convert.ToInt32(sr.ReadLine());
            _iMatrix = new int[_iNMatrix, _iNMatrix];
            for (int i = 0; i < _iNMatrix; i++)
            {
                str = sr.ReadLine();
                S = str.Split(' ');
                for (int j = 0; j < _iNMatrix; j++)
                {
                    _iMatrix[i, j] = Convert.ToInt32(S[j]);
                }
            }
            sr.Dispose();
            f.Dispose();
        }
    }
}
