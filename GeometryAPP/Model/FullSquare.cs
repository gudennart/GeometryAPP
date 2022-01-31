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

        public void SetPoints()
        {
            PSD = new();
            PSD.X = this.StartX + this.Size;
            PSD.Y = this.StartY;

            PID = new();
            PID.X = PSD.X;
            PID.Y = this.StartY + this.Size;
            
            PIE = new();
            PIE.X = this.StartX;
            PIE.Y = this.StartY + this.Size;
            
            PC = new();
            PC.X = this.StartX / 2;
            PC.Y = this.StartY + (this.Size / 2);

        }
    }
}
