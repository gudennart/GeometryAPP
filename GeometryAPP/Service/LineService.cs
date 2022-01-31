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

        public void SetLinePoint(FullSquare pSquare, float pTang, bool pDirection, Line pLine)
        {
            var Result = new Point();
            if (pDirection)
            {
                if (pTang > 1)
                {
                    Result.Y = pSquare.PID.Y;
                    Result.X = pSquare.PC.X - (pSquare.Size / (2 * pTang));
                }
                else if (pTang > 0)
                {
                    Result.X = pSquare.StartX;
                    Result.Y = pSquare.PC.Y + ((pSquare.Size / 2) * pTang);
                }
                else if (pTang > -1) 
                {
                    Result.X = pSquare.StartX;
                    Result.Y = pSquare.PC.Y - ((pSquare.Size / 2 )* pTang);
                }
                else
                {
                    Result.Y = pSquare.StartY;
                    Result.X = pSquare.PC.X - (pSquare.Size / (2 * pTang));
                }
                pLine.StartX = Result.X;
                pLine.StartY = Result.Y;

            }
            else
            {

                if (pTang > 1)
                {
                    Result.Y = pSquare.StartY;
                    Result.X = pSquare.PC.X + (pSquare.Size / (2 * pTang));
                }
                else if (pTang > 0)
                {
                    Result.X = pSquare.PSD.X;
                    Result.Y = pSquare.PC.Y + ((pSquare.Size / 2) * pTang);
                }
                else if (pTang > -1) 
                {
                    Result.X = pSquare.PSD.X;
                    Result.Y = pSquare.PC.Y - ((pSquare.Size / 2) * pTang);
                }
                else
                {
                    Result.Y = pSquare.PID.Y;
                    Result.X = pSquare.PC.X + (pSquare.Size / (2 * pTang));
                }

                pLine.EndX = Result.X;
                pLine.EndY = Result.Y;
            }

        }
    }
}
