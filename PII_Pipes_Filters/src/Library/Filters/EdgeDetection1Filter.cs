using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    public class EdgeDetection1Filter : FilterConvolution
    {
          public EdgeDetection1Filter()
          {
               this.MatrizParametros = new int[3, 3];
               this.Complemento = 0;
               this.Divisor = 1;
            
               MatrizParametros[0, 0] = 1;
               MatrizParametros[2, 2] = 1;
               MatrizParametros[0, 2] = -1;
               MatrizParametros[2, 0] = -1;

          }
     }
}