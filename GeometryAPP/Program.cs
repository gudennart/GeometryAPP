using GeometryAPP.Context;
using GeometryAPP.Model;
using System;

namespace GeometryAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new GeoContext())
            {
                var lteste = new Square();
                lteste.Size = 1;
                lteste.StartX = 1;
                lteste.StartY = 1;
                db.Square.Add(lteste);

                db.SaveChanges();

                foreach (var lSquare in db.Square)
                {
                    Console.WriteLine(lSquare.SquareId);
                }

                var lLine = new Line();
                lLine.StartX = 1;
                lLine.StartY = 1;
                db.Line.Add(lLine);

                db.SaveChanges();

                foreach (var lLines in db.Line)
                {
                    Console.WriteLine(lLine.LineId);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
