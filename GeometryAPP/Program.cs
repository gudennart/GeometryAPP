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
            Console.WriteLine();
            var lSquare1 = new FullSquare();
            var lSquare2 = new FullSquare();
            LineService _LineSerivce = new();
            Line lLine = new();

            try
            {
                Console.WriteLine("###                     Primeiro Quadrado                            ###");
                LerQuadrado(lSquare1);
                Console.WriteLine("###                      Segundo Quadrado                            ###");
                LerQuadrado(lSquare2);

                using (var db = new GeoContext())
                {
                    db.Square.AddAsync(lSquare1);
                    db.Square.AddAsync(lSquare2);
                    db.SaveChangesAsync();
                }

                lSquare1.SetPoints();
                lSquare2.SetPoints();

                var lTan = _LineSerivce.CalcTang(lSquare1.PC, lSquare2.PC);

                _LineSerivce.SetLinePoint(lSquare1, lTan, (lSquare1.StartX < lSquare2.StartX), lLine);
                _LineSerivce.SetLinePoint(lSquare2, lTan, (lSquare2.StartX < lSquare1.StartX), lLine);

                Console.Clear();

                using (var db = new GeoContext())
                {
                    db.Line.AddAsync(lLine);
                    db.SaveChangesAsync();
                }



                Console.WriteLine("########################################################################");
                Console.WriteLine("##                                                                   ###");
                Console.WriteLine("##             Após os complexos calculos necessarios                ###");
                Console.WriteLine("##      O Resultado encontrado foi uma linha saida do ponto          ###");
                Console.WriteLine("##                                                                   ###");
                Console.WriteLine("##                   X = " + lLine.StartX.ToString("0.0") + "            e Y = " + lLine.StartY.ToString("0.0") + "                    ###");
                Console.WriteLine("##                                                                   ###");
                Console.WriteLine("##                 E indo em direção ao ponto                        ###");
                Console.WriteLine("##                                                                   ###");
                Console.WriteLine("##                   X = " + lLine.EndX.ToString("0.0") + "            e Y = " + lLine.EndY.ToString("0.0") + "                   ###");
                Console.WriteLine("##                                                                   ###");
                Console.WriteLine("##                                                                   ###");
                Console.WriteLine("##                    #                                              ###");
                Console.WriteLine("##                      #                                            ###");
                Console.WriteLine("##                        #                                          ###");
                Console.WriteLine("##                           #                                       ###");
                Console.WriteLine("##                              #                                    ###");
                Console.WriteLine("##                                 #                                 ###");
                Console.WriteLine("##                                    #                              ###");
                Console.WriteLine("##                                       #                           ###");
                Console.WriteLine("##                                          #                        ###");
                Console.WriteLine("########################################################################");



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
