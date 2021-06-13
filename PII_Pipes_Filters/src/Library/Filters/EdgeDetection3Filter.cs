using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    public class EdgeDetection3Filter : FilterConvolution
    {
        public EdgeDetection3Filter()
        {
          this.MatrizParametros = new int[3, 3];
          this.Complemento = 0;
          this.Divisor = 1;
            
          for (int x = 0; x < 3; x++)
          {
               for (int y = 0; y < 3; y++)
               {
                    MatrizParametros[x, y] = -1;
               }
          }
               MatrizParametros[1,1] = 8;
          }
    }
}