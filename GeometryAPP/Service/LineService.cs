using GeometryAPP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryAPP.Service
{
    public class LineService
    {
        public float CalcTang(Point a, Point b)
        {
            var lX = a.X - b.X;
            var lY = a.Y - b.Y;

            return lY / lX;
        }

        public Point GetFinalPoint (Square pSquare, float pTang, bool pDirection)
        {
            var Result = new Point();

            return 
        }
    }
}
