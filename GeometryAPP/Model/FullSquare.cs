using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryAPP.Model
{
    public class FullSquare : Square
    {
        public Point PSD { get; set; } // Ponto Superior Direito
        public Point PID { get; set; } // Ponto Inferior Direito
        public Point PIE { get; set; } // Ponto Inferior Esquerdo
        public Point PC { get; set; } // Ponto Central
    }
}
