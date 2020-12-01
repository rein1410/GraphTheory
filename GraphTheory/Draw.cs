using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GraphTheory
{
    class Draw
    {
        const int infinity = 9999; //khai báo vô cùng

        public Vertex[] _vVertex; //Khai báo mảng đỉnh để vẽ trong chương trình
        public Vertex _vUsingPoint = null;//Khai báo điểm hoạt động
        public Edge[] _eEdge;//Khai báo mảng cạnh để vẽ cạnh

        //Constructor
        public Draw(Matrix matrix)
        {
            _vVertex = new Vertex[Graph.vertexNumber]; //gán vVertex là số đỉnh trong ma trận tạm
            _eEdge = new Edge[(Graph.vertexNumber * (Graph.vertexNumber + 1)) / 2]; //1+2+3..+n..có tối đa (n*(n+1))/2 cạnh    
        }

        public void drawVertex(Graphics graph, Vertex vertex) //hàm vẽ đỉnh
        {
            if (_vVertex[vertex._iVerNum]._isDel == 0) //nếu biến _vVertex[số trên đỉnh] mà chưa bị xóa thì
            {
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graph.DrawEllipse(new Pen(Brushes.White), vertex._pVertex.X, vertex._pVertex.Y, 0, 0); //kích thước đỉnh
                graph.FillEllipse(new SolidBrush(vertex._cColor2), vertex._pVertex.X - 15, vertex._pVertex.Y - 15, 30, 30); //lớp màu xám
                graph.FillEllipse(new SolidBrush(vertex._cColor3), vertex._pVertex.X - 12, vertex._pVertex.Y - 12, 24, 24); //lớp màu lá mạ
                graph.DrawString(vertex._iVerNum.ToString(), new Font(FontFamily.GenericSansSerif, 13, FontStyle.Bold, GraphicsUnit.Pixel, 8, false), Brushes.Blue, vertex._pVertex.X + 5f - 10, vertex._pVertex.Y + 3f - 10); //số bên trong vòng tròn
            }
        }

        public void drawEdge(Graphics graph, Color color, Edge edge) //hàm vẽ cạnh
        {
            Pen p = new Pen(color, 2f);
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graph.DrawLine(p, edge._vHead._pVertex.X, edge._vHead._pVertex.Y, edge._vTail._pVertex.X, edge._vTail._pVertex.Y);
            graph.DrawString(edge._fWeight.ToString(), new Font(FontFamily.GenericMonospace, 16, FontStyle.Bold, GraphicsUnit.Pixel, 8, true), Brushes.White, ((edge._vHead._pVertex.X + edge._vTail._pVertex.X) / 2 - 5f), ((edge._vHead._pVertex.Y + edge._vTail._pVertex.Y) / 2 - 5f)); //số bên trong cạnh
        }

        public void drawGraph(int[,] matrix, int nMatrix, Graphics graph) //hàm vẽ đồ thị
        {
            int c = 0; //biến này dùng để làm chỉ số lưu các biến cạnh vào mảng cạnh

            if (_vVertex[0] == null) //phân bố các đỉnh trên picture box
            {
                _vUsingPoint = new Vertex(); //UsingPoint là đỉnh đang được dùng
                _vUsingPoint.dropVertexOnPictureBox(out _vVertex, matrix, nMatrix); //dùng hàm phân bố đỉnh bên class Vertex
            }

            for (int j = 0; j < nMatrix; j++) //vẽ các cạnh của đồ thị trước khi vẽ đỉnh
            {
                for (int k = 0; k < nMatrix; k++)
                {
                    if (matrix[j, k] != matrix[0, 0] && j < k)
                    {
                        _eEdge[c] = new Edge(_vVertex[j], _vVertex[k], matrix[j, k]); //gán biến cạnh từ class
                        drawEdge(graph, Color.DarkOliveGreen, _eEdge[c]); //vẽ cạnh
                        c++; //tăng c
                    }
                }
            }

            for (int i = 0; i < nMatrix; i++) //vẽ các đỉnh của đồ thị sau khi vẽ cạnh
            {
                if (_vVertex[i]._isDel == 0) //nếu đỉnh chưa bị xóa
                    drawVertex(graph, _vVertex[i]); //vẽ đỉnh
            }
        }

        //hàm kiểm tra xem chuột có nằm trên đỉnh không
        public void checkMouse(Point p) //hàm kiểm tra xem chuột có nằm trên đỉnh không
        {
            foreach (Vertex i in _vVertex) //duyệt 1 tập hợp (i có kiểu là Edge trong đỉnh)
            {
                if (i == null)
                    return;
                if (i.isMouseOnVertex(p)) //kiểm tra nếu chuột trên đỉnh thì
                {
                    _vUsingPoint = i; //gán điểm hoạt động đó = i
                    return;
                }
            }
        }

        //hàm kéo thả
        public void Drag(Point p, MouseEventArgs mouse, Matrix matrix, Graphics graph)
        {
            checkMouse(p);//kiểm tra vị trí của chuột có nằm trên đỉnh hay không
            if ((mouse.Button == MouseButtons.Left) && _vUsingPoint != null) //nếu chuột trái và điểm hoạt động khác rỗng
            {
                _vUsingPoint._pVertex.X = mouse.Location.X;//gán điểm hoạt động là vị trí hiện tại của chuột
                _vUsingPoint._pVertex.Y = mouse.Location.Y;
                graph.Clear(Color.Black);//Xóa đồ thị cũ
                drawGraph(matrix._iMatrix, matrix._iNMatrix, graph);//vẽ lại đồ thị
            }

        }

        //hàm reset các điểm hoạt động về null
        public void resetUsingPoint()
        {
            _vUsingPoint = null; //reset điểm hoạt động về null
        }

        //hàm vẽ đỉnh lúc đỉnh đang được duyệt
        public void drawCheckingVertex(Graphics graph, int vertex)
        {
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graph.DrawEllipse(new Pen(Brushes.White), _vVertex[vertex]._pVertex.X - 25, _vVertex[vertex]._pVertex.Y - 25, 50, 50);
            graph.FillEllipse(new SolidBrush(Color.Red), _vVertex[vertex]._pVertex.X - 15, _vVertex[vertex]._pVertex.Y - 15, 30, 30);
            graph.DrawString(_vVertex[vertex]._iVerNum.ToString(), new Font(FontFamily.GenericSansSerif, 13, FontStyle.Bold, GraphicsUnit.Pixel, 9, false), Brushes.Yellow, _vVertex[vertex]._pVertex.X + 5f - 10, _vVertex[vertex]._pVertex.Y + 3f - 10);
        }

        //hàm vẽ đỉnh được chọn lúc click chuột vào 1 đỉnh trên đồ thị
        public void drawChoseVertex(Graphics graph, int vertex)
        {
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graph.DrawEllipse(new Pen(Brushes.White), _vVertex[vertex]._pVertex.X - 25, _vVertex[vertex]._pVertex.Y - 25, 50, 50);
            graph.FillEllipse(new SolidBrush(Color.Orange), _vVertex[vertex]._pVertex.X - 15, _vVertex[vertex]._pVertex.Y - 15, 30, 30);
            graph.DrawString(_vVertex[vertex]._iVerNum.ToString(), new Font(FontFamily.GenericSansSerif, 13, FontStyle.Bold, GraphicsUnit.Pixel, 9, false), Brushes.Blue, _vVertex[vertex]._pVertex.X + 5f - 10, _vVertex[vertex]._pVertex.Y + 3f - 10);
        }

        //hàm vẽ lại cạnh
        public void redrawEdge(Graphics graph, int head, int tail, Matrix matrix)
        {
            if (matrix._iMatrix[head, tail] != matrix._iMatrix[0, 0])
            {
                Pen p = new Pen(Color.Yellow, 2f);
                Edge edge = new Edge(_vVertex[head], _vVertex[tail], matrix._iMatrix[head, tail]);
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graph.DrawLine(p, edge._vHead._pVertex.X, edge._vHead._pVertex.Y, edge._vTail._pVertex.X, edge._vTail._pVertex.Y);
                graph.DrawString(edge._fWeight.ToString(), new Font(FontFamily.GenericMonospace, 16, FontStyle.Bold, GraphicsUnit.Pixel, 8, true), Brushes.White, ((edge._vHead._pVertex.X + edge._vTail._pVertex.X) / 2 - 5f), ((edge._vHead._pVertex.Y + edge._vTail._pVertex.Y) / 2 - 5f));
            }
        }

        //hàm vẽ cạnh được chọn
        public void drawChoseEdge(Graphics graph, int head, int tail, Matrix matrix)
        {
            if (matrix._iMatrix[head, tail] != matrix._iMatrix[0, 0])
            {
                Pen p = new Pen(Color.Aqua, 2f);
                Edge edge = new Edge(_vVertex[head], _vVertex[tail], matrix._iMatrix[head, tail]);
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graph.DrawLine(p, edge._vHead._pVertex.X, edge._vHead._pVertex.Y, edge._vTail._pVertex.X, edge._vTail._pVertex.Y);
                graph.DrawString(edge._fWeight.ToString(), new Font(FontFamily.GenericMonospace, 16, FontStyle.Bold, GraphicsUnit.Pixel, 8, true), Brushes.White, ((edge._vHead._pVertex.X + edge._vTail._pVertex.X) / 2 - 5f), ((edge._vHead._pVertex.Y + edge._vTail._pVertex.Y) / 2 - 5f));
            }
        }

    }
}
