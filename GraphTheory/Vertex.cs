using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphTheory
{
    class Vertex
    {
        public PointF _pVertex;//đỉnh
        public Color _cColor1 = Color.GreenYellow; //tạo 1 lớp màu cho đỉnh đó
        public Color _cColor2 = Color.Gray; //tạo lớp màu thứ 2
        public Color _cColor3 = Color.LightSlateGray; //tạo lớp màu thứ 3
        public int _iVerNum; //số trên đỉnh
        public int _isDel = 0; //cho biết đã bị xóa chưa, 1 - đã bị xóa, 0 - chưa bị xóa

        //Constructor
        public Vertex() //đỉnh
        {
            _cColor1 = Color.Blue; //gán lớp màu 1
            _cColor2 = Color.Pink; //gán lớp màu 2
            _cColor3 = Color.LimeGreen; //gán lớp màu 3
            _iVerNum = 0; //gán số trên đỉnh = 0
        }

        public Vertex(float x, float y, int point1) //hàm đỉnh gồm (tọa độ x, y và số để truyền vào)
        {
            this._pVertex = new PointF(x, y); //gán tọa độ x y
            this._iVerNum = point1; //gán chỉ số trên đỉnh
            _isDel = 0; //gán là đỉnh này chưa bị xóa
        }

        public bool isMouseOnVertex(PointF p) //kiểm tra xem chuột có touch vào đỉnh hay không
        {
            if (Math.Abs(_pVertex.X - p.X) <= 20 && Math.Abs(_pVertex.Y - p.Y) <= 20) //20 là bán kính của hình vẽ đỉnh trên picture box
                return true; //trả về có nếu giá trị trung bình <= 20
            return false; //ngược lại là không
        }

        public void dropVertexOnPictureBox(out Vertex[] vertex, int[,] matrix, int nMatrix) //hàm phân bố đỉnh lên picture box
        {
            vertex = new Vertex[nMatrix]; //tạo biến vertex
            float x, y; //tạo biến nhận tọa độ
            int div = nMatrix / 4, mod = nMatrix % 4, flag = 0, vertexNumber = 0; //tạo biến để lấy các khoảng cách nhất định
            for (int i = 0; i < mod; i++)
            {
                float range = 310 / (div + 2); //tính khoảng cách theo độ rộng
                switch (flag) //dùng switch case để xét từng trường hợp
                {
                    case 0:
                        for (int j = 0; j < div + 1; j++)
                        {
                            x = 20 + range * (j + 1);
                            y = 20 + 20 * j;
                            vertex[vertexNumber] = new Vertex(x, y, vertexNumber++);
                            flag = 1;
                        }
                        break;
                    case 1:
                        for (int j = 0; j < div + 1; j++)
                        {
                            x = 310 - 20 * j;
                            y = 20 + range * (j + 1);
                            vertex[vertexNumber] = new Vertex(x, y, vertexNumber++);
                            flag = 2;
                        }
                        break;
                    case 2:
                        for (int j = 0; j < div + 1; j++)
                        {
                            x = 320 - range * (j + 1);
                            y = 310 - 20 * j;
                            vertex[vertexNumber] = new Vertex(x, y, vertexNumber++);
                            flag = 3;
                        }
                        break;
                    case 3:
                        for (int j = 0; j < div + 1; j++)
                        {
                            x = 20 + 20 * j;
                            y = 310 - range * (j + 1);
                            vertex[vertexNumber] = new Vertex(x, y, vertexNumber++);
                            flag = 0;
                        }
                        break;
                }
            }

            for (int i = 0; i < 4 - mod; i++)
            {
                float range = 310 / (div + 1);
                switch (flag)
                {
                    case 0:
                        for (int j = 0; j < div; j++)
                        {
                            x = 20 + range * (j + 1);
                            y = 20 + 20 * j;
                            vertex[vertexNumber] = new Vertex(x, y, vertexNumber++);
                            flag = 1;
                        }
                        break;
                    case 1:
                        for (int j = 0; j < div; j++)
                        {
                            x = 320 - 20 * j;
                            y = 20 + range * (j + 1);
                            vertex[vertexNumber] = new Vertex(x, y, vertexNumber++);
                            flag = 2;
                        }
                        break;
                    case 2:
                        for (int j = 0; j < div; j++)
                        {
                            x = 320 - range * (j + 1);
                            y = 310 - 20 * j;
                            vertex[vertexNumber] = new Vertex(x, y, vertexNumber++);
                            flag = 3;
                        }
                        break;
                    case 3:
                        for (int j = 0; j < div; j++)
                        {
                            x = 20 + 20 * j;
                            y = 310 - range * (j + 1);
                            vertex[vertexNumber] = new Vertex(x, y, vertexNumber++);
                            flag = 0;
                        }
                        break;
                }
            }
        }
    }
}
