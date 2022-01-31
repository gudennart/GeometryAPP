using GeometryAPP.Context;
using GeometryAPP.Model;
using GeometryAPP.Service;
using System;

namespace GeometryAPP
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("########################################################################");
            Console.WriteLine("###                    Ultimate Master Calculator                    ###");
            Console.WriteLine("###                                                                  ###");
            Console.WriteLine("###                                                                  ###");
            Console.WriteLine("###  A execução dessa aplicação irá ler dois quadrados a partir de   ###");
            Console.WriteLine("###    Seu ponto superior esquerdo e do tamanho de suas laterais     ###");
            Console.WriteLine("###                                                                  ###");
            Console.WriteLine("###                                                                  ###");
            Console.WriteLine("###             Para Prosseguir aperte qualquer tecla                ###");
            Console.WriteLine("###                                                                  ###");
            Console.WriteLine("########################################################################");

            Console.ReadKey();
            
            Line lLine = new();

            var lSquare1 = new FullSquare();
            var lSquare2 = new FullSquare();
            LineService _LineSerivce = new();
            try
            {
                Console.WriteLine("###                     Primeiro Quadrado                            ###");
                LerQuadrado(lSquare1);
                Console.WriteLine("###                      Segundo Quadrado                            ###");
                LerQuadrado(lSquare2);
                lSquare2.StartX = Convert.ToInt64(Console.ReadLine());

                using (var db = new GeoContext())
                {
                    db.Square.AddAsync(lSquare1);
                    db.Square.AddAsync(lSquare2);
                    db.SaveChangesAsync();
                }

                lSquare1.SetPoints();
                lSquare2.SetPoints();

                var lTan = _LineSerivce.CalcTang(lSquare1.PC, lSquare2.PC);
                

                Console.WriteLine("Parabéns, o processamento acabou, agora vá buscar outro café...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreram erros durante o processamento: \r\n" + e.Message);
            }
        }

        public static void LerQuadrado(Square pSquare)
        {
            Console.WriteLine("###         Insira a posição X do ponto superior esquerdo (Float)    ###");
            pSquare.StartX = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("###         Insira a posição Y do ponto superior esquerdo (Float)    ###");
            pSquare.StartY = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("###   Insira o comprimento total de uma lateral do quadrado(Int)     ###");
            pSquare.Size = Convert.ToInt32(Console.ReadLine());
        }
    }
}
