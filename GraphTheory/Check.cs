using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GraphTheory
{
    class Check
    {
        int[] _index; //mảng lưu chỉ số các phần tử liên thông
        int[] _notChecking; //mảng chứa các phần tử chưa xét
        int _iConnect;//biến thể hiện số phần tử liên thông
        //constructor
        public Check(Matrix matrix)
        {
            _index = new int[matrix._iNMatrix]; //tạo biến index độ rộng là các đỉnh
            _notChecking = new int[matrix._iNMatrix]; //biến chưa kiểm tra cũng vậy
        }

        //hàm DFS để kiểm tra liên thông
        public void DFSCheckConnection(int[] _index, int[] _notChecking, int _iconnect, int vertex, Graphics graph, Matrix matrix, Draw draw, Bitmap bm, Form1 f)
        {
            draw.drawCheckingVertex(graph, vertex); //vẽ lại đỉnh
            Thread.Sleep(500);
            f.printPicture.Image = bm; //in hình ra
            Application.DoEvents();

            _index[vertex] = _iconnect; //gán mảng lưu chỉ số các phần tử liên thông là phần tử liên thông
            _notChecking[vertex] = 0; //mảng chưa kiểm tra đỉnh gán = 0
            for (int i = 0; i < matrix._iNMatrix; i++)
            {
                if (_notChecking[i] == 1 && matrix._iMatrix[vertex, i] != matrix._iMatrix[0, 0]) //nếu mảng chưa kiểm tra = 1 và ma trận [đỉnh tới i] khác ma trận [0, 0]
                    DFSCheckConnection(_index, _notChecking, _iconnect, i, graph, matrix, draw, bm, f); //thì lập lại việc kiểm tra liên thông (đệ quy)
            }

        }

        //hàm truyền DFS vô kiểm tra liên thông
        public void checkingConnection(Matrix matrix, Draw draw, Graphics graph, Bitmap bm, Form1 f)
        {
            for (int i = 0; i < matrix._iNMatrix; i++)
            {
                if (draw._vVertex[i]._isDel == 0) //nếu việc việc vẽ đỉnh chưa bị xóa
                    _notChecking[i] = 1; //thì gán chưa kiểm tra = 1
            }
            _iConnect = 0; //biến liên thông gán = 0
            for (int i = 0; i < matrix._iNMatrix; i++)
            {
                if (_notChecking[i] == 1) //nếu mảng chưa kiểm tra = 1
                {
                    _iConnect++; //tăng biến liên thông lên 1 đơn vị
                    DFSCheckConnection(_index, _notChecking, _iConnect, i, graph, matrix, draw, bm, f); //kiểm tra liên thông bằng DFS
                }
            }
        }
    }
}
