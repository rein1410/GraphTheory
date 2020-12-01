using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphTheory
{
    class Edge
    {
        public Vertex _vHead, _vTail; //khai báo đỉnh đầu và đỉnh cuối
        public float _fWeight; //trọng số
        public Color _cColor = Color.YellowGreen; //tạo màu vàng xanh

        //Constructor
        public Edge()
        {
            _cColor = Color.YellowGreen;
            _fWeight = 0;
        }

        public Edge(Vertex head, Vertex tail, float weight) //cạnh là đường nối giữa đỉnh đầu và cuối với trọng số kèm theo
        {
            this._vHead = head;
            this._vTail = tail;
            this._fWeight = weight;
        }

        public bool isMouseOnEdge(int X, int Y) //hàm kiểm tra chuột có nằm trên cạnh không
        {

            double range = Math.Sqrt((double)(Math.Pow(_vTail._pVertex.X - _vHead._pVertex.X, 2) + Math.Pow(_vTail._pVertex.Y - _vHead._pVertex.Y, 2)));
            double range1 = Math.Sqrt((double)(Math.Pow(_vHead._pVertex.X - X, 2) + Math.Pow(_vHead._pVertex.Y - Y, 2)));
            double range2 = Math.Sqrt((double)(Math.Pow(_vTail._pVertex.X - X, 2) + Math.Pow(_vTail._pVertex.Y - Y, 2)));
            return (range + 0.1f >= range1 + range2);

        }




    }
}
